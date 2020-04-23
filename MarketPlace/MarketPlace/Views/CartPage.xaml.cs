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
    public partial class CartPage : ContentPage
    {
        CartViewModel viewModel { get; set; }
        public CartPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CartViewModel();
            MessagingCenter.Subscribe<MainPage>(this, "LoadCart", (s) => viewModel.LoadCart.Execute(null));
        }
    }
}