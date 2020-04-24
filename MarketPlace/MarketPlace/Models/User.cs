using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Models
{
    [Serializable]
    public class User
    {
        public string phone;
        public string code;

        public User(string phone = "", string code = "")
        {
            this.phone = phone;
            this.code = code;
        }
    }
}
