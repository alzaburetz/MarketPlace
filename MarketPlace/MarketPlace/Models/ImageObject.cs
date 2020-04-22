using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class ImageObject
    {
        [JsonProperty("target_id")]
        public int ID { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
