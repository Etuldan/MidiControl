using Newtonsoft.Json;

namespace MidiControl.Models.OBS
{
    public class Source
    {
        [JsonProperty("inputKind")]
        public string InputKind { get; set; }

        [JsonProperty("isGroup")]
        public object IsGroup { get; set; }

        [JsonProperty("sceneItemBlendMode")]
        public string SceneItemBlendMode { get; set; }

        [JsonProperty("sceneItemEnabled")]
        public bool SceneItemEnabled { get; set; }

        [JsonProperty("sceneItemId")]
        public int SceneItemId { get; set; }

        [JsonProperty("sceneItemIndex")]
        public int SceneItemIndex { get; set; }

        [JsonProperty("sceneItemLocked")]
        public bool SceneItemLocked { get; set; }

        [JsonProperty("sceneItemTransform")]
        public SceneItemTransform SceneItemTransform { get; set; }

        [JsonProperty("sourceName")]
        public string SourceName { get; set; }

        [JsonProperty("sourceType")]
        public string SourceType { get; set; }
    }
}
