package logger

import (
	"fmt"
	"log"

	"golang.org/x/sys/windows/svc"
	"golang.org/x/sys/windows/svc/debug"
	"golang.org/x/sys/windows/svc/eventlog"
)

type Logger struct {
	elog  debug.Log
	debug bool
}

func NewLogger(name string, debugFlag bool) (*Logger, error) {
	var logger debug.Log
	serviceFlag, err := svc.IsWindowsService()
	if err == nil && serviceFlag {
		logger, err = eventlog.Open(name)
		if err != nil {
			log.Println("Error creating EventLog")
			return nil, err
		}
	} else {
		logger = debug.New(name)
	}

	return &Logger{elog: logger, debug: debugFlag}, nil
}

func (log *Logger) LogError(message string, a ...any) {
	log.elog.Error(1, fmt.Sprintf(message, a...))
}

func (log *Logger) LogWarning(message string, a ...any) {
	log.elog.Warning(1, fmt.Sprintf(message, a...))
}

func (log *Logger) LogInfo(message string, a ...any) {
	if log.debug {
		log.elog.Info(1, fmt.Sprintf(message, a...))
	}
}

func (log *Logger) Delete() {
	log.elog.Close()
}
