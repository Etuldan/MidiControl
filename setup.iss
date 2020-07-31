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
Source: "{#Dir}CheckComboBox.dll"; DestDir: "{app}";
Source: "{#Dir}MidiControl.exe.config"; DestDir: "{app}";
Source: "{#Dir}NAudio.dll"; DestDir: "{app}"; 
Source: "{#Dir}NAudio.xml"; DestDir: "{app}"; 
Source: "{#Dir}Newtonsoft.Json.dll"; DestDir: "{app}";
Source: "{#Dir}Newtonsoft.Json.xml"; DestDir: "{app}";
Source: "{#Dir}obs-websocket-dotnet.dll"; DestDir: "{app}";
Source: "{#Dir}obs-websocket-dotnet.xml"; DestDir: "{app}";
Source: "{#Dir}websocket-sharp.dll"; DestDir: "{app}";
Source: "{#Dir}websocket-sharp.xml"; DestDir: "{app}";


[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\MidiControl.exe";

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "MIDIControl"; ValueData: "{app}\MIDIControl.exe"; Tasks: RunStartup; Flags: uninsdeletevalue

[Tasks]
Name: RunStartup; Description: Run MIDIControl at Windows startup (your MIDI device should be connected before);