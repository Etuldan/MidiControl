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
	c    map[string]connector.Connector
	m    Mapping
}

func NewMidi(logger *logger.Logger, m Mapping) *Midi {
	return &Midi{log: logger, m: m}
}

func (m *Midi) UpdateConnector(c map[string]connector.Connector) {
	m.c = c
}

func (m *Midi) UpdateMapping(mapping Mapping) {
	m.m = mapping
}

func (m *Midi) feedback(state *bool, device drivers.In, ch uint8, key uint8) {
	if state == nil {
		return
	}
	m.log.LogInfo("Light %v", *state)
}

func checkInput(mapping Common, device drivers.In, channel uint8, key uint8) bool {
	if mapping.Device == device.String() && mapping.Channel == channel && mapping.Key == key {
		return true
	}

	return false
}

func isToggle(mapping ButtonsMapping) bool {
	return len(mapping.ActionsDown) == 0
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
				m.log.LogInfo("[%s] got sysex: % X\n", device.String(), bt)
			case msg.GetNoteStart(&ch, &key, &vel):
				m.log.LogInfo("[%s] starting note %v on channel %v with velocity %v\n", device.String(), key, ch, vel)
				var finalState *bool
				for _, mapping := range m.m.Buttons {
					if checkInput(mapping.Common, device, ch, key) {
						go func() {
							for _, actions := range mapping.ActionsDown {
								result, err := m.c[actions.Connector].OnPress(actions.Action)
								if isToggle(mapping) {
									if err == nil && result != nil {
										if finalState == nil {
											finalState = result
										} else {
											*finalState = *result || *finalState
										}
									}
								}
							}
							if isToggle(mapping) {
								m.feedback(finalState, device, ch, key)
							}
						}()
						break
					}
				}
			case msg.GetNoteEnd(&ch, &key):
				m.log.LogInfo("[%s] ending note %s on channel %v\n", device.String(), midiDriver.Note(key), ch)
				for _, mapping := range m.m.Buttons {
					if checkInput(mapping.Common, device, ch, key) {
						for _, actions := range mapping.ActionsUp {
							m.c[actions.Connector].OnRelease(actions.Action)
						}
						break
					}
				}
			case msg.GetControlChange(&ch, &controller, &value):
				var float float32 = float32(value) / 127
				m.log.LogInfo("[%s] control change %v on channel %v for value %v\n", device.String(), controller, ch, float)

				for _, mapping := range m.m.Sliders {
					if checkInput(mapping.Common, device, ch, controller) {
						for _, actions := range mapping.Actions {
							m.c[actions.Connector].OnControlChange(actions.Action, float)
						}
						break
					}
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
