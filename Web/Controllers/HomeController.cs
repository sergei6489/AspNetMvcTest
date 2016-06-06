using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Web.IocNinject;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private IRepository repository;
        private CartService cartService;

        public HomeController( IRepository repository, CartService cartService )
        {
            this.repository = repository;
            this.cartService = cartService;
        }

        public ActionResult Index( string category )
        {
            int count;
            List<Product> products = new List<Product>();
            products = repository.GetPageProducts( 1, 9, category, out count );
            ProductListViewModel result = new ProductListViewModel();
            result.Products = products;
            result.Categories = repository.GetCategories().ToDictionary( n => n, m => false );
            result.Categories.Add( "Все", true );
            return View( result );
        }

        public bool AddToCart( int id )
        {
            var product = repository.GetProductById( id );
            if( product == null )
            {
                return false;
            }
            else
            {
                cartService.GetCart().AddToCart( product );
                return true;
            }
        }
    }
}