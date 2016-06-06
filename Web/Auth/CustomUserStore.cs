using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core;
using Microsoft.AspNet.Identity;

namespace Web.Auth
{
    public class CustomUserStore : IUserStore<AuthUser, int>, IUserPasswordStore<AuthUser, int>
    {
        public IRepository repository = DependencyResolver.Current.GetService<IRepository>();
        public System.Threading.Tasks.Task CreateAsync( AuthUser user )
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync( AuthUser user )
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<AuthUser> FindByIdAsync( int userId )
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<AuthUser> FindByNameAsync( string userName )
        {
           return Task.Run( () =>{
               var user = repository.GetUserByLogin( userName );
               if( user == null )
               {
                   return null;
               }
               else
               {
                   return new AuthUser( user );
               }
           } );
        }

        public System.Threading.Tasks.Task UpdateAsync( AuthUser user )
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<string> GetPasswordHashAsync( AuthUser user )
        {
            return Task.FromResult<string>( user.Password );
        }

        public Task<bool> HasPasswordAsync( AuthUser user )
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync( AuthUser user, string passwordHash )
        {
            throw new NotImplementedException();
        }
    }
}