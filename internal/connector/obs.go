package connector

import (
	"midicontrol/internal/logger"
	"strings"

	"github.com/andreykaipov/goobs"
	"github.com/andreykaipov/goobs/api/requests/scenes"
)

type Obs struct {
	m KeyMapping
	o *goobs.Client
	l *logger.Logger
}

func NewObs(mapping KeyMapping, logger *logger.Logger) (*Obs, error) {
	// TODO Config
	client, err := goobs.New("localhost:4455", goobs.WithPassword("97kI0JjvVGx40dOr"))
	if err != nil {
		return nil, err
	}
	logger.LogInfo("OBS Websocket connected")
	return &Obs{m: mapping, o: client, l: logger}, nil
}

func (k Obs) Close() error {
	return k.o.Disconnect()
}

func (k Obs) OnPress(device string, key uint8, channel uint8, velocity uint8) (*bool, error) {
	data, toggle, err := k.m.GetInfo(key, ActionDown)
	if err != nil {
		return nil, err
	}
	action := strings.Fields(data)

	err = k.doAction(action[0], action[1:]...)
	if err != nil {
		return nil, err
	}

	if toggle {
		toggleResult := true

		return &toggleResult, nil
	}
	return nil, nil
}

func (k Obs) OnRelease(device string, key uint8, channel uint8, velocity uint8) error {
	data, toggle, err := k.m.GetInfo(key, ActionUp)
	if err != nil || toggle {
		return err
	}

	action := strings.Fields(data)
	return k.doAction(action[0], action[1:]...)
}

func (k Obs) OnControlChange(device string, controller uint8, channel uint8, value float32) error {

	return nil
}

func (k Obs) doAction(action string, params ...string) error {
	var err error
	switch action {
	case "switchScene":
		scene := &scenes.SetCurrentProgramSceneParams{
			SceneName: &params[0],
		}
		_, err = k.o.Scenes.SetCurrentProgramScene(scene)
	case "previewScene":
		scene := &scenes.SetCurrentPreviewSceneParams{
			SceneName: &params[0],
		}
		_, err = k.o.Scenes.SetCurrentPreviewScene(scene)
	}
	return err
}
