using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarketPlace.Services;
using MarketPlace.Views;

namespace MarketPlace
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<Services.RequestService>();
            DependencyService.Register<DataBaseService>();
            DependencyService.Register<IARLauncher>();
            try
            {
                var token = Application.Current.Properties["Token"];
                MainPage = new MainPage();
            }
            catch
            {
                MainPage = new StartPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
