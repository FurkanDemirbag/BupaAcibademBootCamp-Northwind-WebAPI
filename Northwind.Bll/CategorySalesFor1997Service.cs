using Northwind.Bll.Base;
using Northwind.Dal.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CategorySalesFor1997Service : BllBase<CategorySalesFor1997, DtoCategorySalesFor1997>, ICategorySalesFor1997Service
    {
        private readonly ICategorySalesFor1997Service _categorySalesFor1997Service;

        public CategorySalesFor1997Service(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _categorySalesFor1997Service = serviceProvider.GetService<ICategorySalesFor1997Service>();
        }
    }
}
