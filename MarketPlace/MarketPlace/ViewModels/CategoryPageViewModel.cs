using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using MarketPlace.Models;
using Xamarin.Forms;

using System.Threading.Tasks;

namespace MarketPlace.ViewModels
{
    public class CategoryPageViewModel:BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public List<Category> Cats { get; set; }
        public Command LoadCategoriesCommand { get; set; }
        public Command OpenCategory { get; set; }
        public CategoryPageViewModel()
        {
            Categories = new ObservableCollection<Category>();
            LoadCategoriesCommand = new Command(() =>
            {
                Task.Run(async () =>
                {
                    IsBusy = true;
                    Categories.Clear();
                    Cats = await Http.GetRequest<List<Category>>("getdata?action=getcat", false);
                    if (Cats != null)
                    {
                        foreach (var category in Cats)
                        {
                            var cat = category;
                            cat.Subcategories = Cats.FindAll(x => x.Parent == category.ID);
                            if (cat.Parent == 0)
                            Device.BeginInvokeOnMainThread(() => Categories.Add(cat));
                        }
                    }
                    IsBusy = false;
                });
            });

            OpenCategory = new Command<int>((id) =>
            {

            });
        }
    }
}
