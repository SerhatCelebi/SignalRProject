using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            
            CreateMap<Product, ResultProductWithCategoryDto>()
              .ForMember(dest => dest.CategoryName, opt => opt
              .MapFrom(src => src.Category.CategoryName))
              .ReverseMap();


        }
    }
}
