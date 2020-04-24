using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MarketPlace.Models;

namespace MarketPlace.ViewModels
{
    public class UserViewModel:BaseViewModel
    {
        public Command LoadUser { get; set; }
        public Command Updateuser { get; set; }
        public UserData User { get; set; }
        public UserViewModel()
        {
            LoadUser = new Command(() =>
            {
                Task.Run(async () =>
                {
                    var resp = await Http.GetRequest<UserData>("user", true);
                    if (resp != null)
                    {
                        Device.BeginInvokeOnMainThread(() => User = resp);
                    }
                });
            });
            Updateuser = new Command<UserInfo>((user) =>
            {
                Task.Run(async () =>
                {
                    await Http.PostRequest<UserInfo>("user/update", user, true);
                });
            });
        }
    }
}
