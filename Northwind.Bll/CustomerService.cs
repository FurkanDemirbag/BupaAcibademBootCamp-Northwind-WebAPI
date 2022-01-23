using Northwind.Bll.Base;
using Northwind.Dal.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerService : BllBase<Customer, DtoCustomer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IServiceProvider serviceProvider): base(serviceProvider)
        {
            _customerRepository = serviceProvider.GetService<ICustomerRepository>();
        }

        public IQueryable CustomerReport()
        {
            return _customerRepository.CustomerReport();
        }

        public DtoCustomer FindById(string id)
        {
            var customer = _customerRepository.FindById(id);

            return ObjectMapper.Mapper.Map<DtoCustomer>(customer);
        }
    }
}
