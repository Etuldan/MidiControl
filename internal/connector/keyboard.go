package connector

import (
	"midicontrol/internal/logger"
	"strconv"

	"github.com/micmonay/keybd_event"
)

type Keyboard struct {
	kb keybd_event.KeyBonding
	l  *logger.Logger
}

func NewKeyboard(logger *logger.Logger) (*Keyboard, error) {
	kb, err := keybd_event.NewKeyBonding()
	if err != nil {
		return nil, err
	}
	return &Keyboard{kb: kb, l: logger}, nil
}

func (k Keyboard) OnPress(action string) (*bool, error) {
	return nil, k.sendInput(action)
}

func (k Keyboard) OnRelease(action string) error {
	return k.sendInput(action)
}

func (k Keyboard) OnControlChange(action string, value float32) error {
	return k.sendInput(action)
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
