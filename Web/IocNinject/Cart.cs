using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Web.ViewModel;

namespace Web.IocNinject
{
    public class Cart
    {
        private object _lockObject = new object();
        public List<CartProduct> Products { get; set; }

        public Cart()
        {
            Products = new List<CartProduct>();
        }

        public void AddToCart( Product product )
        {
            lock( _lockObject )
            {
                var cartProduct = Products.FirstOrDefault( n => n.Id == product.Id );
                if( cartProduct == null )
                {
                    cartProduct = new CartProduct( product );
                    Products.Add( cartProduct );
                }
                else
                {
                    cartProduct.Count++;
                }
            }
        }

        public void setProductCount( int id, int count )
        {
            lock( _lockObject )
            {
                var cartProduct = Products.FirstOrDefault( n => n.Id == id );
                if( cartProduct == null )
                {
                    throw new Exception( "Корзина была изменена" );
                }
                else
                {
                    if( count <= 0 )
                    {
                        Products.Remove( cartProduct );
                    }
                    else
                    {
                        cartProduct.Count = count;
                    }
                }
            }
        }

    }
}