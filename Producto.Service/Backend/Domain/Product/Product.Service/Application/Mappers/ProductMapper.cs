using AutoMapper;
using Product.Service.Application.Dtos;
using Product.Service.Domain.Products.Entities;

namespace Product.Service.Application.Mappers
{   
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductForCreationDto, ProductEntity>();
            CreateMap<ProductForUpdateDto, ProductEntity>();
            CreateMap<ProductEntity, ProductForUpdateDto>();
        }
    }
}
