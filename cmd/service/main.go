package main

import (
	"fmt"
	"midicontrol/internal/connector"
	"midicontrol/internal/logger"
	"midicontrol/internal/midi"
	"midicontrol/internal/service"
)

func main() {
	name := "MidiControl"
	debug := true

	logger, err := logger.NewLogger(name, debug)
	if err != nil {
		fmt.Println("Unable to open Logger, exiting ...")
		return
	}
	defer logger.Delete()

	connectorMappings, err := connector.LoadFromFile("e:/Dev/Git/MidiControl/golang/mapping.json")
	if err != nil {
		logger.LogError("Unable to load mapping %v", err)
		return
	}
	connectors := make([]connector.Connector, 0)

	//audio, err := connector.NewAudio(connectorMappings["audio"], logger)
	//connectors = append(connectors, audio)
	//defer audio.Close()

	keyboard, err := connector.NewKeyboard(connectorMappings["keyboard"], logger)
	if err != nil {
		logger.LogError("Unable to load Keyboard %v", err)
		return
	}
	connectors = append(connectors, keyboard)

	obs, err := connector.NewObs(connectorMappings["obs"], logger)
	if err != nil {
		logger.LogError("Unable to load OBS %v", err)
		return
	}
	defer obs.Close()
	connectors = append(connectors, obs)

	midi := midi.NewMidi(logger, connectors)
	midi.Listen()
	defer midi.Stop()

	Service := service.NewService(logger, midi)
	Service.RunService(name, debug)
}
