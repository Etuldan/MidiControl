package service

import (
	"fmt"
	"midicontrol/internal/connector"
	"midicontrol/internal/logger"
	"midicontrol/internal/midi"
	"time"

	"golang.org/x/sys/windows/svc"
	"golang.org/x/sys/windows/svc/debug"
)

type Service struct {
	log  *logger.Logger
	midi *midi.Midi
}

func (s Service) UpdateMapping(file string) error {
	connectorMappings, err := midi.NewMapping(file)
	if err != nil {
		return err
	}
	s.midi.UpdateMapping(*connectorMappings)
	return nil
}

func NewService(log *logger.Logger, mappingFile string) *Service {
	connectorMappings, err := midi.NewMapping(mappingFile)
	if err != nil {
		log.LogError("Unable to load mapping %v", err)
		return nil
	}

	midi := midi.NewMidi(log, *connectorMappings)
	service := Service{log: log, midi: midi}

	connectors := make(map[string]connector.Connector, 0)

	/*
		audio, err := connector.NewAudio(log)
		if err != nil {
			log.LogError("Unable to load Audio %v", err)
		} else {
			connectors["audio"] = audio
			defer audio.Close()
		}
	*/

	keyboard, err := connector.NewKeyboard(log)
	if err != nil {
		log.LogError("Unable to load Keyboard %v", err)
	} else {
		connectors["keyboard"] = keyboard
	}

	midicontrol := connector.NewMidiControl(log, service)
	if err != nil {
		log.LogError("Unable to load MidiControl %v", err)
	} else {
		connectors["midicontrol"] = midicontrol
	}

	/*
		obs, err := connector.NewObs(log)
		if err != nil {
			log.LogError("Unable to load OBS %v", err)
		} else {
			defer obs.Close()
			connectors["obs"] = obs
		}
	*/

	midi.UpdateConnector(connectors)
	midi.Listen()

	return &service
}

func (s *Service) Execute(args []string, r <-chan svc.ChangeRequest, changes chan<- svc.Status) (ssec bool, errno uint32) {
	const cmdsAccepted = svc.AcceptStop | svc.AcceptShutdown | svc.AcceptPauseAndContinue

	changes <- svc.Status{State: svc.StartPending}

	fasttick := time.Tick(500 * time.Millisecond)
	slowtick := time.Tick(2 * time.Second)
	tick := fasttick

	changes <- svc.Status{State: svc.Running, Accepts: cmdsAccepted}

loop:
	for {
		select {
		case <-tick:
			//s.log.LogInfo("Tick Handled...!")
		case c := <-r:
			switch c.Cmd {
			case svc.Interrogate:
				changes <- c.CurrentStatus
			case svc.Stop, svc.Shutdown:
				s.midi.Stop()
				s.log.LogInfo("Shutting service...!")
				break loop
			case svc.Pause:
				s.midi.Stop()
				changes <- svc.Status{State: svc.Paused, Accepts: cmdsAccepted}
				tick = slowtick
			case svc.Continue:
				s.midi.Listen()
				changes <- svc.Status{State: svc.Running, Accepts: cmdsAccepted}
				tick = fasttick
			default:
				s.log.LogWarning("Unexpected service control request #%d", c)
			}
		}
	}

	changes <- svc.Status{State: svc.StopPending}
	return
}

func (s *Service) RunService(name string, service bool) {
	if service {
		err := svc.Run(name, s)
		if err != nil {
			fmt.Println("Error running service in Service Control mode.")
		}
	} else {
		err := debug.Run(name, s)
		if err != nil {
			fmt.Println("Error running program")
		}
	}
}
