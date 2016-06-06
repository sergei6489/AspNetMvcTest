using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace Web.ViewModel
{
    public class CartProduct : Product
    {

        public CartProduct( Product prod )
        {
            this.Category = prod.Category;
            this.Description = prod.Description;
            this.Id = prod.Id;
            this.Image = prod.Image;
            this.Name = prod.Name;
            this.Price = prod.Price;
            this.Count = 1;
        }

        public int Count { get; set; }
    }
}