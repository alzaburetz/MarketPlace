using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarketPlace.Views.Overlays
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerOverlay : ContentView
    {
        public BarcodeScannerOverlay()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}