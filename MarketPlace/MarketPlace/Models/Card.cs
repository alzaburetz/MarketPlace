using System;
using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Card:ModelChanged
    {
        private string mask;
        [JsonProperty("mask")]
        public string Mask
        {
            get => mask;
            set
            {
                mask = value;
                OnPropertyChanged("Mask");
            }
        }
    }
}
