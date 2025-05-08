# MidiControl
MIDIControl is an external software (Windows Only), to remote control OBS, act as Soundboard, send message in Twitch Chat, and more..., with any MIDI controller like APC (from AKAI), Launchpad (from Novation), or Maschine (from Native Instruments).

It support profiles/mapping, so you can switch from one to another, to use your MIDI Controller differently if you want to.

## Prerequisites
- obs-websocket-5.0. This is included with OBS Studio 28.  Older versions of OBS and obs-websocket are NOT supported.


## How to configure
1. Create config file:
TODO

2. Create mapping file:
- For commmand-line: `%AppData%\MidiControl\mapping.json`
- For service: `C:\Windows\System32\config\systemprofile\AppData\Roaming\MidiControl\mapping.json`

Example:
```json
{
    "buttons": [
        {
            "key": 30,
            "device": "loopMIDI Port 0",
            "channel": 0,
            "actionsUp": 
            [
                {
                    "connector":"keyboard",
                    "command": "press",
                    "parameters": "30"
                    
                },
                {
                    "connector":"keyboard",
                    "command": "press",
                    "parameters": "31"
                }
            ]
        },
        {
            "key": 36, 
            "device": "loopMIDI Port 0",
            "channel": 0,
            "actionsDown": 
            [ 
                {
                    "connector":"midicontrol",
                    "command": "mapping",
                    "parameters": "C:/mapping.json"
                },
                {
                    "connector":"midicontrol",
                    "command": "sleep",
                    "parameters": "1"
                },
                {
                    "connector":"midicontrol",
                    "command": "exec",
                    "parameters": "calc.exe"
                },
                {
                    "connector":"keyboard",
                    "command": "press",
                    "parameters": "33"
                }
            ]
        },
        {
            "key": 48, 
            "device": "loopMIDI Port 0",
            "channel": 0,
            "actionsDown": 
            [ 
                {
                    "connector":"audio",
                    "command": "mute",
                    "parameters": ""
                }
            ]
        }
    ],
    "sliders": [{
        "key": 1, 
        "device": "loopMIDI Port 0",
        "channel": 0,
        "action": 
        [ 
            {
                "connector":"audio",
                "command": "volume",
                "parameters": "Casque pour téléphone (G435 Wireless Gaming Headset)"
            }
        ]
    }]
}
```

## How to Use
1. Make sure OBS Studio is running first.
2. Start MIDIControl.
3. Select the profile you want to use, if needed.
4. Press on your MIDI keys/controls!

## How to build

[Go](https://go.dev/doc/install) 1.24.2 or later
`go env -w CGO_ENABLED=1` (more info [here](https://github.com/go101/go101/wiki/CGO-Environment-Setup))