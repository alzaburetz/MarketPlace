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

using Android.Graphics;
using Xamarin.Forms;
using MarketPlace.Controls;
using MarketPlace.Droid.Renderers;
using Xamarin.Android;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;

[assembly:ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]
namespace MarketPlace.Droid.Renderers
{
    public class CustomButtonRenderer: Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public CustomButtonRenderer(Context context):base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var gradient = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new int[]
                {
                    Xamarin.Forms.Color.FromHex("#EC4257").ToAndroid(),
                    Xamarin.Forms.Color.FromHex("#F02941").ToAndroid()
                });
                var height = Control.MinHeight;
                gradient.SetCornerRadius((float) height / 2);
                Control.Background = gradient;
            }
        }

        protected override AppCompatButton CreateNativeControl()
        {
            var button = base.CreateNativeControl();
            button.SetAllCaps(false);
            button.SetTextColor(Android.Graphics.Color.White);
            button.SetValue(Xamarin.Forms.Button.CornerRadiusProperty, 20);
            return button;
        }

    }
}