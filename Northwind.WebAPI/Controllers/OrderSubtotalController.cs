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
    public class OrderSubtotalController : ApiBaseController<IOrderSubtotalService, OrderSubtotal, DtoOrderSubtotal>
    {
        private readonly IOrderSubtotalService _orderSubtotalService;
        public OrderSubtotalController(IOrderSubtotalService orderSubtotalService) : base(orderSubtotalService)
        {
            _orderSubtotalService = orderSubtotalService;
        }
    }
}
