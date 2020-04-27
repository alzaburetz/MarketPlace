using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class Message:ModelChanged
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("nid")]
        public int NId { get; set; }
        [JsonProperty("uid1")]
        public int SenderID { get; set; }
        [JsonProperty("uid2")]
        public int RecieverID { get; set; }
        [JsonProperty("cid")]
        public int ID { get; set; }
        [JsonProperty("date")]
        public long Date { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonIgnore]
        int _wasread;
        [JsonProperty("wasread")]
        public int WasRead
        {
            get => _wasread;
            set
            {
                _wasread = value;
                OnPropertyChanged("WasRead");
            }
        }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("file")]
        public string File { get; set; }
        [JsonProperty("file_preview")]
        public string Preview { get; set; }
        [JsonProperty("img_url")]
        public string Image { get; set; }
        public Message() { }
        public Message(string name, string surname, string avatar, string text)
        {
            Name = name;
            Surname = surname;
            Image = avatar;
            Text = text;
        }
    }
}
