using System;
using System.IO;
using System.Web;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Web.Controllers;

namespace UnitTest
{

    public class ProductControllerTest
    {
        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void CreateTest()
        {
            var product = new Product() { Category = "Электроника", Description = "Новы телефон", Image = new byte[5], Name = "Nokia E3", Price = 500 };
            Mock<IRepository> mock = new Mock<IRepository>();
            Mock<HttpPostedFileBase> mockFileBase = new Mock<HttpPostedFileBase>();
            mockFileBase.Setup( n => n.ContentLength ).Returns( 5 );
            mockFileBase.Setup( m => m.InputStream ).Returns( new MemoryStream() );
            ProductController controller = new ProductController( mock.Object );
            controller.Create( product, mockFileBase.Object, true );
            mock.Verify( n => n.AddProduct( product ), Times.Once() );
        }
        [Test]
        public void CreateIsNewFailTest()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            Mock<HttpPostedFileBase> mockFileBase = new Mock<HttpPostedFileBase>();
            mockFileBase.Setup( n => n.ContentLength ).Returns( 0 );
            mockFileBase.Setup( m => m.InputStream ).Returns( new MemoryStream() );
            var product = new Product() { Category = "Электроника", Description = "Новы телефон", Image = new byte[5], Name = "Nokia E3", Price = 500 };
            ProductController controller = new ProductController( mock.Object );
            controller.Create( product, mockFileBase.Object, true );
            mock.Verify( n => n.AddProduct( product ), Times.Never() );
        }
        [Test]
        public void EditTest()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            Mock<HttpPostedFileBase> mockFileBase = new Mock<HttpPostedFileBase>();
            mockFileBase.Setup( n => n.ContentLength ).Returns( 0 );
            mockFileBase.Setup( m => m.InputStream ).Returns( new MemoryStream() );
            var product = new Product() { Category = "Электроника", Description = "Новы телефон", Image = new byte[5], Name = "Nokia E3", Price = 500 };
            ProductController controller = new ProductController( mock.Object );
            controller.Create( product, mockFileBase.Object, false );
            mock.Verify( n => n.EditProduct( product ), Times.Once );
        }
    }
}
