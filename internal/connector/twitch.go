package connector

import "fmt"

type Twitch struct {
	m KeyMapping
}

const (
	CHAT = "chat"
)

func NewTwitch(mapping KeyMapping) Twitch {
	return Twitch{m: mapping}
}

func (k Twitch) OnPress(device string, key uint8, channel uint8, velocity uint8) (*bool, error) {
	a, err := k.m.GetActionDown(key)
	fmt.Println(a)
	return nil, err
}

func (k Twitch) OnRelease(device string, key uint8, channel uint8, velocity uint8) error {

	return nil
}

func (k Twitch) OnControlChange(device string, controller uint8, channel uint8, value float32) error {

	return nil
}
