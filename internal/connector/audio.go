package connector

import (
	"midicontrol/internal/logger"
	"strings"

	"github.com/go-ole/go-ole"
	"github.com/moutend/go-wca/pkg/wca"
)

// https://github.com/moutend/go-wca
// github.com/gen2brain/malgo

type Audio struct {
	l       *logger.Logger
	mmde    *wca.IMMDeviceEnumerator
	devices map[string]*wca.IMMDevice
}

const (
	MUTE   = "mute"
	UNMUTE = "unmute"
	VOLUME = "volume"
)

/*
type CallbackRegistration struct {
	session        *wca.IAudioSessionControl
	nativeCallback *wca.IAudioSessionEvents
}
*/

func NewAudio(logger *logger.Logger) (*Audio, error) {
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
	devices := make(map[string]*wca.IMMDevice, 0)

	var mmd *wca.IMMDevice
	err = mmde.GetDefaultAudioEndpoint(wca.ERender, wca.EConsole, &mmd)
	if err != nil {
		return nil, err
	}

	devices["DEFAULT"] = mmd

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
		devices[deviceName] = mmd
		logger.LogInfo("found audio output device %s", deviceName)

		ps.Release()
	}

	/*
		err = mmde.GetDefaultAudioEndpoint(wca.ERender, wca.EConsole, &mmd)
		if err != nil {
			return nil, err
		}

		var asm2 *wca.IAudioSessionManager2
		err = mmd.Activate(wca.IID_IAudioSessionManager2, wca.CLSCTX_INPROC_SERVER, nil, &asm2)
		if err != nil {

		}

		watch := make(chan *wca.IAudioSessionControl, 10)
		release := make(chan CallbackRegistration, 10)

		go func() {
			for session := range watch {
				setupSessionCallback(deviceName, release, session)
			}
		}()

		callback := wca.IAudioSessionNotificationCallback{
			OnSessionCreated: func(pNewSession *wca.IAudioSessionControl) error {
				return onSessionCreated(deviceName, watch, pNewSession)
			},
		}

		asn := wca.NewIAudioSessionNotification(callback)
		if err := asm2.RegisterSessionNotification(asn); err != nil {
			return nil, err
		}

		// You must call IAudioSessionEnumerator::GetCount to begin receiving notifications.
		// https://learn.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-registersessionnotification
		var sessionEnum *wca.IAudioSessionEnumerator
		err = asm2.GetSessionEnumerator(&sessionEnum)
		if err != nil {
			return nil, err
		}
		var sessionCount int
		if err := sessionEnum.GetCount(&sessionCount); err != nil {
			return nil, err
		}

		fmt.Printf("%s: %d session(s)\n", deviceName, sessionCount)

		for i := 0; i < sessionCount; i++ {
			var session *wca.IAudioSessionControl
			if err := sessionEnum.GetSession(i, &session); err != nil {
				return nil, err
			}

			session.AddRef()
			simpleVolume := (*wca.ISimpleAudioVolume)(session)
			//var state uint32
			//err = s.GetState(&state)
			//var retVal ole.GUID
			//err = s.GetGroupingParam(&retVal)
			//var muted bool
			//simpleVolume.GetMute(&muted)
			simpleVolume.SetMasterVolume(0.5, nil)
			watch <- session
		}

		var aev *wca.IAudioEndpointVolume
		err = mmd.Activate(wca.IID_IAudioEndpointVolume, wca.CLSCTX_ALL, watch, &aev)
		if err != nil {
			return nil, err
		}*/

	return &Audio{l: logger, mmde: mmde, devices: devices}, nil
}

func (k Audio) Close() {
	k.l.LogInfo("stopping audio ...")
	for deviceName, device := range k.devices {
		k.l.LogInfo("releasing device %v", deviceName)
		device.Release()
	}
	k.mmde.Release()
	ole.CoUninitialize()
}

func (k Audio) OnPress(action Action) (toggle *bool, err error) {
	k.l.LogInfo("Audio Press %v", action)
	switch action.Command {
	case MUTE:
		var value bool = false
		if action.Toggle {
			value, err = get(getMute, k.devices[getDeviceName(action.Params)])
			if err != nil {
				return nil, err
			}
		}
		return nil, set(setMute, k.devices[getDeviceName(action.Params)], !value)
	}
	return nil, nil
}

func (k Audio) OnRelease(action Action) error {
	k.l.LogInfo("Audio Press %v", action)
	switch action.Command {
	case MUTE:
		return set(setMute, k.devices[getDeviceName(action.Params)], false)
	}
	return nil
}

