using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

using Newtonsoft.Json;

namespace MarketPlace.Models
{
    [Serializable]
    public class UserData
    {
        public string access_token;
        public UserInfo user;
    }

    [Serializable]
    public class UserData2
    {
        public UserInfo user { get; set; }
    }

    [Serializable]
    public class UserInfo: INotifyPropertyChanged
    {
        private string _phone;
        [JsonProperty("phone")]
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public int uid { get; set; }
        private string surname;
        [JsonProperty("surname")]
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string age;
        public string lang;
        public string push_token;
        public float lat;
        public float lon;
        public List<Files> img;
        private string status;
        [JsonProperty("status")]
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public bool firstTime;
        private List<Card> cards;
        [JsonProperty("cards")]
        public List<Card> Cards
        {
            get => cards;
            set
            {
                cards = value;
                OnPropertyChanged("Cards");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [JsonProperty("avatar_image")]
        public string Avatar { get; set; }
    }
}
