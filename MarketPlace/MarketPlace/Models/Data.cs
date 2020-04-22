using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Data
    {
        [JsonProperty("cats")]
        public List<Category> Categories { get; set; }
    }
}
