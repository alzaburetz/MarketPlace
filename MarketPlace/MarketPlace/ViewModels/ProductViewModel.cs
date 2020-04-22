using System;
using System.Collections.Generic;
using System.Text;

using MarketPlace.Models;

namespace MarketPlace.ViewModels
{
    public class ProductViewModel:BaseViewModel
    {
        Product product;
        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        public ProductViewModel(Product prod)
        {
            Product = prod;
        }
    }
}
