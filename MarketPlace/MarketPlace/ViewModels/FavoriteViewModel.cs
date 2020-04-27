using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using MarketPlace.Models;
using System.Threading.Tasks;

using System.Linq;

namespace MarketPlace.ViewModels
{
    public class FavoriteViewModel:BaseViewModel
    {
        public ObservableCollection<Product> FavoriteProducts { get; set; }
        public Command LoadFavorite { get; set; }
        public Command RemoveFromFavorite { get; set; }
        public Command CountFavorite { get; set; }
        public int FavoriteCount { get; set; }
        public FavoriteViewModel()
        {
            FavoriteProducts = new ObservableCollection<Product>();
            LoadFavorite = new Command(() =>
            {
                IsBusy = true;
                Task.Run(async () =>
                {
                    FavoriteProducts.Clear();
                    var favorite = (await Database.GetAllStreamAsync<Product>("Favorite")).GetEnumerator();
                    while (favorite.MoveNext())
                    {
                        Device.BeginInvokeOnMainThread(() => FavoriteProducts.Add(favorite.Current));
                    }
                    IsBusy = false;
                });
                CountFavorite.Execute(null);
            });

            RemoveFromFavorite = new Command<Product>((product) =>
            {
                FavoriteProducts.Remove(product);
                Task.Run(() =>
                {
                    Database.RemoveItem<Product>("Favorite", LiteDB.Query.Where("_id", x => x.AsInt32 == product.ID));
                    MessagingCenter.Send<FavoriteViewModel, Product>(this, "UnsetFavorite", product);
                    MessagingCenter.Send<Application>(Application.Current, "UpdateFavorite");
                });
            });

            CountFavorite = new Command(() =>
            {
                FavoriteCount = Database.GetRecordCount<Product>("Favorite");
            });
        }
    }
}
