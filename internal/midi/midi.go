package midi

import (
	"midicontrol/internal/connector"
	"midicontrol/internal/logger"

	midiDriver "gitlab.com/gomidi/midi/v2"
	"gitlab.com/gomidi/midi/v2/drivers"
	_ "gitlab.com/gomidi/midi/v2/drivers/rtmididrv" // autoregisters driver
)

type Midi struct {
	stop func()
	log  *logger.Logger
	c    []connector.Connector
}

func NewMidi(logger *logger.Logger, connectors []connector.Connector) *Midi {
	return &Midi{log: logger, c: connectors}
}

func (m *Midi) feedback(state *bool) {
	if state == nil {
		return
	}
	m.log.LogInfo("Light %v", *state)
}

func (m *Midi) UpdateConnectors(connectors []connector.Connector) {
	m.c = connectors
}

func (m *Midi) Listen() {
	var err error
	inPorts := midiDriver.GetInPorts()

	m.log.LogInfo("MIDI devices %s", inPorts.String())
	devices := make([]drivers.In, len(inPorts))
	for i, device := range inPorts {
		devices[i], err = midiDriver.FindInPort(device.String())
		if err != nil {
			m.log.LogError("can't find %s", device.String())
			return
		}
	}

	for _, device := range devices {
		m.stop, err = midiDriver.ListenTo(device, func(msg midiDriver.Message, timestampms int32) {
			var bt []byte
			var ch, key, vel uint8
			var controller, value uint8
			switch {
			case msg.GetSysEx(&bt):
				//m.log.LogInfo("[%s] got sysex: % X\n", device.String(), bt)
			case msg.GetNoteStart(&ch, &key, &vel):
				//m.log.LogInfo("[%s] starting note %v on channel %v with velocity %v\n", device.String(), key, ch, vel)
				var finalState *bool
				for _, connector := range m.c {
					result, err := connector.OnPress(device.String(), key, ch, vel)
					if err == nil && result != nil {
						if finalState == nil {
							finalState = result
						} else {
							*finalState = *result || *finalState
						}
					}
				}
				m.feedback(finalState)

			case msg.GetNoteEnd(&ch, &key):
				//m.log.LogInfo("[%s] ending note %s on channel %v\n", device.String(), midiDriver.Note(key), ch)
				for _, connector := range m.c {
					connector.OnRelease(device.String(), key, ch, vel)
				}
			case msg.GetControlChange(&ch, &controller, &value):
				var float float32 = float32(value) / 127
				m.log.LogInfo("[%s] control change %v on channel %v for value %v\n", device.String(), controller, ch, float)
				for _, connector := range m.c {
					connector.OnControlChange(device.String(), controller, ch, float)
				}

			default:
				// ignore
			}
		}, midiDriver.UseSysEx())

		if err != nil {
			m.log.LogError("[%s] ERROR: %s\n", device.String(), err)
			return
		}
	}
}

func (m *Midi) Stop() {
	defer midiDriver.CloseDriver()
	m.stop()
}
