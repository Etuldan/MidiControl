package connector

import (
	"fmt"
	"midicontrol/internal/tools"

	"github.com/andreykaipov/goobs"
	"github.com/andreykaipov/goobs/api/requests/inputs"
	"github.com/andreykaipov/goobs/api/requests/sceneitems"
	"github.com/andreykaipov/goobs/api/requests/scenes"
	"github.com/andreykaipov/goobs/api/requests/sources"
)

const (
	OBS_SWITCHSCENE  = "switchScene"
	OBS_PREVIEWSCENE = "previewScene"
	OBS_MUTE         = "mute"
	OBS_UNMUTE       = "unmute"
	OBS_TOGGLEMUTE   = "togglemute"
	OBS_HIDE         = "hide"
	OBS_SHOW         = "show"
	OBS_TOGGLEHIDE   = "togglehide"
)

type Obs struct {
	o *goobs.Client
	l *tools.Logger
}

func NewObs(logger *tools.Logger, config *tools.Config) (*Obs, error) {
	client, err := goobs.New(fmt.Sprintf("%s:%s", config.Obs.Host, config.Obs.Port), goobs.WithPassword(config.Obs.Password))
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
	if len(action.Params) == 0 {
		return nil, ErrInvalidParameter
	}

	err := k.doAction(action.Command, action.Params...)
	if err != nil {
		return nil, err
	}

	toggleResult := true

	return &toggleResult, nil
}

func (k Obs) OnRelease(action Action) error {
	if len(action.Params) == 0 {
		return ErrInvalidParameter
	}

	return k.doAction(action.Command, action.Params...)
}

func (k Obs) OnControlChange(action Action, value float32) error {
	if len(action.Params) == 0 {
		return ErrInvalidParameter
	}

	return nil
}

func (k Obs) doAction(action string, params ...string) error {
	var err error
	switch action {
	case OBS_SWITCHSCENE:
		_, err = k.o.Scenes.SetCurrentProgramScene(&scenes.SetCurrentProgramSceneParams{
			SceneName: &params[0],
		})
	case OBS_PREVIEWSCENE:
		_, err = k.o.Scenes.SetCurrentPreviewScene(&scenes.SetCurrentPreviewSceneParams{
			SceneName: &params[0],
		})
	case OBS_MUTE:
		mute := true
		for _, source := range params {
			k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
				InputMuted: &mute,
				InputName:  &source,
			})
		}
	case OBS_UNMUTE:
		mute := false
		for _, source := range params {
			k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
				InputMuted: &mute,
				InputName:  &source,
			})
		}
	case OBS_TOGGLEMUTE:
		for _, source := range params {
			resp, err := k.o.Inputs.GetInputMute(&inputs.GetInputMuteParams{
				InputName: &source,
			})
			mute := !resp.InputMuted
			if err == nil {
				k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
					InputMuted: &mute,
					InputName:  &source,
				})
			}
		}
	case OBS_HIDE:
		hide := true
		return k.manageScenes(&hide)
	case OBS_SHOW:
		hide := false
		return k.manageScenes(&hide)
	case OBS_TOGGLEHIDE:
		return k.manageScenes(nil)
	}
	return err
}

func (k Obs) manageScenes(hideParam *bool) error {
	scenes, err := k.o.Scenes.GetSceneList()
	if err != nil {
		return err
	}
	for _, scene := range scenes.Scenes {
		var hide bool
		if hideParam == nil {
			resp, err := k.o.Sources.GetSourceActive(&sources.GetSourceActiveParams{
				SourceName: &scene.SceneName,
			})
			if err != nil {
				return err
			}
			hide = !resp.VideoShowing
		} else {
			hide = *hideParam
		}

		sceneItemList, err := k.o.SceneItems.GetGroupSceneItemList(&sceneitems.GetGroupSceneItemListParams{
			SceneName: &scene.SceneName,
		})
		if err == nil {
			for _, item := range sceneItemList.SceneItems {
				k.o.SceneItems.SetSceneItemEnabled(&sceneitems.SetSceneItemEnabledParams{
					SceneItemEnabled: &hide,
					SceneItemId:      &item.SceneItemID,
					SceneName:        &scene.SceneName,
				})
			}
		}
	}
	return nil
}
