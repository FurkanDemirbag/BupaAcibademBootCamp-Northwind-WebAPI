using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
    public class DtoUserToken
    {
        public DtoUser DtoUser { get; set; }
        public object AccessToken { get; set; }

        public DtoUserToken()
        {
            
        }
    }
}
