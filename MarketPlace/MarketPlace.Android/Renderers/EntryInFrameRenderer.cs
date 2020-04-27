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
using MarketPlace.Controls;
using MarketPlace.Droid.Renderers;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(EntryInFrame),typeof(EntryInFrameRenderer))]
namespace MarketPlace.Droid.Renderers
{
    public class EntryInFrameRenderer:EntryRenderer
    {
        public EntryInFrameRenderer(Context context): base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var element = e.NewElement as EntryInFrame;
                var background = new GradientDrawable(GradientDrawable.Orientation.BottomTop, new int[]
                {
                    element.BackgroundColor.ToAndroid(),
                    element.BackgroundColor.ToAndroid()
                });

                background.SetStroke(5, Android.Content.Res.ColorStateList.ValueOf(element.BorderColor.ToAndroid()));

                var corner = element.CornerRadius;
                background.SetCornerRadius(corner);
                Control.SetBackground(background);

                var padding = element.Padding;
                Control.SetPadding(padding, padding, padding, padding);

                Control.SetElevation(10);
            }
        }
    }
}