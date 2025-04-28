package logger

import (
	"fmt"
	"log"

	"golang.org/x/sys/windows/svc/debug"
	"golang.org/x/sys/windows/svc/eventlog"
)

type Logger struct {
	elog debug.Log
	d    bool
}

func NewLogger(name string, serviceFlag bool, debugFlag bool) (*Logger, error) {
	var logger debug.Log
	var err error
	if serviceFlag {
		logger, err = eventlog.Open(name)
		if err != nil {
			log.Println("Error creating EventLog")
			return nil, err
		}
	} else {
		logger = debug.New(name)
	}
	return &Logger{elog: logger, d: debugFlag}, nil
}

func (log *Logger) LogError(message string, a ...any) {
	log.elog.Error(1, fmt.Sprintf(message, a...))
}

func (log *Logger) LogWarning(message string, a ...any) {
	log.elog.Warning(1, fmt.Sprintf(message, a...))
}

func (log *Logger) LogInfo(message string, a ...any) {
	if log.d {
		log.elog.Info(1, fmt.Sprintf(message, a...))
	}
}

func (log *Logger) Delete() {
	log.elog.Close()
}
