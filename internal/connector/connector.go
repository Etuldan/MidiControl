package connector

type Connector interface {
	OnPress(device string, key uint8, channel uint8, velocity uint8) (*bool, error)
	OnRelease(device string, key uint8, channel uint8, velocity uint8) error
	OnControlChange(device string, controller uint8, channel uint8, value float32) error
}
