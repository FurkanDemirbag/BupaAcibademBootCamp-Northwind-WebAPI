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
    public class ProductsByCategoryService : BllBase<ProductsByCategory, DtoProductsByCategory>, IProductsByCategoryService
    {
        private readonly IProductsByCategoryService _productsByCategoryService;

        public ProductsByCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productsByCategoryService = serviceProvider.GetService<IProductsByCategoryService>();
        }
    }
}
