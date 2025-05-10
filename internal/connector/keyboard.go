package connector

import (
	"midicontrol/internal/tools"
	"strconv"

	"github.com/micmonay/keybd_event"
)


type Keyboard struct {
	kb keybd_event.KeyBonding
	l  *tools.Logger
}

func NewKeyboard(logger *tools.Logger) (*Keyboard, error) {
	kb, err := keybd_event.NewKeyBonding()
	if err != nil {
		return nil, err
	}
	return &Keyboard{kb: kb, l: logger}, nil
}

func (k Keyboard) OnPress(action Action) (*bool, error) {
	switch action.Command {
	case "press":
		for _, param := range action.Params {
			return nil, k.sendInput(param)
		}
	}
	return nil, nil
}

func (k Keyboard) OnRelease(action Action) error {
	switch action.Command {
	case "press":
		for _, param := range action.Params {
			return k.sendInput(param)
		}
	}
	return nil
}

func (k Keyboard) OnControlChange(action Action, value float32) error {
	switch action.Command {
	case "press":
		for _, param := range action.Params {
			return k.sendInput(param)
		}
	}
	return nil
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
