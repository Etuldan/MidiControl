package connector

import (
	"midicontrol/internal/logger"
	"strings"

	"github.com/andreykaipov/goobs"
	"github.com/andreykaipov/goobs/api/requests/scenes"
)

type Obs struct {
	o *goobs.Client
	l *logger.Logger
}

func NewObs(logger *logger.Logger) (*Obs, error) {
	// TODO Config
	client, err := goobs.New("localhost:4455", goobs.WithPassword("97kI0JjvVGx40dOr"))
	if err != nil {
		return nil, err
	}
	logger.LogInfo("OBS Websocket connected")
	return &Obs{o: client, l: logger}, nil
}

func (k Obs) Close() error {
	return k.o.Disconnect()
}

func (k Obs) OnPress(action string) (*bool, error) {
	data := strings.Fields(action)

	err := k.doAction(data[0], data[1:]...)
	if err != nil {
		return nil, err
	}

	toggleResult := true

	return &toggleResult, nil
}

func (k Obs) OnRelease(action string) error {
	data := strings.Fields(action)
	return k.doAction(data[0], data[1:]...)
}

func (k Obs) OnControlChange(action string, value float32) error {

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
