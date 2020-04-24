using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MarketPlace.ViewModels
{
    public class AuthorizationViewModel:BaseViewModel
    {
        public User User { get; set; }
        public Command SendPhone { get; set; }
        public Command SendSMS { get; set; }
        bool _phonesent;
        public bool PhoneSent
        {
            get => _phonesent;
            set
            {
                _phonesent = value;
                OnPropertyChanged("PhoneSent");
            }
        }
        bool _smssent;
        public bool SmsSent
        {
            get => _smssent;
            set
            {
                _smssent = value;
                OnPropertyChanged("SmsSent");
            }
        }

        public AuthorizationViewModel()
        {
            User = new User();
            SendPhone = new Command<string>(async (phone) =>
            {
                IsBusy = true;
                if (!string.IsNullOrEmpty(phone) || phone?.Length > 15)
                {
                    User.phone = Regex.Replace(phone.Replace("+7", "8"), @"\D", "");
                    var resp = await Http.PostRequest<User>("user/register", User, false);
                    if (resp.Contains("success"))
                    {
                        PhoneSent = true;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(null, "Введите корректный номер телефона", "ОК");
                }
                IsBusy = false;
            });

            SendSMS = new Command<string>(async (sms) =>
            {
                IsBusy = true;
                if (!string.IsNullOrEmpty(sms) || sms.Length > 3)
                {
                    User.code = sms;
                    var resp = await Http.PostRequest<UserData, User>("user/login", User, false);
                    if (resp != null)
                    {
                        if (!string.IsNullOrEmpty(resp.access_token))
                        {
                            if (!Application.Current.Properties.ContainsKey("Token"))
                            {
                                Application.Current.Properties.Add("Token", resp.access_token);
                            }
                            else
                            {
                                Application.Current.Properties["Token"] = resp.access_token;
                            }
                            await Application.Current.SavePropertiesAsync();
                            Http.Token = resp.access_token;
                        }
                        SmsSent = true;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Ошибка", "Введен неверный код", "ОК");
                    }
                }
                IsBusy = false;
            });
        }
    }
}
