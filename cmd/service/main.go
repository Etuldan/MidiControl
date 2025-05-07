package main

import (
	"flag"
	"fmt"
	"midicontrol/internal/logger"
	"midicontrol/internal/service"
	"os"
)

const NAME string = "MidiControl"

func main() {
	appData, err := os.UserConfigDir()
	debugFlag := flag.Bool("debug", true, "Run in debug mode")
	mappingFile := flag.String("mapping", appData+"/MidiControl/mapping.json", "Set the file path of the mapping configuration file")
	//configFile := flag.String("config", "appData+"/MidiControl/config.json", "Set the file path of the configuration file")

	flag.Parse()

	logger, err := logger.NewLogger(NAME, *debugFlag)
	if err != nil {
		fmt.Println("Unable to open Logger, exiting ...")
		return
	}
	defer logger.Delete()

	sv := service.NewService(logger, *mappingFile)
	sv.RunService(NAME)
}
