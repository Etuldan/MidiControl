using System.Collections.Generic;
using Newtonsoft.Json;
using Fleck;

namespace MidiControl.Control
{
    class GoXLRControl : IExternalControl
    {
        private bool isConnected;
        private IWebSocketConnection socket;
        public static List<string> inputs = new List<string>(new string[] { "Mic", "Chat", "Music", "Game", "Console", "Line In", "System", "Samples" });
        public static List<string> outputs = new List<string>(new string[] { "Headphones", "Broadcast Mix", "Line Out", "Chat Mic", "Sampler"});
        private readonly Dictionary<string, MIDIFeedback> feedbackToggle = new Dictionary<string, MIDIFeedback>();

        public enum Action : int
        {
            Mute = 0,
            UnMute = 1,
            Toggle = 2
        }
        public GoXLRControl()
        {
            isConnected = false;

            var server = new WebSocketServer("ws://127.0.0.1:6805/?GOXLRApp");
            server.Start(OnClientConnecting);
        }

        private void OnClientConnecting(IWebSocketConnection socket)
        {
            var connectionInfo = socket.ConnectionInfo;

            socket.OnOpen = () =>
            {
                this.socket = socket;
                isConnected = true;
            };

            socket.OnClose = () =>
            {
                isConnected = false;
            };
        }

        private void Send(string action, string input, string output)
        {
            if (!isConnected)
                return;

            action = JsonConvert.SerializeObject(action);
            input = JsonConvert.SerializeObject(input);
            output = JsonConvert.SerializeObject(output);

            var json = $"{{\"action\":\"com.tchelicon.goxlr.routingtable\",\"event\":\"keyUp\",\"payload\":{{\"settings\":{{\"RoutingAction\":{action},\"RoutingInput\":{input},\"RoutingOutput\":{output}}}}}}}";
            socket.Send(json);
        }

        public void Mute(string input, string output, KeyBindEntry keybind)
        {
            if (!isConnected) return;

            Send("Turn Off", input, output);
            var feedback = new MIDIFeedback(keybind);
            feedback.SendOff();
        }
        public void UnMute(string input, string output, KeyBindEntry keybind)
        {
            if (!isConnected) return;
            
            Send("Turn On", input, output);
            var feedback = new MIDIFeedback(keybind);
            feedback.SendOn();
        }
        public void Toggle(string input, string output, KeyBindEntry keybind)
        {
            if (!isConnected) return;
            
            Send("Toggle", input, output);
            var feedback = new MIDIFeedback(keybind);
            if (!feedbackToggle.ContainsKey(input + "-" + output))
            {
                feedbackToggle.Add(input + "-" + output, feedback);
            }
            foreach (var entry in feedbackToggle)
            {
                if (entry.Key == input + "-" + output)
                {
                    if (entry.Value.state == true)
                    {
                        entry.Value.SendOff();
                    }
                    else
                    {
                        entry.Value.SendOn();
                    }
                }
            };
        }

        public bool IsEnabled()
        {
            return isConnected;
        }
    }
}
