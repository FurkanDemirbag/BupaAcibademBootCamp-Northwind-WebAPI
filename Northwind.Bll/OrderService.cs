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
    public class OrderService : BllBase<Order, DtoOrder>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orderRepository = serviceProvider.GetService<IOrderRepository>();
        }

        public IQueryable OrderReport(int orderId)
        {
            return _orderRepository.OrderReport(orderId);
        }
    }
}
