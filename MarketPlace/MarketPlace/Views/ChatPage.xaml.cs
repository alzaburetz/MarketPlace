using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MarketPlace.ViewModels;

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
    }
}