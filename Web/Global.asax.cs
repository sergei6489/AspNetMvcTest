using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core;
using Web.App_Start;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebActionConfig.Start();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            Bundles.RegisterBundles( BundleTable.Bundles );
            WebApiConfig.Register( GlobalConfiguration.Configuration );
            var rep = DependencyResolver.Current.GetService<IRepository>();
            if( rep.GetUserByLogin( "admin" ) == null )
            {
                rep.AddUser( new User() { Name = "admin", IsAdmin = true, Password = "admin", UserName = "admin" } );
                var image = File.ReadAllBytes( HttpContext.Current.Server.MapPath( "~/Content/TestImage.jpg" ) );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia E3", Price = 500 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Samsung", Price = 500 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Fly", Price = 500 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Texet", Price = 576 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Sony", Price = 543 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia 5543", Price = 543 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia 3311", Price = 524 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia 3310", Price = 532 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia 9933", Price = 554 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Nokia 5533", Price = 515 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Lenovo 3311", Price = 563 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Lenovo 3310", Price = 5321 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Lenovo 9933", Price = 544 } );
                rep.AddProduct( new Product() { Category = "Электроника", Description = "Новы телефон", Image = image, Name = "Lenovo 5533", Price = 564 } );
                rep.AddProduct( new Product() { Category = "Книга", Description = "Антиутопия", Image = image, Name = "1984", Price = 5 } );
                rep.AddProduct( new Product() { Category = "Книга", Description = "Антиутопия", Image = image, Name = "1984 переиздание", Price = 543 } );
                rep.AddProduct( new Product() { Category = "Книга", Description = "О дивный новый мир", Image = image, Name = "О дивный новый мир", Price = 521 } );
                rep.AddProduct( new Product() { Category = "Книга", Description = "451 градус по Фаренгейту", Image = image, Name = "451 градус по Фаренгейту", Price = 512 } );
                rep.Save();
            }
        }
    }
}
