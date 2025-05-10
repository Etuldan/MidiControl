package connector

import (
	"fmt"
	"midicontrol/internal/tools"

	"github.com/andreykaipov/goobs"
	"github.com/andreykaipov/goobs/api/requests/scenes"
)

const (
	OBS_SWITCHSCENE  = "switchScene"
	OBS_PREVIEWSCENE = "previewScene"
)

type Obs struct {
	o *goobs.Client
	l *tools.Logger
}

func NewObs(logger *tools.Logger, config *tools.Config) (*Obs, error) {
	client, err := goobs.New(fmt.Sprintf("%s:%s", config.Obs.Host, config.Obs.Password), goobs.WithPassword(config.Obs.Password))
	if err != nil {
		return nil, err
	}
	logger.LogInfo("OBS Websocket connected")
	return &Obs{o: client, l: logger}, nil
}

func (k Obs) Close() error {
	return k.o.Disconnect()
}

func (k Obs) OnPress(action Action) (*bool, error) {
	err := k.doAction(action.Command, action.Params...)
	if err != nil {
		return nil, err
	}

	toggleResult := true

	return &toggleResult, nil
}

func (k Obs) OnRelease(action Action) error {
	return k.doAction(action.Command, action.Params...)
}

func (k Obs) OnControlChange(action Action, value float32) error {

	return nil
}

func (k Obs) doAction(action string, params ...string) error {
	var err error
	switch action {
	case OBS_SWITCHSCENE:
		scene := &scenes.SetCurrentProgramSceneParams{
			SceneName: &params[0],
		}
		_, err = k.o.Scenes.SetCurrentProgramScene(scene)
	case OBS_PREVIEWSCENE:
		scene := &scenes.SetCurrentPreviewSceneParams{
			SceneName: &params[0],
		}
		_, err = k.o.Scenes.SetCurrentPreviewScene(scene)
	}
	return err
}
