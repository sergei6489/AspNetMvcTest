using System;
using System.IO;
using System.Web;
using Core;
using Moq;
using NUnit.Framework;
using Web.Controllers;
using Web.IocNinject;
using Web.ViewModel;

namespace UnitTest
{
   
    public class CartControllerTest
    {
        [Test]
        public void CartSetCountProductTest()
        {
            Cart cart = new Cart();
            cart.Products=new System.Collections.Generic.List<CartProduct>(){new CartProduct(new Product(){Id = 4})};
            Mock<IRepository> mock = new Mock<IRepository>();
            Mock<CartService> cartMock = new Mock<CartService>(mock.Object);
            cartMock.Setup( n => n.GetCart() ).Returns( cart );
            CartController cartController = new CartController( mock.Object, cartMock.Object );
            cartController.SetProductCountCart( 4, -3 );
            Assert.AreEqual( cart.Products.Count, 0 );
        }
    }
}
