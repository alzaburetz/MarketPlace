using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin;
using Xamarin.Forms;

using Com.Facetec.Zoom.Sdk;
using Google.AR.Core;

namespace MarketPlace.Droid
{
    [Activity(Label = "MarketPlace", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);


            Forms.SetFlags("SwipeView_Experimental");
            Forms.SetFlags("CarouselView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
            ZoomSDK.Initialize(this, "lE4uZ5mutuGfGlKMfrUUmcWlp79jtLM8OUhW", new ZoomInitializeCallback(this));
        }

        private class ZoomInitializeCallback : ZoomSDK.InitializeCallback
        {
            private MainActivity activity;

            public ZoomInitializeCallback(MainActivity activity)
            {
                this.activity = activity;
            }

            public override void OnCompletion(bool success)
            {
                activity.RunOnUiThread(delegate {

                    if (!success)
                    {
                        String statusStr = ZoomSDK.GetStatus(activity).ToString();
                        String alertMessage = "Initialization failed. " + statusStr;
                        activity.ShowZoomAlert("Warning", alertMessage);
                    }
                });
            }
        }

        public void ShowZoomAlert(string title, string message)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetCancelable(true);
            alert.SetNeutralButton("OK", (senderAlert, arg) => { });
            alert.Create().Show();
        }
    }


   
}