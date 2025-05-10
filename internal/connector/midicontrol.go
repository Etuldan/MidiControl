package connector

import (
	"midicontrol/internal/tools"
	"os/exec"
	"strconv"
	"time"
)

const (
	MIDICONTROL_MAPPING = "mapping"
	MIDICONTROL_SLEEP   = "sleep"
	MIDICONTROL_EXEC    = "exec"
)

type service interface {
	UpdateMapping(file string) error
}

type MidiControl struct {
	l *tools.Logger
	s service
}

func NewMidiControl(logger *tools.Logger, service service) *MidiControl {
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
	case MIDICONTROL_MAPPING:
		k.s.UpdateMapping(action.Params[0])
	case MIDICONTROL_SLEEP:
		duration, err := strconv.Atoi(action.Params[0])
		if err != nil {
			return err
		}
		time.Sleep(time.Second * time.Duration(duration))
	case MIDICONTROL_EXEC:
		cmd := exec.Command(action.Params[0], action.Params[1:]...)
		err := cmd.Run()
		if err != nil {
			k.l.LogError("error %v", err)
			return err
		}
	}
	return nil
}
