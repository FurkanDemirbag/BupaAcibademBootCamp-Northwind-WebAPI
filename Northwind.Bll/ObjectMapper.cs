using AutoMapper;
using Northwind.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    class ObjectMapper
    {
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(a =>
            {
                a.AddProfile<MappingProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}
