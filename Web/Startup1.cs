using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Web.Auth;

[assembly: OwinStartup( typeof( Web.Startup1 ) )]
namespace Web
{
    public class Startup1
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration( IAppBuilder app )
        {
            app.CreatePerOwinContext( CustomUserManager.Create );
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            //This will used the HTTP header: "Authorization"      Value: "Bearer 1234123412341234asdfasdfasdfasdf"
            app.UseOAuthBearerAuthentication( OAuthBearerOptions );
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication( new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString( "/Account/Login" )
            } );
            app.UseTwoFactorSignInCookie( DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes( 5 ) );
        }
    }
}