using System;
using System.Collections.Generic;
using System.Text;

using MarketPlace.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MarketPlace.ViewModels
{
    public class ProductViewModel:BaseViewModel
    {
        Product product;
        public Command Favorite { get; set; }
        public Command AddToCart { get; set; }
        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        public ProductViewModel(Product product)
        {
            Product = product;
            Favorite = new Command<Product>(async (prod) =>
            {
                prod.Favorited = !prod.Favorited;
                if (prod.Favorited)
                    await Task.Run(() =>
                    {
                        Database.WriteItem<Product>("Favorite", prod);
                    });
                else
                    await Task.Run(() =>
                    {
                        Database.RemoveItem<Product>("Favorite", LiteDB.Query.Where("_id", x => x.AsInt32 == prod.ID));
                    });

                await Task.Delay(TimeSpan.FromMilliseconds(500));
                MessagingCenter.Send<Application>(Application.Current, "UpdateFavorite");
            });

            AddToCart = new Command<Product>(async (prod) =>
            {
                var cart_item = await Database.GetItemAsync<CartItem>("Cart", LiteDB.Query.Where("_id", x => x.AsInt32 == prod.ID));
                if (cart_item != null)
                {
                    cart_item.Count++;
                    Database.UpdateItem<CartItem>("Cart", null, cart_item);
                }
                else
                {
                    var item = new CartItem(prod);
                    Database.WriteItem<CartItem>("Cart", item);
                }
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                MessagingCenter.Send<Application>(Application.Current, "UpdateCart");
            });
        }
    }
}
