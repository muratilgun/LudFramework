using LudFramework.Core.DataAccess;
using LudFramework.Core.DataAccess.EntityFramework;
using LudFramework.Core.DataAccess.NHibernate;
using LudFramework.Northwind.Business.Abstract;
using LudFramework.Northwind.Business.Concrete.Managers;
using LudFramework.Northwind.DataAccess.Abstract;
using LudFramework.Northwind.DataAccess.Concrete.EntityFramework;
using LudFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();


        }
    }
}
