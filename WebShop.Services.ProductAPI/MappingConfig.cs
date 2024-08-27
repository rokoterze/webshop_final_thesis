using AutoMapper;
using WebShop.Services.ProductAPI.Models;
using WebShop.Services.ProductAPI.Models.Dto;

namespace WebShop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CreateProductDto, Product>().ReverseMap();
            }
            );
            return mappingConfig;
        }
    }
}
