using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing.Mobile;
using MarketPlace.Views.Overlays;
using MarketPlace.ViewModels;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogPage : ContentPage
    {
        CategoryPageViewModel viewModel { get; set; }
        public CatalogPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCategoriesCommand.Execute(null);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StackPage());
        }

        private async void OpenScanner(object sender, EventArgs e)
        {
            var scanner = new ZXing.Net.Mobile.Forms.ZXingScannerPage(
                new MobileBarcodeScanningOptions() { },
                new BarcodeScannerOverlay());
            
            scanner.OnScanResult += (result) =>
            {
                DisplayAlert(null, result.Text, "OK");
            };

            await Navigation.PushModalAsync(scanner);
        }

        private async void GoToCategory(object sender, EventArgs e)
        {
            var id = viewModel.Cats.Find(x => x.Name == (sender as Label).Text).ID;
            await Navigation.PushAsync(new CategoryPage(id));
        }
    }
}