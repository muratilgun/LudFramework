using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LudFramework.Core.DataAccess.EntityFramework;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.Entities.ComplexTypes;
using LudFramework.Northwind.Entities.Concrete;

namespace LudFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                    join c in context.Categories on p.CategoryId equals c.CategoryId
                    select new ProductDetail
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName

                    };
                return result.ToList();
            }
            
        }
    }
}
