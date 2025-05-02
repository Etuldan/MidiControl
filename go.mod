module midicontrol

go 1.24.2

require (
	github.com/andreykaipov/goobs v1.5.6
	github.com/go-ole/go-ole v1.2.6
	github.com/micmonay/keybd_event v1.1.2
	github.com/moutend/go-wca v0.3.0
	gitlab.com/gomidi/midi/v2 v2.2.19
	golang.org/x/sys v0.32.0
)

require (
	github.com/buger/jsonparser v1.1.1 // indirect
	github.com/gorilla/websocket v1.5.3 // indirect
	github.com/hashicorp/logutils v1.0.0 // indirect
	github.com/mitchellh/mapstructure v1.5.0 // indirect
	github.com/mmcloughlin/profile v0.1.1 // indirect
	github.com/nu7hatch/gouuid v0.0.0-20131221200532-179d4d0c4d8d // indirect
)

replace github.com/moutend/go-wca => ./go-wca
