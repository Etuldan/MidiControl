package midi

import (
	"encoding/json"
	"os"
)

type Mapping struct {
	Buttons []ButtonsMapping `json:"buttons"`
	Sliders []SliderMapping  `json:"sliders"`
}

type Common struct {
	Key     uint8  `json:"key"`
	Channel uint8  `json:"channel"`
	Device  string `json:"device"`
}

type ButtonsMapping struct {
	ActionsUp   []Action `json:"actionsUp"`
	ActionsDown []Action `json:"actionsDown"`
	Common
}

type SliderMapping struct {
	Actions []Action `json:"action"`
	Common
}

type Action struct {
	Connector string `json:"connector"`
	Action    string `json:"action"`
}

func NewMapping(filePath string) (mapping *Mapping, err error) {
	mapping = &Mapping{}
	configFile, err := os.Open(filePath)
	if err != nil {
		return
	}
	defer configFile.Close()

	jsonParser := json.NewDecoder(configFile)
	err = jsonParser.Decode(mapping)
	if err != nil {
		return
	}

	return
}
