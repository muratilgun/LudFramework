using LudFramework.Core.DataAccess.EntityFramework;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.Entities.Concrete;

namespace LudFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {

    }
}
