package connector

import (
	"midicontrol/internal/logger"
	"os/exec"
	"strconv"
	"time"
)

type service interface {
	UpdateMapping(file string) error
}

type MidiControl struct {
	l *logger.Logger
	s service
}

func NewMidiControl(logger *logger.Logger, service service) *MidiControl {
	return &MidiControl{l: logger, s: service}
}

func (k MidiControl) OnPress(action Action) (*bool, error) {
	return nil, k.doAction(action)
}

func (k MidiControl) OnRelease(action Action) error {
	return k.doAction(action)
}

func (k MidiControl) OnControlChange(action Action, value float32) error {

	return nil
}

func (k MidiControl) doAction(action Action) error {
	if len(action.Params) == 0 {
		return ErrInvalidParameter
	}

	switch action.Command {
	case "mapping":
		k.s.UpdateMapping(action.Params[0])
	case "sleep":
		duration, err := strconv.Atoi(action.Params[0])
		if err != nil {
			return err
		}
		time.Sleep(time.Second * time.Duration(duration))
	case "exec":
		cmd := exec.Command(action.Params[0], action.Params[1:]...)
		err := cmd.Run()
		if err != nil {
			k.l.LogError("error %v", err)
			return err
		}
	}
	return nil
}