func (k Audio) OnControlChange(action Action, value float32) error {
	k.l.LogInfo("Audio Change %v", action)
	switch action.Command {
	case VOLUME:
		return set(setMasterVolume, k.devices[getDeviceName(action.Params)], value)
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

func set[T any](fn func(aev *wca.IAudioEndpointVolume, value T) error, mmd *wca.IMMDevice, value T) error {
	var aev *wca.IAudioEndpointVolume
	err := mmd.Activate(wca.IID_IAudioEndpointVolume, wca.CLSCTX_ALL, nil, &aev)
	if err != nil {
		return err
	}
	defer aev.Release()

	return fn(aev, value)
}

func get[T any](fn func(aev *wca.IAudioEndpointVolume) (T, error), mmd *wca.IMMDevice) (T, error) {
	var ret T
	var aev *wca.IAudioEndpointVolume
	err := mmd.Activate(wca.IID_IAudioEndpointVolume, wca.CLSCTX_ALL, nil, &aev)
	if err != nil {
		return ret, err
	}
	defer aev.Release()

	return fn(aev)
}

func setMasterVolume(aev *wca.IAudioEndpointVolume, value float32) error {
	return aev.SetMasterVolumeLevelScalar(value, nil)
}

func setMute(aev *wca.IAudioEndpointVolume, mute bool) error {
	return aev.SetMute(mute, nil)
}

func getMute(aev *wca.IAudioEndpointVolume) (bool, error) {
	var mute bool = false
	err := aev.GetMute(&mute)
	return mute, err
}

/*
func onSessionCreated(deviceName string, watch chan *wca.IAudioSessionControl, pNewSession *wca.IAudioSessionControl) error {
	fmt.Printf("%s: called OnSessionCreated\n", deviceName)
	pNewSession.AddRef()
	watch <- pNewSession
	return nil
}

func (k Audio) test(value float32) error {
	go func() {
		for s := range k.watch {
			simpleVolume := (*wca.ISimpleAudioVolume)(s)
			//var state uint32
			//err = s.GetState(&state)
			//var retVal ole.GUID
			//err = s.GetGroupingParam(&retVal)
			//var muted bool
			//simpleVolume.GetMute(&muted)
			simpleVolume.SetMasterVolume(value, nil)
			s1 := (*wca.IAudioSessionControl)(s)
			s2 := &wca.IAudioSessionControl2{
				IAudioSessionControl: *s1,
			}
			var process uint32
			s2.GetProcessId(&process)
			//fmt.Print(muted)
		}
		fmt.Println("&")
		return
	}()
	return nil
}

func setupSessionCallback(deviceName string, release chan CallbackRegistration, session *wca.IAudioSessionControl) error {
	var sessionName string
	if err := session.GetDisplayName(&sessionName); err != nil {
		sessionName = fmt.Sprintf("error: %v", err)
	}

	fmt.Printf("%s: session %q\n", deviceName, sessionName)

	var releaseFunc func()

	callback := wca.IAudioSessionEventsCallback{
		OnDisplayNameChanged: func(newDisplayName string, eventContext *ole.GUID) error {
			return onDisplayNameChanged(deviceName, newDisplayName, eventContext)
		},
		OnIconPathChanged: func(newIconPath string, eventContext *ole.GUID) error {
			return onIconPathChanged(deviceName, newIconPath, eventContext)
		},
		// https://github.com/golang/go/issues/45300
		// OnSimpleVolumeChanged: func(newVolume float32, mute bool, eventContext *ole.GUID) error {
		// 	return onSimpleVolumeChanged(deviceName, newVolume, mute, eventContext)
		// },
		// OnChannelVolumeChanged: func(channelCount int, newChannelVolumeArray []float32, changedChannel int, eventContext *ole.GUID) error {
		// 	return onChannelVolumeChanged(deviceName, channelCount, newChannelVolumeArray, changedChannel, eventContext)
		// },
		OnGroupingParamChanged: func(newGroupingParam, eventContext *ole.GUID) error {
			return onGroupingParamChanged(deviceName, newGroupingParam, eventContext)
		},
		OnStateChanged: func(newState wca.AudioSessionState) error {
			return onStateChanged(deviceName, sessionName, releaseFunc, newState)
		},
		OnSessionDisconnected: func(disconnectReason wca.AudioSessionDisconnectReason) error {
			return onSessionDisconnected(deviceName, sessionName, releaseFunc, disconnectReason)
		},
	}
	ase := wca.NewIAudioSessionEvents(callback)
	releaseFunc = func() {
		release <- CallbackRegistration{session, ase}
	}
	err := session.RegisterAudioSessionNotification(ase)
	if err != nil {
		fmt.Printf("Error registering audio session notification: %v\n", err)
	}

	return err
}


func onDisplayNameChanged(deviceName, newDisplayName string, eventContext *ole.GUID) error {
	fmt.Printf("%s: called OnDisplayNameChanged\t%q\n", deviceName, newDisplayName)

	return nil
}

func onIconPathChanged(deviceName, newIconPath string, eventContext *ole.GUID) error {
	fmt.Printf("%s: called OnIconPathChanged\t%q\n", deviceName, newIconPath)

	return nil
}

func onSimpleVolumeChanged(deviceName string, newVolume float32, mute bool, eventContext *ole.GUID) error {
	fmt.Printf("%s: called OnSimpleVolumeChanged\t%f %v\n", deviceName, newVolume, mute)

	return nil
}

func onChannelVolumeChanged(deviceName string, channelCount int, newChannelVolumeArray []float32, changedChannel int, eventContext *ole.GUID) error {
	fmt.Printf("%s: called onChannelVolumeChanged\t%d %v %d\n", deviceName, channelCount, newChannelVolumeArray, changedChannel)

	return nil
}

func onGroupingParamChanged(deviceName string, newGroupingParam, eventContext *ole.GUID) error {
	fmt.Printf("%s: called OnGroupingParamChanged\t%s\n", deviceName, newGroupingParam.String())

	return nil
}

func onStateChanged(deviceName, sessionName string, release func(), newState wca.AudioSessionState) error {
	fmt.Printf("%s: called OnStateChanged %q\t%d\n", deviceName, sessionName, newState)

	if newState == wca.AudioSessionStateExpired {
		release()
	}

	return nil
}

func onSessionDisconnected(deviceName, sessionName string, release func(), disconnectReason wca.AudioSessionDisconnectReason) error {
	fmt.Printf("%s: called OnSessionDisconnected %q\t%d\n", deviceName, sessionName, disconnectReason)
	release()

	return nil
}
*/
