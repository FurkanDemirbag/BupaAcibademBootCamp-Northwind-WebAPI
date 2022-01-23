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
    public class SalesByCategoryService : BllBase<SalesByCategory, DtoSalesByCategory>, ISalesByCategoryService
    {
        private readonly ISalesByCategoryService _salesByCategoryService;

        public SalesByCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _salesByCategoryService = serviceProvider.GetService<ISalesByCategoryService>();
        }
    }
}
