using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Products.Commands;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}