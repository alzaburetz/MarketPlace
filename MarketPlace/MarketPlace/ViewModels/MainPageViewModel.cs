using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;

namespace MarketPlace.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public Command LoadUser { get; set; }
        public MainPageViewModel()
        {
            LoadUser = new Command(async () =>
            {
                var user = await Http.GetRequest<UserData2>("user", true);
                if (user != null)
                {
                    MessagingCenter.Send<MainPageViewModel, int>(this, "SetID", user.user.uid);
                }
            });
        }
    }
}
