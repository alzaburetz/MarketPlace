using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MarketPlace.ViewModels;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        AuthorizationViewModel viewModel { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AuthorizationViewModel();
        }

        protected async void Continue(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new LocationFinder());
        }
    }
}