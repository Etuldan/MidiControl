using Newtonsoft.Json;

namespace MidiControl.Models.OBS
{
    public class SceneItemTransform
    {
        [JsonProperty("alignment")]
        public int alignment { get; set; }

        [JsonProperty("boundsAlignment")]
        public int boundsAlignment { get; set; }

        [JsonProperty("boundsHeight")]
        public double boundsHeight { get; set; }

        [JsonProperty("boundsType")]
        public string boundsType { get; set; }

        [JsonProperty("boundsWidth")]
        public double boundsWidth { get; set; }

        [JsonProperty("cropBottom")]
        public int cropBottom { get; set; }

        [JsonProperty("cropLeft")]
        public int cropLeft { get; set; }

        [JsonProperty("cropRight")]
        public int cropRight { get; set; }

        [JsonProperty("cropTop")]
        public int cropTop { get; set; }

        [JsonProperty("height")]
        public double height { get; set; }

        [JsonProperty("positionX")]
        public double positionX { get; set; }

        [JsonProperty("positionY")]
        public double positionY { get; set; }

        [JsonProperty("rotation")]
        public double rotation { get; set; }

        [JsonProperty("scaleX")]
        public double scaleX { get; set; }

        [JsonProperty("scaleY")]
        public double scaleY { get; set; }

        [JsonProperty("sourceHeight")]
        public double sourceHeight { get; set; }

        [JsonProperty("sourceWidth")]
        public double sourceWidth { get; set; }

        [JsonProperty("width")]
        public double width { get; set; }
    }
}
