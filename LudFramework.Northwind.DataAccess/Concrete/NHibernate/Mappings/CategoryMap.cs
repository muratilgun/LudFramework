﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LudFramework.Northwind.Entities.Concrete;

namespace LudFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap: ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");


        }
    }
}
