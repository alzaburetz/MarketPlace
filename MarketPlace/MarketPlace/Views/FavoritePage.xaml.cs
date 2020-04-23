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
    public partial class FavoritePage : ContentPage
    {
        FavoriteViewModel viewModel { get; set; }
        public FavoritePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FavoriteViewModel();
            MessagingCenter.Subscribe<MainPage>(this, "LoadFavorite",(sender) => viewModel.LoadFavorite.Execute(null));
        }
    }
}