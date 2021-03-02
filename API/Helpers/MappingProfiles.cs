using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDto>()
                .ForMember(x=>x.ProductBrand,y=>y.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(x=>x.ProductType,y=>y.MapFrom(s=>s.ProductType.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
            CreateMap<Address,AddressDto>().ReverseMap();
        }
    }
}