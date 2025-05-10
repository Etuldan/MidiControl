package tools

import (
	"encoding/json"
	"os"
)

type Config struct {
	Obs ObsConfig `json:"obs"`
}

type ObsConfig struct {
	Host     string `json:"host"`
	Port     string `json:"port"`
	Password string `json:"password"`
}

func NewConfig(filePath string) (mapping *Config, err error) {
	config := &Config{}
	conf, err := os.Open(filePath)
	if err != nil {
		return nil, err
	}
	defer conf.Close()

	jsonParser := json.NewDecoder(conf)
	err = jsonParser.Decode(config)
	if err != nil {
		return nil, err
	}

	return config, nil
}
