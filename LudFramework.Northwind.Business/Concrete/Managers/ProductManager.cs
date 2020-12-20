using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LudFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using LudFramework.Northwind.Business.Abstract;
using LudFramework.Northwind.Business.ValidationRules.FluentValidation;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.Entities.Concrete;
using LudFramework.Core.Aspects.Postsharp;
using LudFramework.Core.DataAccess;
using System.Transactions;
using LudFramework.Core.Aspects.Postsharp.TransactionAspects;
using LudFramework.Core.Aspects.Postsharp.ValidationAspects;
using LudFramework.Core.Aspects.Postsharp.CacheAspects;
using LudFramework.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace LudFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {

            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {

            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
