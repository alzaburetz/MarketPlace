using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MarketPlace.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);        
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            var i = this.Children.IndexOf(this.CurrentPage);
            switch (i)
            {
                case 0: break;
                case 1: MessagingCenter.Send<MainPage>(this, "LoadFavorite");
                    break;
                case 2: MessagingCenter.Send<MainPage>(this, "LoadCart");
                    break;
            }
        }
    }
}