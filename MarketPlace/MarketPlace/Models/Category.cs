using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Category
    {
        [JsonProperty("tid")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("parent")]
        public int Parent { get; set; }
        [JsonProperty("img_url")]
        public string Img { get; set; }
        [JsonIgnore]
        public List<Category> Subcategories { get; set; }
    }
}
