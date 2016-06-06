using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Web.Auth;
using Web.IocNinject;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected override void OnResultExecuting( ResultExecutingContext filterContext )
        {
            var userName = System.Web.HttpContext.Current.User.Identity.Name;
            ViewBag.IsAdmin = false;
            if( !String.IsNullOrEmpty( userName ) )
            {
                var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>().FindByName( userName );
                if( user != null )
                {
                    ViewBag.IsAdmin = user.IsAdmin;
                }
                else
                {
                    AuthenticationManager.SignOut( DefaultAuthenticationTypes.ExternalCookie );
                }
            }
            ViewBag.CountProducts = DependencyResolver.Current.GetService<CartService>().GetCart().Products.Sum(n=>n.Count);

            base.OnResultExecuting( filterContext );
        }
    }
}