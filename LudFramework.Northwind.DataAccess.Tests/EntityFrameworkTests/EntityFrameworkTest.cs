﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LudFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace LudFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        #region Bütün Ürünlerin Testi

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            // Test amaçlı instance alıyorum.
            EfProductDal productDal = new EfProductDal();
            //SqlQuery yazıp elimdeki toplam product sayısını alıyorum 77 adet var 
            var result = productDal.GetList();

            Assert.AreEqual(77,result.Count);
            //Get_all_returns_all_products passed dönüşü alıyorum 77 ürün geliyor ve testi başarılı bir şekilde geçiyor.
        }

        #endregion
        

        #region Filtre Testi

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            // Test amaçlı instance alıyorum.
            EfProductDal productDal = new EfProductDal();
            /*Product içerisinde ab içeren ürünleri görmek için bir sql query yazıyorum.
             ---select COUNT(*) from Products where ProductName like '%ab%--- 
            sorgu sonucu 4 adet ürün geliyor*/
            var result = productDal
                .GetList(p => 
                    p.ProductName.Contains("ab")/* && || gibi operatörlerle filterelerimizi dahada genişletebiliiz. */);

            Assert.AreEqual(4, result.Count);
            // Get_all_with_parameter_returns_filtered_products passed dönüşü alıyorum. 4 tane ürün geliyor.
        }

        #endregion

    }
}
