#define AppName "MIDIControl"
#define Dir "MidiControl\bin\Release\"
#define AppVersion GetFileVersion(Dir + "MIDIControl.exe")

[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
WizardStyle=modern
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
Source: "license.txt"; DestDir: "{app}";
Source: "MIDIControl.VisualElementsManifest.xml"; DestDir: "{app}";
Source: "filterminmax.csv"; DestDir: "{app}";
Source: "icon.png"; DestDir: "{app}";
Source: "Redist\MicrosoftEdgeWebview2Setup.exe"; DestDir: {tmp}; Flags: deleteafterinstall
Source: "Redist\ndp472-kb4054531-web.exe"; DestDir: {tmp}; Flags: deleteafterinstall

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\MidiControl.exe";

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "MIDIControl"; ValueData: "{app}\MIDIControl.exe"; Tasks: RunStartup; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Tobias Erichsen\loopMIDI\Ports"; ValueType: dword; ValueName: "MIDIControl Forward IN"; ValueData: 1; Tasks: loopMIDI; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Tobias Erichsen\loopMIDI\Ports"; ValueType: dword; ValueName: "MIDIControl Forward OUT"; ValueData: 1; Tasks: loopMIDI; Flags: uninsdeletevalue

[Tasks]
Name: RunStartup; Description: AutoStart : Run MIDIControl at Windows startup (your MIDI devices should be connected before);
Name: loopMIDI; Description: Enable MIDI Forward : Visit loopMIDI WebPage (manual installation required) and Configure loopMIDI;

[Run]
Filename: {tmp}\MicrosoftEdgeWebview2Setup.exe; Parameters: "/silent /install"; StatusMsg: "Installing Microsoft Edge Webview2 Runtime ..."
Filename: {tmp}\ndp472-kb4054531-web.exe; Parameters: "/q /norestart"; StatusMsg: "Installing Microsoft .NET Framework 4.7.2 ..."	
Filename: "http://www.tobias-erichsen.de/software/loopmidi.html"; Tasks: loopMIDI; Flags: shellexec runasoriginaluser
Filename: {app}\{#AppName}.exe; Description: {cm:LaunchProgram,{#AppName}}; Flags: nowait postinstall skipifsilent