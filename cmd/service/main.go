package main

import (
	"flag"
	"fmt"
	"midicontrol/internal/logger"
	"midicontrol/internal/service"
)

const NAME string = "MidiControl"

func main() {
	debugFlag := flag.Bool("debug", false, "Run in debug mode")
	serviceFlag := flag.Bool("service", true, "Run as Service")
	mappingFile := flag.String("mapping", "C:/Users/Etuldan/source/repos/MidiControl/mapping.json", "Set the file path of the mapping configuration file")
	//configFile := flag.String("config", "e:/Dev/Git/MidiControl/mapping.json", "Set the file path of the configuration file")

	flag.Parse()

	logger, err := logger.NewLogger(NAME, *serviceFlag, *debugFlag)
	if err != nil {
		fmt.Println("Unable to open Logger, exiting ...")
		return
	}
	defer logger.Delete()

	sv := service.NewService(logger, *mappingFile)
	sv.RunService(NAME, *serviceFlag)
}
