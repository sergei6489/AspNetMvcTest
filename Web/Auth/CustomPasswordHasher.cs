using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Web.Auth
{
    public class CustomPasswordHasher : PasswordHasher
    {
        public override string HashPassword( string password )
        {
            return base.HashPassword( password );
        }

        public override PasswordVerificationResult VerifyHashedPassword( string hashedPassword, string providedPassword )
        {
            if( hashedPassword == providedPassword )
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}
