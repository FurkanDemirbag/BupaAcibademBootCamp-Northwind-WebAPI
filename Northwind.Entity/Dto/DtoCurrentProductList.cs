using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
    public class DtoCurrentProductList : DtoBase
    {
        public string CategoryName { get; set; }
        public decimal? CategorySales { get; set; }

        public DtoCurrentProductList()
        {

        }
    }
}
