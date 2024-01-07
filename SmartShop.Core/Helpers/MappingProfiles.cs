using AutoMapper;

namespace SmartShop.Core;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.SubCategory, o => o.MapFrom(s => s.SubCategory.Name));
    }
    
}
