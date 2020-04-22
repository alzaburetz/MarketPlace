using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Product
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("img")]
        public List<ImageObject> Images { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
