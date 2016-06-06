using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ninject;
using Web.IocNinject;

namespace Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register( HttpConfiguration config )
        {
            config.DependencyResolver = new NinjectResolver( new StandardKernel() );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}