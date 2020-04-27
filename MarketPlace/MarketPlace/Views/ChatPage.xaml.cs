using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MarketPlace.ViewModels;
using MarketPlace.Models;

namespace MarketPlace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        ChatListViewModel viewModel { get; set; }
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChatListViewModel();
            MessagingCenter.Subscribe<MainPage>(this, "LoadChatList", (s) => viewModel.LoadChat.Execute(null));
        }

        async void OpenChat(object sender, SelectionChangedEventArgs args)
        {
            try
            {
                var chat = (args.CurrentSelection[0] as ChatData);
                var reciver = chat.UID;
                await Navigation.PushAsync(new Messages(reciver, viewModel.User.uid, viewModel.User, chat.Title));
                (sender as CollectionView).SelectedItem = null;
            }
            catch
            {

            }
        }
    }
}