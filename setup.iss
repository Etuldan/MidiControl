#define AppName "MIDIControl"
#define Dir "MidiControl\bin\Release\"
#define AppVersion GetVersionNumbersString(Dir + "MIDIControl.exe")

#define UseWebView2
#define UseDotNet47

#include "InnoDependencyInstaller.iss"


[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
LicenseFile=LICENSE
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
UninstallDisplayIcon={app}\MidiControl.exe
UninstallDisplayName={#AppName}
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=admin
OutputBaseFilename={#AppName} {#AppVersion} Setup
VersionInfoVersion={#AppVersion}

[Files]
Source: "{#Dir}MidiControl.exe"; DestDir: "{app}";
Source: "{#Dir}*.dll"; DestDir: "{app}";
Source: "{#Dir}runtimes\*"; DestDir: "{app}\runtimes";  Flags: recursesubdirs
Source: "{#Dir}MidiControl.exe.config"; DestDir: "{app}";
Source: "3rd-party-licenses.txt"; DestDir: "{app}";
Source: "LICENSE"; DestDir: "{app}";
Source: "MIDIControl.VisualElementsManifest.xml"; DestDir: "{app}";
Source: "filterminmax.csv"; DestDir: "{userappdata}\{#AppName}";
Source: "hotkeys.csv"; DestDir: "{userappdata}\{#AppName}";
Source: "icon.png"; DestDir: "{app}";

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\MidiControl.exe";

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "MIDIControl"; ValueData: "{app}\MIDIControl.exe"; Tasks: RunStartup; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Tobias Erichsen\loopMIDI\Ports"; ValueType: dword; ValueName: "MIDIControl Forward IN"; ValueData: 1; Tasks: loopMIDI; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Tobias Erichsen\loopMIDI\Ports"; ValueType: dword; ValueName: "MIDIControl Forward OUT"; ValueData: 1; Tasks: loopMIDI; Flags: uninsdeletevalue

[Tasks]
Name: RunStartup; Description: AutoStart : Run MIDIControl at Windows startup;
Name: loopMIDI; Description: Enable MIDI Forward : Visit loopMIDI WebPage (manual installation required) and Configure loopMIDI;

[Run]
Filename: "http://www.tobias-erichsen.de/software/loopmidi.html"; Tasks: loopMIDI; Flags: shellexec runasoriginaluser
Filename: {app}\{#AppName}.exe; Description: {cm:LaunchProgram,{#AppName}}; Flags: nowait postinstall skipifsilent
