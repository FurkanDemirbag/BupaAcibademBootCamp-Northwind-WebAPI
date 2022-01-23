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
    public class CategorySalesFor1997Controller : ApiBaseController<ICategorySalesFor1997Service, CategorySalesFor1997, DtoCategorySalesFor1997>
    {
        private readonly ICategorySalesFor1997Service _categorySalesFor1997Service;
        public CategorySalesFor1997Controller(ICategorySalesFor1997Service categorySalesFor1997Service) : base(categorySalesFor1997Service)
        {
            _categorySalesFor1997Service = categorySalesFor1997Service;
        }
    }
}
