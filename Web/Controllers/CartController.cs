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
    public class CartController : BaseController
    {
        private IRepository repository;
        private CartService service;
        public CartController( IRepository repository, CartService service )
        {
            this.repository = repository;
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Remove( int productId )
        {
            service.GetCart().setProductCount( productId, 0 );
            return Json( true );
        }

        [HttpPost]
        public ActionResult SetProductCountCart( int id, int count )
        {
            service.GetCart().setProductCount( id, count );
            return Json( true );
        }

        [HttpPost]
        public ActionResult GetCart()
        {
            return Json( service.GetCart().Products );
        }
    }
}