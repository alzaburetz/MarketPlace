using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace MarketPlace.Controls
{
    public class EntryInFrame:Entry
    {
        public Color BorderColor { get; set; }
        public int Padding { get; set; }
        public int CornerRadius { get; set; }
        public EntryInFrame()
        {
            if (BorderColor == null)
            {
                BorderColor = Color.FromHex("#A9A8A8");
            }    
        }
    }
}
