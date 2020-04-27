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
    public partial class Messages : ContentPage
    {
        MessagesViewModel viewModel { get; set; }
        public Messages(int reciever, int sender, UserInfo user, string title)
        {
            InitializeComponent();
            BindingContext = viewModel = new MessagesViewModel(sender, reciever, user, title);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadChat.Execute(null);
            Collection.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ItemsSource")
                {
                    viewModel.Messages.CollectionChanged += (newitems, olditems) =>
                    {
                        (s as CollectionView).ScrollTo(viewModel.Messages.Count);
                    };
                }
            };
        }

        private void ClearChat(object sender, EventArgs args)
        {
            Message.Text = string.Empty;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.CancellationSource.Cancel();
        }
    }
}