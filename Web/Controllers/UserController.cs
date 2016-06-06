using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Web.Auth;

namespace Web.Controllers
{
    public class UserController : BaseController
    {
        private CustomUserManager UserManager
        {
            get
            {
                return System.Web.HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>();
            }
        }

        private IRepository repository;

        public UserController( IRepository repository )
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn( User user )
        {
            var data = await UserManager.FindAsync( user.UserName, user.Password );
            if( data != null )
            {
                await SigInAsync( data );
            }
            return RedirectToAction( "Index", "Home" );
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut( DefaultAuthenticationTypes.ApplicationCookie );
            return RedirectToAction( "Index", "Home" );
        }

        #region Редактирование пользователя

        [HttpGet]
        [CustromAuthAttribute]
        public ActionResult Edit( int id )
        {
            User user;
            ViewBag.IsNew = false;
            user = repository.GetUserById( id );
            return View( user );
        }

        [HttpPost]
        [CustromAuthAttribute]
        public ActionResult Edit( User user )
        {
            bool isExists = repository.GetUserByLogin( user.UserName ) != null;
            if( !ModelState.IsValid && isExists )
            {
                if( isExists )
                {
                    ModelState.AddModelError( "UserName", "Пользователь с таким уже существует" );
                }
                ViewBag.IsNew = true;
                return View( user );
            }
            else
            {
                repository.AddUser( user );
                repository.Save();
            }
            return RedirectToAction( "Index", "Home" );
        }
        #endregion

        #region Добавление пользователя

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.IsNew = true;
            var user = new User();
            return View( "Edit", user );
        }

        [HttpPost]
        public ActionResult Add( User user )
        {
            bool isExists = repository.GetUserByLogin( user.UserName ) != null;
            if( !ModelState.IsValid || isExists )
            {
                if( isExists )
                {
                    ModelState.AddModelError( "UserName", "Пользователь с таким логином уже существует" );
                }
                ViewBag.IsNew = true;
                return View("Edit", user );
            }
            else
            {
                repository.AddUser( user );
                repository.Save();
            }
            return RedirectToAction( "Index", "Home" );
        }

        #endregion

        [CustromAuthAttribute]
        public ActionResult Delete( int id )
        {
            var user = repository.RemoveUserById( id );
            repository.Save();
            if( user == null )
            {
                return RedirectToAction( "GetUsers", "User" );
            }
            else
            {
                return RedirectToAction( "GetUsers", "User" );
            }
        }

        private async Task SigInAsync( AuthUser user )
        {
            AuthenticationManager.SignOut( DefaultAuthenticationTypes.ExternalCookie );
            var identity = await UserManager.CreateIdentityAsync( user, DefaultAuthenticationTypes.ApplicationCookie );
            AuthenticationManager.SignIn( new AuthenticationProperties() { IsPersistent = true }, identity );
        }

        [CustromAuthAttribute]
        public ActionResult GetUsers()
        {
            var users = repository.GetUsers();
            return View( users );
        }
    }
}