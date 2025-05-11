package connector

import (
	"midicontrol/internal/tools"
	"strings"

	"github.com/go-ole/go-ole"
	"github.com/moutend/go-wca/pkg/wca"
)

const (
	AUDIO_MUTE       = "mute"
	AUDIO_UNMUTE     = "unmute"
	AUDIO_TOGGLEMUTE = "togglemute"
	AUDIO_VOLUME     = "volume"
)

type Audio struct {
	l    *tools.Logger
	mmde *wca.IMMDeviceEnumerator
	aev  map[string]*wca.IAudioEndpointVolume
}

func NewAudio(logger *tools.Logger) (*Audio, error) {
	if err := ole.CoInitializeEx(0, ole.COINIT_MULTITHREADED); err != nil {
		return nil, err
	}

	var mmde *wca.IMMDeviceEnumerator
	if err := wca.CoCreateInstance(wca.CLSID_MMDeviceEnumerator, 0, wca.CLSCTX_ALL, wca.IID_IMMDeviceEnumerator, &mmde); err != nil {
		return nil, err
	}

	var mmdc *wca.IMMDeviceCollection
	err := mmde.EnumAudioEndpoints(wca.ERender, wca.DEVICE_STATE_ACTIVE, &mmdc)
	if err != nil {
		return nil, err
	}

	var count uint32
	err = mmdc.GetCount(&count)
	if err != nil {
		return nil, err
	}
	devices := make(map[string]*wca.IAudioEndpointVolume, 0)

	var mmd *wca.IMMDevice
	err = mmde.GetDefaultAudioEndpoint(wca.ERender, wca.EConsole, &mmd)
	if err != nil {
		return nil, err
	}

	var aev *wca.IAudioEndpointVolume
	err = mmd.Activate(wca.IID_IAudioEndpointVolume, wca.CLSCTX_ALL, nil, &aev)
	if err != nil {
		return nil, err
	}
	devices["DEFAULT"] = aev

	for i := range count {
		err = mmdc.Item(i, &mmd)
		if err != nil {
			return nil, err
		}

		var ps *wca.IPropertyStore
		if err := mmd.OpenPropertyStore(wca.STGM_READ, &ps); err != nil {
			return nil, err
		}

		var pv wca.PROPVARIANT
		if err := ps.GetValue(&wca.PKEY_Device_FriendlyName, &pv); err != nil {
			return nil, err
		}

		deviceName := pv.String()
		logger.LogInfo("found audio output device %s", deviceName)

		err := mmd.Activate(wca.IID_IAudioEndpointVolume, wca.CLSCTX_ALL, nil, &aev)
		if err != nil {
			return nil, err
		}
		devices[deviceName] = aev

		mmd.Release()
		ps.Release()
	}

	return &Audio{l: logger, mmde: mmde, aev: devices}, nil
}

func (k Audio) Close() {
	k.l.LogInfo("stopping audio ...")
	for deviceName, aev := range k.aev {
		k.l.LogInfo("releasing device %v", deviceName)
		defer aev.Release()
	}
	k.mmde.Release()
	ole.CoUninitialize()
}

func (k Audio) OnPress(action Action) (toggle *bool, err error) {
	switch action.Command {
	case AUDIO_TOGGLEMUTE:
		var value bool = true
		if action.Toggle {
			err := k.aev[getDeviceName(action.Params)].GetMute(&value)
			if err != nil {
				return nil, err
			}
			value = !value
		}
		k.aev[getDeviceName(action.Params)].SetMute(value, nil)
	case AUDIO_MUTE:
		k.aev[getDeviceName(action.Params)].SetMute(true, nil)
	case AUDIO_UNMUTE:
		k.aev[getDeviceName(action.Params)].SetMute(false, nil)
	}
	return nil, nil
}

func (k Audio) OnRelease(action Action) error {
	switch action.Command {
	case AUDIO_MUTE:
		k.aev[getDeviceName(action.Params)].SetMute(true, nil)
	case AUDIO_UNMUTE:
		k.aev[getDeviceName(action.Params)].SetMute(false, nil)
	}
	return nil
}

func (k Audio) OnControlChange(action Action, value float32) error {
	switch action.Command {
	case AUDIO_VOLUME:
		return k.aev[getDeviceName(action.Params)].SetMasterVolumeLevelScalar(value, nil)
	}
	return nil
}

func getDeviceName(params []string) (deviceName string) {
	deviceName = "DEFAULT"
	if len(params) > 1 && params[0] == "device" {
		deviceName = strings.Join([]string(params[1:]), " ")
	}
	return
}
