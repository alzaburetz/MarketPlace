using System;
using System.Collections.Generic;
using System.Text;

using LiteDB;

namespace MarketPlace.Models
{
    public class CartItem:Product
    {
        [BsonId]
        public override int id { get; set; }
        public int Count { get; set; }

        public CartItem() { }
        public CartItem(Product product)
        {
            Name = product.Name;
            Favorited = product.Favorited;
            Count = 1;
            Description = product.Description;
            Price = product.Price;
            Images = product.Images;
            id = product.ID;
        }
    }
}
