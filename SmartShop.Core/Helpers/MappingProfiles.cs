using AutoMapper;
using SmartShop.Core.Helpers;

namespace SmartShop.Core;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.SubCategory, o => o.MapFrom(s => s.SubCategory.Name))
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
    }
    
}
