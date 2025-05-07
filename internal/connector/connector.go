package connector

import "fmt"

type Action struct {
	Command string
	Params  []string
	Toggle  bool
}

var ErrInvalidParameter error = fmt.Errorf("invalid parameter")

type Connector interface {
	OnPress(action Action) (*bool, error)
	OnRelease(action Action) error
	OnControlChange(action Action, value float32) error
}
