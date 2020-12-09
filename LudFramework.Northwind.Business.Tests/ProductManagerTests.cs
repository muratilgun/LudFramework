using LudFramework.Northwind.Business.Concrete.Managers;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentValidation;
using System;

namespace LudFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        //Expected Validation Test => Yani programın bir exception vermesini bekliyoruz. 
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            // Eklediğimiz product validation kurallarına uygun olmadığı için hata alıyoruz Test başarılı oluyor. Validationların doğru şekilde çalıştığına emin oluyorum.
            productManager.Add(new Product());

        }
    }
}
