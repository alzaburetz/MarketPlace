using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;

using System.Threading.Tasks;
using System.Linq;

namespace MarketPlace.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        int ID { get; set; }
        public Command Loadproducts { get; set; }
        
        public Command Favorite { get; set; }
        public CategoryViewModel(int id)
        {
            ID = id;
            Products = new ObservableCollection<Product>();
            Favorite = new Command<Product>((prod) =>
            {
                prod.Favorited = !prod.Favorited;
                if (prod.Favorited)
                    Task.Run(() =>
                    {
                        Database.WriteItem<Product>("Favorite", prod);
                    });
                else
                    Task.Run(() =>
                    {
                        Database.RemoveItem<Product>("Favorite", LiteDB.Query.Where("_id", x => x.AsInt32 == prod.ID));
                    });
            });
            Loadproducts = new Command(() =>
             {

                 Task.Run(async () =>
                 {
                     IsBusy = true;
                     var response = await Http.GetRequest<List<Product>>("getdata?tid=7", false);
                     if (response != null)
                     {
                         foreach (var product in response)
                         {
                             var prod = await Database.GetItemAsync<Product>("Favorite", LiteDB.Query.Where("_id", x => x.AsInt32 == product.ID));
                             if (prod != null)
                             {
                                 product.Favorited = true;
                             }
                             Device.BeginInvokeOnMainThread(() => Products.Add(product));
                         }
                     }
                    IsBusy = false;
                 });
             });
            MessagingCenter.Subscribe<FavoriteViewModel, Product>(this, "UnsetFavorite", (sender, product) =>
            {
                Products.Where(x => x.ID == product.ID).FirstOrDefault().Favorited = false;
            });
        }
    }
}
