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

namespace LudFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidate(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidate(typeof(ProductValidator))]
        public Product Update(Product product)
        {

            return _productDal.Update(product);
        }
    }
}
