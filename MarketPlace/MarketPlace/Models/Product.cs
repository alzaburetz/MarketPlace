using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using LiteDB;

namespace MarketPlace.Models
{
    [Serializable]
    public class Product: MarketPlace.ViewModels.BaseViewModel
    {
        [LiteDB.BsonId]
        [JsonIgnore]
        public virtual int id { get => ID; set => ID = value; }
        [JsonProperty("id")]
        [BsonField("ID")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("img")]
        public List<ImageObject> Images { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonIgnore]
        public bool Favorited
        {
            get => _favorited;
            set
            {
                _favorited = value;
                OnPropertyChanged("Favorited");
            }
        }
        [JsonIgnore]
        private bool _favorited;
    }
}
