package connector

import (
	"encoding/json"
	"errors"
	"os"
)

type ConnectorMapping struct {
	ConnectorName string     `json:"connector"`
	Mapping       KeyMapping `json:"mapping"`
}

type KeyMapping struct {
	Keys   []Key    `json:"keys"`
	Slider []Slider `json:"slider"`
}

type Key struct {
	Key        uint8  `json:"key"`
	ActionUp   string `json:"actionUp"`
	ActionDown string `json:"actionDown"`
	Toggle     bool   `json:"toggle"`
}

type Slider struct {
	Controller uint8  `json:"key"`
	Action     string `json:"action"`
}

type Actions int

const (
	ActionUp Actions = iota
	ActionDown
)

var errNoKeyFound = errors.New("no key found")

func LoadFromFile(filePath string) (map[string]KeyMapping, error) {
	mappings := []ConnectorMapping{}
	configFile, err := os.Open(filePath)
	defer configFile.Close()
	if err != nil {
		return nil, err
	}
	jsonParser := json.NewDecoder(configFile)
	err = jsonParser.Decode(&mappings)
	if err != nil {
		return nil, err
	}

	connectorMappings := map[string]KeyMapping{}
	for _, mapping := range mappings {
		connectorMappings[mapping.ConnectorName] = mapping.Mapping
	}

	return connectorMappings, nil
}

func (m *KeyMapping) GetInfo(key uint8, actionType Actions) (string, bool, error) {
	for _, info := range m.Keys {
		if info.Key == key {
			switch actionType {
			case ActionUp:
				return info.ActionUp, info.Toggle, nil
			case ActionDown:
				return info.ActionDown, info.Toggle, nil
			}
		}
	}
	return "", false, errNoKeyFound
}

func (m *KeyMapping) GetActionSlider(controller uint8) (string, error) {
	for _, info := range m.Slider {
		if info.Controller == controller {
			return info.Action, nil
		}
	}
	return "", errNoKeyFound
}
