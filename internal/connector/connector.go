package connector

type Action struct {
	Command string
	Params  []string
}

type Connector interface {
	OnPress(action Action) (*bool, error)
	OnRelease(action Action) error
	OnControlChange(action Action, value float32) error
}
