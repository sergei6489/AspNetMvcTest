using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Core;
using Moq;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace Web.IocNinject
{
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;

        public NinjectScope( IResolutionRoot kernel )
        {
            resolutionRoot = kernel;
        }

        public object GetService( Type serviceType )
        {
            IRequest request = resolutionRoot.CreateRequest( serviceType, null, new Parameter[0], true, true );
            return resolutionRoot.Resolve( request ).SingleOrDefault();
        }

        public IEnumerable<object> GetServices( Type serviceType )
        {
            IRequest request = resolutionRoot.CreateRequest( serviceType, null, new Parameter[0], true, true );
            return resolutionRoot.Resolve( request ).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if( disposable != null ) disposable.Dispose();
            resolutionRoot = null;
        }
    }

    public class NinjectResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        IKernel _kernel;
        public NinjectResolver( IKernel kernel )
            : base( kernel )
        {
            this._kernel = kernel;
            AddBinding();
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope( _kernel.BeginBlock() );
        }

        private List<Product> FillProducts()
        {
            var image = File.ReadAllBytes( HttpContext.Current.Server.MapPath( "~/Content/TestImage.jpg" ) );
            var products = new List<Product>()
            {
                new Product(){Id=0,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=1,Description="description description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=2,Description="description test",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=3,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=4,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=5,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=6,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=7,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"},
                new Product(){Id=8,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=9,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=10,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=11,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=12,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=13,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=14,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=15,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"},
                new Product(){Id=16,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=17,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=27,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=37,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=47,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=54,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=68,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=73,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"},
                new Product(){Id=1234,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=1346,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=2246,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=375,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=46589,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=557,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=69528,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=738,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"},
                new Product(){Id=3888,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=18558,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=25548,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=30066,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=40066,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=56686,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=6643,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=7267,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"},
                new Product(){Id=3721,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=1356,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=235636,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=3365,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Электроника"},
                new Product(){Id=4365,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=5356,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=647657,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Бытовой товар"},
                new Product(){Id=71119,Description="description",Name="Первый продукт",Price=456,Image=image,Category="Книги"}
            };
            return products;
        }

        private List<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User(){Id = 1, UserName = "test1",Password="test1",Name="test test test",IsAdmin=true},
                new User(){Id = 2, UserName = "test2",Password="test2",Name="test2 test2 test2",IsAdmin=false},
                new User(){Id = 3, UserName = "test3",Password="test3",Name="test3 test3 test3",IsAdmin=false},
                new User(){Id = 4, UserName = "test4",Password="test4",Name="test4 test4 test4",IsAdmin=false},
                new User(){Id = 5, UserName = "test5",Password="test5",Name="test5 test5 test5",IsAdmin=false},
            };
            return users;
        }

        private Mock<IRepository> GetMockRepository()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            int hh;
            var products = FillProducts();
            var users = GetUsers();
            mock.Setup( n => n.GetPageProducts( It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), out hh ) ).Returns(
                ( int a, int b, string c, int count ) =>
                {
                    return c == null ? products.Skip( (a - 1) * b ).Take( b ).ToList() : products.Where( n => n.Category == c ).Skip( (a - 1) * b ).Take( b ).ToList();
                } );
            mock.Setup( m => m.GetProductById( It.IsAny<int>() ) ).Returns( ( int id ) => products.FirstOrDefault( n => n.Id == id ) );
            mock.Setup( n => n.AddUser( It.IsAny<User>() ) ).Callback( ( User user ) => { users.Add( user ); } );
            mock.Setup( n => n.GetUsers() ).Returns( users );
            mock.Setup( n => n.GetUserByLogin( It.IsAny<string>() ) ).Returns( ( string userName ) =>
            {
                return users.FirstOrDefault( n => n.UserName == userName );
            } );
            mock.Setup( n => n.GetUserById( It.IsAny<int>() ) ).Returns( ( int id ) => { return users.FirstOrDefault( m => m.Id == id ); } );
            mock.Setup( n => n.AddUser( It.IsAny<User>() ) ).Callback( ( User user ) => { users.Add( user ); } );
            mock.Setup( n => n.EditUser( It.IsAny<User>() ) ).Callback( ( User user ) =>
            {
                var currentUser = users.FirstOrDefault( n => n.Id == user.Id );
                if( currentUser != null )
                {
                    currentUser.Name = user.Name;
                    currentUser.UserName = user.UserName;
                    currentUser.Password = user.Password;
                }
                else
                {
                    throw new Exception( "Указанный пользователь отсутствует" );
                }
            } );
            mock.Setup( n => n.RemoveUserById( It.IsAny<int>() ) ).Returns( ( int id ) => { return users.FirstOrDefault( m => m.Id == id ); } ).Callback( ( int id ) => { users.Remove( users.FirstOrDefault( m => m.Id == id ) ); } );
            mock.Setup( n => n.AddProduct( It.IsAny<Product>() ) ).Returns( ( Product prod ) =>
            {
                prod.Id = products.Max( m => m.Id + 1 );
                return prod;
            } ).Callback( ( Product prod ) =>
            {
                products.Add( prod );
            } );
            mock.Setup( n => n.GetCategories() ).Returns( () =>
            {
                return products.Select( m => m.Category ).Distinct().ToList();
            } );
            return mock;
        }

        private void AddBinding()
        {
            if( true )
            {
                _kernel.Bind<IRepository>().To<EFRepository>();
            }
            else
            {
                var mock = GetMockRepository();
                _kernel.Bind<IRepository>().ToConstant( mock.Object );
            }
            _kernel.Bind<CartService>().To<CartService>();
        }
    }
}