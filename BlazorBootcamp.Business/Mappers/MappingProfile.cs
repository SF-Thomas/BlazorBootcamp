using AutoMapper;
using BlazorBootcamp.DataAccess;
using BlazorBootcamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootcamp.Business.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();  
            CreateMap<Product, ProductDTO>().ReverseMap();  
        }
    }
}
