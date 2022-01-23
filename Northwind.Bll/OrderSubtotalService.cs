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
    public class OrderSubtotalService : BllBase<OrderSubtotal, DtoOrderSubtotal>, IOrderSubtotalService
    {
        private readonly IOrderSubtotalService _orderSubtotalService;

        public OrderSubtotalService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orderSubtotalService = serviceProvider.GetService<IOrderSubtotalService>();
        }
    }
}
