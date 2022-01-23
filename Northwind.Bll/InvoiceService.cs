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
    public class InvoiceService : BllBase<Invoice, DtoInvoice>, IInvoiceService
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _invoiceService = serviceProvider.GetService<IInvoiceService>();
        }
    }
}
