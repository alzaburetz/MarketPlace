using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourLocation : ContentPage
    {
        public YourLocation()
        {
            InitializeComponent();
        }

        private void OpenMainApp(object sender, EventArgs args)
        {
            Application.Current.MainPage = new MainPage();
        }

        private void FocusField(object sende, EventArgs args)
        {
            Town.Focus();
        }
    }
}