package connector

type Twitch struct {
}

const (
	CHAT = "chat"
)

func NewTwitch() Twitch {
	return Twitch{}
}

func (k Twitch) OnPress(action Action) (*bool, error) {

	return nil, nil
}

func (k Twitch) OnRelease(action Action) error {

	return nil
}

func (k Twitch) OnControlChange(action Action, value float32) error {

	return nil
}
