using FluentValidation;
using LudFramework.Northwind.Business.ValidationRules.FluentValidation;
using LudFramework.Northwind.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudFramework.Northwind.Business.DependencyResolvers.Ninject
{
    class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
