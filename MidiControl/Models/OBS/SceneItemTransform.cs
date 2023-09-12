using Newtonsoft.Json;

namespace MidiControl.Models.OBS
{
    public class SceneItemTransform
    {
        [JsonProperty("alignment")]
        public int Alignment { get; set; }

        [JsonProperty("boundsAlignment")]
        public int BoundsAlignment { get; set; }

        [JsonProperty("boundsHeight")]
        public double BoundsHeight { get; set; }

        [JsonProperty("boundsType")]
        public string BoundsType { get; set; }

        [JsonProperty("boundsWidth")]
        public double BoundsWidth { get; set; }

        [JsonProperty("cropBottom")]
        public int CropBottom { get; set; }

        [JsonProperty("cropLeft")]
        public int CropLeft { get; set; }

        [JsonProperty("cropRight")]
        public int CropRight { get; set; }

        [JsonProperty("cropTop")]
        public int CropTop { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("positionX")]
        public double PositionX { get; set; }

        [JsonProperty("positionY")]
        public double PositionY { get; set; }

        [JsonProperty("rotation")]
        public double Rotation { get; set; }

        [JsonProperty("scaleX")]
        public double ScaleX { get; set; }

        [JsonProperty("scaleY")]
        public double ScaleY { get; set; }

        [JsonProperty("sourceHeight")]
        public double SourceHeight { get; set; }

        [JsonProperty("sourceWidth")]
        public double SourceWidth { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }
    }
}
