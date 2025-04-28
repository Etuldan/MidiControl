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

func (m *KeyMapping) GetActionUp(key uint8) (string, error) {
	for _, info := range m.Keys {
		if info.Key == key {
			return info.ActionUp, nil
		}
	}

	return "", errNoKeyFound
}

func (m *KeyMapping) GetActionDown(key uint8) (string, error) {
	for _, info := range m.Keys {
		if info.Key == key {
			return info.ActionDown, nil
		}
	}
	return "", errNoKeyFound
}

func (m *KeyMapping) GetActionSlider(controller uint8) (string, error) {
	for _, info := range m.Slider {
		if info.Controller == controller {
			return info.Action, nil
		}
	}
	return "", errNoKeyFound
}

func (m *KeyMapping) IsToggle(key uint8) (bool, error) {
	for _, info := range m.Keys {
		if info.Key == key {
			return info.Toggle, nil
		}
	}
	return false, errNoKeyFound
}
