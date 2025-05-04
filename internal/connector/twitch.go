package connector

type Twitch struct {
}

const (
	CHAT = "chat"
)

func NewTwitch() Twitch {
	return Twitch{}
}

func (k Twitch) OnPress(action string) (*bool, error) {

	return nil, nil
}

func (k Twitch) OnRelease(action string) error {

	return nil
}

func (k Twitch) OnControlChange(action string, value float32) error {

	return nil
}
