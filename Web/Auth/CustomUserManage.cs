using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Microsoft.AspNet.Identity;

namespace Web.Auth
{
    public class CustomUserManager : UserManager<AuthUser, int>
    {
        public CustomUserManager( CustomUserStore userStore )
            : base( userStore )
        {
            this.PasswordHasher = new CustomPasswordHasher();
        }

        public static CustomUserManager Create()
        {
            return new CustomUserManager( new CustomUserStore() );
        }
    }
}