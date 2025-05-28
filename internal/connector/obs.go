package connector

import (
	"fmt"
	"midicontrol/internal/tools"
	"strconv"

	"github.com/andreykaipov/goobs"
	"github.com/andreykaipov/goobs/api/requests/filters"
	"github.com/andreykaipov/goobs/api/requests/general"
	"github.com/andreykaipov/goobs/api/requests/inputs"
	"github.com/andreykaipov/goobs/api/requests/record"
	"github.com/andreykaipov/goobs/api/requests/sceneitems"
	"github.com/andreykaipov/goobs/api/requests/scenes"
	"github.com/andreykaipov/goobs/api/requests/sources"
	"github.com/andreykaipov/goobs/api/requests/stream"
	"github.com/andreykaipov/goobs/api/requests/transitions"
	"github.com/andreykaipov/goobs/api/requests/ui"
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
	OBS_SHOWFILTER   = "showfilter"
	OBS_HIDEFILTER   = "hidefilter"
	OBS_TOGGLEFILTER = "togglefilter"

	OBS_MEDIAPLAY    = "mediaplay"
	OBS_MEDIASTOP    = "mediastop"
	OBS_MEDIARESTART = "mediarestart"

	OBS_TRANSITION = "transtion"
	OBS_HOTKEY     = "hotkey"

	OBS_STREAMSTART     = "streamstart"
	OBS_STREAMSTOP      = "streamstop"
	OBS_STREAMTOGGLE    = "streamtoggle"
	OBS_RECORDSTART     = "recordstart"
	OBS_RECORDSTOP      = "recordstop"
	OBS_RECORDTOGGLE    = "recordtoggle"
	OBS_RECORDPLAYPAUSE = "recordplaypause"
	OBS_RECORDPAUSE     = "recordpause"
	OBS_RECORDRESUME    = "recordresume"
	OBS_RECORDSAVE      = "recordsave"

	OBS_TRANSITIONTOPROGRAM = "transitiontoprogram"
	OBS_TOGGLESTUDIOMODE    = "togglestudiomode"
)

type Obs struct {
	o *goobs.Client
	l *tools.Logger
}

func newTrue() *bool {
	b := true
	return &b
}

func newFalse() *bool {
	b := false
	return &b
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

	status, err := k.doAction(action.Command, action.Params...)
	if err != nil {
		return nil, err
	}

	return status, nil
}

func (k Obs) OnRelease(action Action) error {
	if len(action.Params) == 0 {
		return ErrInvalidParameter
	}
	_, err := k.doAction(action.Command, action.Params...)
	return err
}

func (k Obs) OnControlChange(action Action, value float32) error {
	if len(action.Params) == 0 {
		return ErrInvalidParameter
	}

	return nil
}

