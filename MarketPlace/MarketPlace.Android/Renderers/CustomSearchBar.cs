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
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Platform.Android;

using MarketPlace.Droid.Renderers;
using MarketPlace.Controls;
using Android.Graphics;
using Android.Graphics.Drawables;

[assembly:ExportRenderer(typeof(CustomSearchBarEntry), typeof(CustomSearchBar))]
namespace MarketPlace.Droid.Renderers
{
    public class CustomSearchBar:EntryRenderer
    {
        public CustomSearchBar(Context context):base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var background = new GradientDrawable(GradientDrawable.Orientation.TopBottom,
                    new int[]
                    {
                        Xamarin.Forms.Color.FromHex("#EBEAEA").ToAndroid(),
                        Xamarin.Forms.Color.FromHex("#EBEAEA").ToAndroid()
                    });
                var height = Control.Height;
                background.SetCornerRadius(10);
                background.SetStroke(3, Android.Content.Res.ColorStateList.ValueOf(Xamarin.Forms.Color.FromHex("#CDCDCD").ToAndroid()));
                Control.SetPadding(40, 20, 40, 20);
                Control.Background = background;
            }
        }
    }
}