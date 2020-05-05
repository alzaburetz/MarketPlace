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

using Google.AR.Core;

using Xamarin.Forms;
using MarketPlace.Services;
using MarketPlace.Droid.ARImpl;
using MarketPlace.Droid;


using Plugin.CurrentActivity;

[assembly:Dependency(typeof(ARMain))]
namespace MarketPlace.Droid.ARImpl
{
    public class ARMain : IARLauncher
    {
        Session session { get; set; }
        public void LaunchAR()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var intent = new Intent(activity, typeof(ARActivity));
            activity.StartActivity(intent);
        }
    }
}