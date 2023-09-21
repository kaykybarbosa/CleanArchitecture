using AutoMapper;
using CleanArchitecture.Application.DTOs.Requests.Category;
using CleanArchitecture.Application.DTOs.Requests.Product;
using CleanArchitecture.Application.DTOs.Responses.Category;
using CleanArchitecture.Application.DTOs.Responses.Product;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}