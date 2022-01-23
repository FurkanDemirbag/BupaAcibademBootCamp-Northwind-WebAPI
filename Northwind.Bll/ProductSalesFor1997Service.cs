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
    public class ProductSalesFor1997Service : BllBase<ProductSalesFor1997, DtoProductSalesFor1997>, IProductSalesFor1997Service
    {
        private readonly IProductSalesFor1997Service _productSalesFor1997Service;

        public ProductSalesFor1997Service(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productSalesFor1997Service = serviceProvider.GetService<IProductSalesFor1997Service>();
        }
    }
}