func (k Obs) doAction(action string, params ...string) (status *bool, err error) {
	switch action {
	case OBS_SWITCHSCENE:
		_, err = k.o.Scenes.SetCurrentProgramScene(&scenes.SetCurrentProgramSceneParams{
			SceneName: &params[0],
		})
		return
	case OBS_PREVIEWSCENE:
		_, err = k.o.Scenes.SetCurrentPreviewScene(&scenes.SetCurrentPreviewSceneParams{
			SceneName: &params[0],
		})
		return

	case OBS_MUTE:
		mute := true
		for _, source := range params {
			_, err = k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
				InputMuted: &mute,
				InputName:  &source,
			})
		}
		return
	case OBS_UNMUTE:
		mute := false
		for _, source := range params {
			_, err = k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
				InputMuted: &mute,
				InputName:  &source,
			})
		}
		return
	case OBS_TOGGLEMUTE:
		var resp *inputs.GetInputMuteResponse
		for _, source := range params {
			resp, err = k.o.Inputs.GetInputMute(&inputs.GetInputMuteParams{
				InputName: &source,
			})
			mute := !resp.InputMuted
			if err == nil {
				_, err = k.o.Inputs.SetInputMute(&inputs.SetInputMuteParams{
					InputMuted: &mute,
					InputName:  &source,
				})
			}
		}
		return

	case OBS_HIDE:
		show := true
		return nil, k.manageScene(params[0], &show)
	case OBS_SHOW:
		show := false
		return nil, k.manageScene(params[0], &show)
	case OBS_TOGGLEHIDE:
		return nil, k.manageScene(params[0], nil)

	case OBS_HIDEFILTER:
		show := true
		return nil, k.manageFilter(params[0], &show)
	case OBS_SHOWFILTER:
		show := false
		return nil, k.manageFilter(params[0], &show)
	case OBS_TOGGLEFILTER:
		return nil, k.manageFilter(params[0], nil)

	case OBS_MEDIAPLAY:
		//TODO k.o.client.SendRequest()
	case OBS_MEDIASTOP:
		//TODO k.o.client.SendRequest()
	case OBS_MEDIARESTART:
		//TODO k.o.client.SendRequest()

	case OBS_TRANSITION:
		var duration float64
		duration, err = strconv.ParseFloat(params[0], 64)
		if err != nil {
			return
		}
		_, err = k.o.Transitions.SetCurrentSceneTransition(&transitions.SetCurrentSceneTransitionParams{
			TransitionName: &params[0],
		})
		if err != nil {
			return
		}
		_, err = k.o.Transitions.SetCurrentSceneTransitionDuration(&transitions.SetCurrentSceneTransitionDurationParams{
			TransitionDuration: &duration,
		})
		if err != nil {
			return
		}

	case OBS_HOTKEY:
		for _, hotkey := range params {
			_, err = k.o.General.TriggerHotkeyByName(&general.TriggerHotkeyByNameParams{
				HotkeyName: &hotkey,
			})
			if err != nil {
				return
			}
		}

	case OBS_STREAMSTART:
		_, err = k.o.Stream.StartStream()
		if err != nil {
			return
		}
	case OBS_STREAMSTOP:
		_, err = k.o.Stream.StopStream()
		if err != nil {
			return
		}
	case OBS_STREAMTOGGLE:
		var resp *stream.ToggleStreamResponse
		resp, err = k.o.Stream.ToggleStream()
		if err != nil {
			return
		}
		status = &resp.OutputActive
		return
	case OBS_RECORDSTART:
		_, err = k.o.Record.StartRecord()
		return
	case OBS_RECORDSTOP:
		_, err = k.o.Record.StopRecord()
		return
	case OBS_RECORDTOGGLE:
		var resp *record.ToggleRecordResponse
		resp, err = k.o.Record.ToggleRecord()
		if err != nil {
			return
		}
		status = &resp.OutputActive
		return
	case OBS_RECORDPLAYPAUSE:
		var resp *record.ToggleRecordPauseResponse
		resp, err = k.o.Record.ToggleRecordPause()
		if err != nil {
			return
		}
		status = &resp.OutputPaused
		return
	case OBS_RECORDPAUSE:
		status = newTrue()
		_, err = k.o.Record.PauseRecord()
		if err != nil {
			return
		}
		return
	case OBS_RECORDRESUME:
		status = newFalse()
		_, err = k.o.Record.ResumeRecord()
		if err != nil {
			return
		}
		return
	case OBS_RECORDSAVE:
		_, err = k.o.Outputs.SaveReplayBuffer()
		if err != nil {
			return
		}
		return

	case OBS_TOGGLESTUDIOMODE:
		var resp *ui.GetStudioModeEnabledResponse
		resp, err = k.o.Ui.GetStudioModeEnabled()
		if err != nil {
			return
		}
		enabled := resp.StudioModeEnabled
		_, err = k.o.Ui.SetStudioModeEnabled(&ui.SetStudioModeEnabledParams{
			StudioModeEnabled: &enabled,
		})
		return
	case OBS_TRANSITIONTOPROGRAM:
		_, err = k.o.Transitions.TriggerStudioModeTransition()
		return
	}
	return
}

func (k Obs) manageFilter(filterName string, showParam *bool) error {
	sceneList, err := k.o.Scenes.GetSceneList()
	if err != nil {
		return nil
	}
	for _, scene := range sceneList.Scenes {
		filterList, err := k.o.Filters.GetSourceFilterList(&filters.GetSourceFilterListParams{
			SourceName: &scene.SceneName,
		})
		if err == nil {
			for _, filter := range filterList.Filters {
				if filter.FilterName == filterName {
					var show bool
					if showParam == nil {
						filterInfo, err := k.o.Filters.GetSourceFilter(&filters.GetSourceFilterParams{
							FilterName: &filter.FilterName,
							SourceName: &scene.SceneName,
						})
						if err == nil {
							show = !filterInfo.FilterEnabled
						}
					} else {
						show = *showParam
					}

					k.o.Filters.SetSourceFilterEnabled(&filters.SetSourceFilterEnabledParams{
						FilterEnabled: &show,
						FilterName:    &filter.FilterName,
						SourceName:    &scene.SceneName,
					})
				}
			}
		}
	}
	return nil
}

func (k Obs) manageScene(sceneName string, showParam *bool) error {
	scenes, err := k.o.Scenes.GetSceneList()
	if err != nil {
		return err
	}
	for _, scene := range scenes.Scenes {
		var show bool
		if showParam == nil {
			sourceInfo, err := k.o.Sources.GetSourceActive(&sources.GetSourceActiveParams{
				SourceName: &scene.SceneName,
			})
			if err != nil {
				return err
			}
			show = !sourceInfo.VideoShowing
		} else {
			show = *showParam
		}

		sceneItemList, err := k.o.SceneItems.GetGroupSceneItemList(&sceneitems.GetGroupSceneItemListParams{
			SceneName: &scene.SceneName,
		})
		if err == nil {
			for _, item := range sceneItemList.SceneItems {
				if sceneName == item.SourceName {
					k.o.SceneItems.SetSceneItemEnabled(&sceneitems.SetSceneItemEnabledParams{
						SceneItemEnabled: &show,
						SceneItemId:      &item.SceneItemID,
						SceneName:        &scene.SceneName,
					})
				}
			}
		}
	}
	return nil
}
