using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;

using System.Threading.Tasks;

namespace MarketPlace.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public Command LoadUser { get; set; }
        public Command CountMessages { get; set; }
        int _messageCount;
        public int MessageCount
        {
            get => _messageCount;
            set
            {
                _messageCount = value;
                OnPropertyChanged("MessageCount");
            }
        }
        public Command CountFavorite { get; set; }
        int _favoriteCount;
        public int FavoriteCount
        {
            get => _favoriteCount;
            set
            {
                _favoriteCount = value;
                OnPropertyChanged("FavoriteCount");
            }
        }
        public Command CountCart { get; set; }
        int _cartCount;
        public int CartCount
        {
            get => _cartCount;
            set
            {
                _cartCount = value;
                OnPropertyChanged("CartCount");
            }
        }
        public MainPageViewModel()
        {
            LoadUser = new Command(async () =>
            {
                var user = await Http.GetRequest<UserData2>("user", true);
                if (user != null)
                {
                    MessagingCenter.Send<MainPageViewModel, UserInfo>(this, "SetID", user.user);
                }
            });

            CountMessages = new Command(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    await Task.Run(async () =>
                    {
                        MessageCount = await Http.GetRequest<int>("chat?action=count_newmessage", true);
                    });
                }
            });

            CountFavorite = new Command(() =>
            {
                FavoriteCount = Database.GetRecordCount<Product>("Favorite");
            });

            CountCart = new Command(() =>
            {
                CartCount = Database.GetRecordCount<CartItem>("Cart");
            });

            MessagingCenter.Subscribe<Application>(this, "UpdateCart", (sender) => CountCart.Execute(null));
            MessagingCenter.Subscribe<Application>(this, "UpdateFavorite", (sender) => CountFavorite.Execute(null));
        }
    }
}
