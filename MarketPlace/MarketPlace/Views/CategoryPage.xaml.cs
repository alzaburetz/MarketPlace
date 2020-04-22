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
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel viewModel { get; set; }
        public CategoryPage(int id)
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryViewModel(id);
            viewModel.Loadproducts.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void GoToProduct(object sender, EventArgs args)
        {
            
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var product = e.CurrentSelection[0] as MarketPlace.Models.Product;
                await Navigation.PushAsync(new ProductPage(product));
                (sender as CollectionView).SelectedItem = null;
            }
            catch (Exception ex)
            {

            }
        }
    }
}