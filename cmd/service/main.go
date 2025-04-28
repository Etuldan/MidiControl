package main

import (
	"flag"
	"fmt"
	"midicontrol/internal/connector"
	"midicontrol/internal/logger"
	"midicontrol/internal/midi"
	"midicontrol/internal/service"
)

func main() {
	name := "MidiControl"

	debugFlag := flag.Bool("debug", false, "Run in debug mode")
	serviceFlag := flag.Bool("service", true, "Run as Service")
	mappingFile := flag.String("mapping", "e:/Dev/Git/MidiControl/mapping.json", "Set the file path of the mapping configuration file")
	//configFile := flag.String("config", "e:/Dev/Git/MidiControl/mapping.json", "Set the file path of the configuration file")

	flag.Parse()

	logger, err := logger.NewLogger(name, *serviceFlag, *debugFlag)
	if err != nil {
		fmt.Println("Unable to open Logger, exiting ...")
		return
	}
	defer logger.Delete()

	connectorMappings, err := connector.LoadFromFile(*mappingFile)
	if err != nil {
		logger.LogError("Unable to load mapping %v", err)
		return
	}
	connectors := make([]connector.Connector, 0)

	//audio, err := connector.NewAudio(connectorMappings["audio"], logger)
	//if err != nil {
	//	logger.LogError("Unable to load Audio %v", err)
	//} else {
	//	connectors = append(connectors, audio)
	//	defer audio.Close()
	//}

	keyboard, err := connector.NewKeyboard(connectorMappings["keyboard"], logger)
	if err != nil {
		logger.LogError("Unable to load Keyboard %v", err)
	} else {
		connectors = append(connectors, keyboard)
	}

	obs, err := connector.NewObs(connectorMappings["obs"], logger)
	if err != nil {
		logger.LogError("Unable to load OBS %v", err)
	} else {
		defer obs.Close()
		connectors = append(connectors, obs)
	}

	midi := midi.NewMidi(logger, connectors)

	midi.Listen()
	defer midi.Stop()

	Service := service.NewService(logger, midi)
	Service.RunService(name, *serviceFlag)
}
