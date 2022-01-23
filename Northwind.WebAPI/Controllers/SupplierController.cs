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
    public class SupplierController : ApiBaseController<ISupplierService, Supplier, DtoSupplier>
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService) : base(supplierService)
        {
            _supplierService = supplierService;
        }
    }
}
