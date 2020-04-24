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
        public Command RemoveFromCart { get; set; }
        public Command ClearCart { get; set; }
        public ObservableCollection<CartItem> CartItems { get; set;}
        int _sum;
        public int Sum
        {
            get => _sum;
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }
        int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }
        public CartViewModel()
        {
            CartItems = new ObservableCollection<CartItem>();
            LoadCart = new Command(async () =>
            {
                CartItems.Clear();
                Sum = 0;
                Count = 0;
                var cart = (await Database.GetAllStreamAsync<CartItem>("Cart")).GetEnumerator();
                while (cart.MoveNext())
                {
                    CartItems.Add(cart.Current);
                    Sum += cart.Current.Price * cart.Current.Count;
                    Count += cart.Current.Count;
                }
            });
            ClearCart = new Command(() =>
            {
                Database.RemoveAll<CartItem>("Cart");
                CartItems.Clear();
            });
            RemoveFromCart = new Command<CartItem>((item) =>
            {
                Database.RemoveItem<CartItem>("Cart", LiteDB.Query.Where("_id", x => x.AsInt32 == item.id));
                CartItems.Remove(item);
            });
        }
    }
}
