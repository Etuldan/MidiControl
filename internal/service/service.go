package service

import (
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

func NewService(log *logger.Logger, midi *midi.Midi) *Service {
	return &Service{log: log, midi: midi}
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
				s.log.LogInfo("Shutting service...!")
				break loop
			case svc.Pause:
				changes <- svc.Status{State: svc.Paused, Accepts: cmdsAccepted}
				tick = slowtick
			case svc.Continue:
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

func (s *Service) RunService(name string, isDebug bool) {
	if isDebug {
		err := debug.Run(name, s)
		if err != nil {
			s.log.LogError("Error running program")
		}
	} else {
		err := svc.Run(name, s)
		if err != nil {
			s.log.LogError("Error running service in Service Control mode.")
		}
	}
}
