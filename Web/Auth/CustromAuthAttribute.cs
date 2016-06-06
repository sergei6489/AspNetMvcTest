using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Web.Auth
{
    public class CustromAuthAttribute : AuthorizeAttribute
    {
        private CustomUserManager userManager
        {
            get
            {
                return System.Web.HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>();
            }
        }

        public override void OnAuthorization( AuthorizationContext filterContext )
        {
            var user = filterContext.HttpContext.User;
            bool isError = false;
            if( user.Identity.IsAuthenticated )
            {
                var data = userManager.FindByName( user.Identity.Name );
                if( data == null || !data.IsAdmin )
                {
                    isError = true;
                }
            }
            else
            {
                isError = true;
            }
            if( isError )
            {
                filterContext.Result = new RedirectToRouteResult( new RouteValueDictionary( new
                {
                    action = "Index",
                    controller = "Home",
                    returnUrl = filterContext.HttpContext.Request.Url
                } ) );
            }
        }
    }
}