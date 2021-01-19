
using ApiNovosys.Dto.Productos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNovosys.AutoMapper
{
    public class AutoMappers : Profile
    {

        public AutoMappers()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
