using System;
using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Files
    {
        public int target_id { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("alt")]
        public string Alt { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
