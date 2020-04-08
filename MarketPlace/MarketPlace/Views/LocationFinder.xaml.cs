using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationFinder : ContentPage
    {
        public LocationFinder()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Low,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            if (location != null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Location", $"{location.Latitude} x {location.Longitude}", "OK");
                });
            }
        }

        private async void Continue(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new YourLocation());
        }

        private void OpenMainApp(object sender, EventArgs args)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}