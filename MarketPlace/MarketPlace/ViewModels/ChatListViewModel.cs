using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;
using System.Threading.Tasks;

namespace MarketPlace.ViewModels
{
    public class ChatListViewModel:BaseViewModel
    {
        public Command LoadChat { get; set; }
        public ObservableCollection<ChatData> ChatList { get; set; }
        int UserID;
        public ChatListViewModel()
        {
            ChatList = new ObservableCollection<ChatData>();
            LoadChat = new Command(() =>
            {
                IsBusy = true;
                Task.Run(async () =>
                {
                    ChatList.Clear();
                    var chat_list = await Http.GetRequest<List<ChatData>>("chat?action=list", true);
                    if (chat_list != null)
                    {
                        foreach (var element in chat_list)
                        {
                            Device.BeginInvokeOnMainThread(() => ChatList.Add(element));
                        }
                    }
                    IsBusy = false;
                });
            });
            MessagingCenter.Subscribe<MainPageViewModel, int>(this, "SetID", (s, id) => UserID = id);
        }
    }
}
