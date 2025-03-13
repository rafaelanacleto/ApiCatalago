using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ApiCatalago.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Categoria, Dtos.CategoriaDTO>().ReverseMap();
            CreateMap<Models.Produto, Dtos.ProdutoDTO>().ReverseMap();

        }
    }
}