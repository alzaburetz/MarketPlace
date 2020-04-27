using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class ChatData
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("img_url")]
        public string Image { get; set; }
        [JsonProperty("comment_body_value")]
        public string Text { get; set; }
        [JsonProperty("changed")]
        public long Timestamp { get; set; }
        [JsonProperty("has_new")]
        public int New { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("uid")]
        public int UID { get; set; }
    }

    [Serializable]
    public class Chat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("chat")]
        public List<Message> Messages { get; set; }
    }
}
