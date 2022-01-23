using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
    public class DtoLogin
    {
        public string UserCode { get; set; }
        public string Password { get; set; }

        public DtoLogin()
        {
            
        }
    }
}
