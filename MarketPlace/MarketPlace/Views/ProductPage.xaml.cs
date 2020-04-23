using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MarketPlace.ViewModels;
using MarketPlace.Models;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        public ProductPage(Product product):this()
        {

            BindingContext = new ProductViewModel(product);
        }
    }
}