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
    public class OrdersQryService : BllBase<OrdersQry, DtoOrdersQry>, IOrdersQryService
    {
        private readonly IOrdersQryService _ordersQryService;

        public OrdersQryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ordersQryService = serviceProvider.GetService<IOrdersQryService>();
        }
    }
}
