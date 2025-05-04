package connector

type Connector interface {
	OnPress(action string) (*bool, error)
	OnRelease(action string) error
	OnControlChange(action string, value float32) error
}
