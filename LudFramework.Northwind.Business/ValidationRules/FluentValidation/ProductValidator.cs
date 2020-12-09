using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LudFramework.Northwind.Entities.Concrete;

namespace LudFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p=>p.CategoryId==1);
            //Kendi kurallarımıda yazabilirim.
            //RuleFor(p => p.ProductName).Must(StartWithA); 

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
