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
    public class CustomerAndSuppliersByCityController : ApiBaseController<ICustomerAndSuppliersByCityService, CustomerAndSuppliersByCity, DtoCustomerAndSuppliersByCity>
    {
        private readonly ICustomerAndSuppliersByCityService _customerAndSuppliersByCity;
        public CustomerAndSuppliersByCityController(ICustomerAndSuppliersByCityService customerAndSuppliersByCity) : base(customerAndSuppliersByCity)
        {
            _customerAndSuppliersByCity = customerAndSuppliersByCity;
        }
    }
}
