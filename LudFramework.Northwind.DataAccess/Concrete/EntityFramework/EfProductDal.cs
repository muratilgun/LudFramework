using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LudFramework.Core.DataAccess.EntityFramework;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.Entities.Concrete;

namespace LudFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}
