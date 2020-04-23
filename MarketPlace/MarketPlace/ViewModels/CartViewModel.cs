using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketPlace.Models;
using Xamarin.Forms;

namespace MarketPlace.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public Command LoadCart { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set;}
        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
            LoadCart = new Command(async () =>
            {
                CartItems.Clear();
                var cart = (await Database.GetAllStreamAsync<CartItem>("Cart")).GetEnumerator();
                while (cart.MoveNext())
                {
                    CartItems.Add(cart.Current);
                }
            });
        }
    }
}
