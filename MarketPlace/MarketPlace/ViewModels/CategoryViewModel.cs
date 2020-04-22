using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Xamarin.Forms;
using MarketPlace.Models;

using System.Threading.Tasks;

namespace MarketPlace.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        int ID { get; set; }
        public Command Loadproducts { get; set; }
        public CategoryViewModel(int id)
        {
            ID = id;
            Products = new ObservableCollection<Product>();
            Loadproducts = new Command(() =>
             {

                 Task.Run(async () =>
                 {
                     IsBusy = true;
                     var response = await Http.GetRequest<List<Product>>("getdata?tid=7", false);
                     if (response != null)
                     {
                         foreach (var product in response)
                         {
                             Device.BeginInvokeOnMainThread(() => Products.Add(product));
                         }
                     }
                    IsBusy = false;
                 });
             });
        }
    }
}
