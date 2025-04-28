package connector

import (
	"midicontrol/internal/logger"
	"strconv"

	"github.com/micmonay/keybd_event"
)

type Keyboard struct {
	m  KeyMapping
	kb keybd_event.KeyBonding
	l  *logger.Logger
}

type Action struct {
	Key int `json:"keys"`
}

func NewKeyboard(mapping KeyMapping, logger *logger.Logger) (*Keyboard, error) {
	kb, err := keybd_event.NewKeyBonding()
	if err != nil {
		return nil, err
	}
	return &Keyboard{m: mapping, kb: kb, l: logger}, nil
}

func (k Keyboard) sendInput(data string) error {
	defer k.kb.Clear()

	i, err := strconv.Atoi(data)
	if err != nil {
		return err
	}

	k.kb.SetKeys(i)
	return k.kb.Launching()
}

func (k Keyboard) OnPress(device string, key uint8, channel uint8, velocity uint8) (*bool, error) {
	data, _, err := k.m.GetInfo(key, ActionDown)
	if err != nil {
		return nil, err
	}

	return nil, k.sendInput(data)
}

func (k Keyboard) OnRelease(device string, key uint8, channel uint8, velocity uint8) error {
	data, _, err := k.m.GetInfo(key, ActionUp)
	if err != nil {
		return err
	}
	return k.sendInput(data)
}

func (k Keyboard) OnControlChange(device string, controller uint8, channel uint8, value float32) error {
	data, err := k.m.GetActionSlider(controller)
	if err != nil {
		return err
	}
	return k.sendInput(data)
}
