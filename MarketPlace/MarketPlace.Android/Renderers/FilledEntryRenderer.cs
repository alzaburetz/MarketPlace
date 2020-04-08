using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using MarketPlace.Droid.Renderers;
using MarketPlace.Controls;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(FilledEntry), typeof(FilledEntryRenderer))]
namespace MarketPlace.Droid.Renderers
{
    public class FilledEntryRenderer:EntryRenderer
    {
        public FilledEntryRenderer(Context context) : base(context) { }
        Color Background { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                Background = (e.NewElement as FilledEntry).Background;
                if (this.Background == null)
                {
                    Background = Color.FromHex("#F4F4F4");
                }
                Control.SetBackgroundColor(this.Background.ToAndroid());
                Control.SetPadding(40, 40, 40, 40);
            }
        }
    }
}