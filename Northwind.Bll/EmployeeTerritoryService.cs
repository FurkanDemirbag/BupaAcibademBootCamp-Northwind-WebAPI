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
    public class EmployeeTerritoryService : BllBase<EmployeeTerritory, DtoEmployeeTerritory>, IEmployeeTerritoryService
    {
        private readonly IEmployeeTerritoryService _employeeTerritoryService;

        public EmployeeTerritoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _employeeTerritoryService = serviceProvider.GetService<IEmployeeTerritoryService>();
        }
    }
}
