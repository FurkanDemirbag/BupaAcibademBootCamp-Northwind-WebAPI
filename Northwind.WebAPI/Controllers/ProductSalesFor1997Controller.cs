using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductSalesFor1997Controller : ApiBaseController<IProductSalesFor1997Service, ProductSalesFor1997, DtoProductSalesFor1997>
    {
        private readonly IProductSalesFor1997Service _productSalesFor1997Service;
        public ProductSalesFor1997Controller(IProductSalesFor1997Service productSalesFor1997Service) : base(productSalesFor1997Service)
        {
            _productSalesFor1997Service = productSalesFor1997Service;
        }
    }
}
