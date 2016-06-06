using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Web.Auth;

namespace Web.Controllers
{
    public class ProductController : BaseController
    {
        private IRepository repository;

        public ProductController( IRepository repository )
        {
            this.repository = repository;
        }

        public ActionResult GetProducts( int PageNumber, int PageItems, string category )
        {
            int count;
            List<Product> products = new List<Product>();
            category = category == "Все" ? null : category;
            products = repository.GetPageProducts( PageNumber, PageItems, category, out count );
            return PartialView( "_ProductPage", products );
        }

        public ActionResult FilterByCategory( string category )
        {
            int count;
            category = category == "Все" ? null : category;
            var products = repository.GetPageProducts( 1, 9, category, out count );
            return PartialView( "_ProductPage", products );
        }

        public ActionResult Detail( int id )
        {
            var data = repository.GetProductById( id );
            return View( data );
        }

        [HttpGet]
        [CustromAuthAttribute]
        public ActionResult Edit( int id )
        {
            var product = repository.GetProductById( id );
            ViewBag.IsNew = false;
            return View( "Create", product );
        }

        [HttpGet]
        [CustromAuthAttribute]
        public ActionResult Create()
        {
            var product = new Product();
            ViewBag.IsNew = true;
            return View( product );
        }

        [HttpPost]
        [CustromAuthAttribute]
        public ActionResult Create( Product product, HttpPostedFileBase uploadimage, bool isNew )
        {
            if( isNew && (uploadimage == null || uploadimage.ContentLength == 0) )
            {
                ModelState.AddModelError( "Image", "Выберите изображение товара" );
            }
            if( ModelState.IsValid )
            {
                if( uploadimage != null &&  uploadimage.ContentLength > 0 )
                {
                    using( var reader = new BinaryReader( uploadimage.InputStream ) )
                    {
                        product.Image = reader.ReadBytes( uploadimage.ContentLength );
                    }
                }

                if( isNew )
                {
                    repository.AddProduct( product );
                }
                else
                {
                    repository.EditProduct( product );
                }
                repository.Save();
                return RedirectToAction( "Index", "Home" );
            }
            else
            {
                ViewBag.IsNew = isNew;
                return View( "Create", product );
            }
        }

        [CustromAuthAttribute]
        public int Delete( int id )
        {
            this.repository.RemoveProduct( id );
            repository.Save();
            return id;
        }
    }
}