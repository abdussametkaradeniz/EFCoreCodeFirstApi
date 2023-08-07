using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Services.Mapping {
    public class MapProfile : Profile {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<ProductFeature,ProductFeatureDto>().ReverseMap();
            CreateMap<Product,ProductWithCategoryDto>().ReverseMap();
            CreateMap<Category,CategoryWithProductsDto>().ReverseMap();
        }
    }
}
