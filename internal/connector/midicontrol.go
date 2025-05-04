package connector

import (
	"midicontrol/internal/logger"
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

func (k MidiControl) OnPress(action string) (*bool, error) {
	switch action {
	case "mapping":
		k.s.UpdateMapping("")
	case "sleep":
		time.Sleep(5 * time.Second)
	}
	return nil, nil
}

func (k MidiControl) OnRelease(action string) error {

	return nil
}

func (k MidiControl) OnControlChange(action string, value float32) error {

	return nil
}
