using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Microsoft.AspNet.Identity;

namespace Web.Auth
{
    public class AuthUser : User, IUser<int>
    {
        public AuthUser( User user )
        {
            if( user != null )
            {
                this.Id = user.Id;
                this.IsAdmin = user.IsAdmin;
                this.Name = user.Name;
                this.Password = user.Password;
                this.UserName = user.UserName;
            }
        }
    }
}