# MidiControl
MIDIControl is an external software (Windows Only), to remote control OBS, act as Soundboard, send message in Twitch Chat, and more..., with any MIDI controller like APC (from AKAI), Launchpad (from Novation), or Maschine (from Native Instruments).

It support profiles/mapping, so you can switch from one to another, to use your MIDI Controller differently if you want to.

## Prerequisites
- obs-websocket-5.0. This is included with OBS Studio 28.  Older versions of OBS and obs-websocket are NOT supported.


## How to configure
TODO

## How to Use
1. Make sure OBS Studio is running first.
2. Start MIDIControl.
3. Select the profile you want to use, if needed.
4. Press on your MIDI keys/controls!

## How to build

[Go](https://go.dev/doc/install) 1.24.2 or later
`go env -w CGO_ENABLED=1` (more info [here](https://github.com/go101/go101/wiki/CGO-Environment-Setup))