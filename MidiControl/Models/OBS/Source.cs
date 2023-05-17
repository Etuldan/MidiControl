using Newtonsoft.Json;

namespace MidiControl.Models.OBS
{
    public class Source
    {
        [JsonProperty("inputKind")]
        public string inputKind { get; set; }

        [JsonProperty("isGroup")]
        public object isGroup { get; set; }

        [JsonProperty("sceneItemBlendMode")]
        public string sceneItemBlendMode { get; set; }

        [JsonProperty("sceneItemEnabled")]
        public bool sceneItemEnabled { get; set; }

        [JsonProperty("sceneItemId")]
        public int sceneItemId { get; set; }

        [JsonProperty("sceneItemIndex")]
        public int sceneItemIndex { get; set; }

        [JsonProperty("sceneItemLocked")]
        public bool sceneItemLocked { get; set; }

        [JsonProperty("sceneItemTransform")]
        public SceneItemTransform sceneItemTransform { get; set; }

        [JsonProperty("sourceName")]
        public string sourceName { get; set; }

        [JsonProperty("sourceType")]
        public string sourceType { get; set; }
    }
}
