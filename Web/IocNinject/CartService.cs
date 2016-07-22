using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace Web.IocNinject
{
    public class CartService
    {
        private IRepository repository;

        public CartService( IRepository repository )
        {
            this.repository = repository;
        }

        private string sessionKey="CartService";
        public virtual Cart GetCart()
        {
            var cart = (Cart)HttpContext.Current.Session[sessionKey];
            Product prod;
            if( cart == null )
            {
                cart = new Cart();
                HttpContext.Current.Session[sessionKey] = cart;
            }
            foreach( var data in cart.Products.ToList() )
            {
                prod = repository.GetProductById(data.Id);
                if (prod == null)
                {
                    cart.Products.Remove(data);
                }
                else
                {
                    data.Price = prod.Price;
                }
            }
            return cart;
        }

    }
}