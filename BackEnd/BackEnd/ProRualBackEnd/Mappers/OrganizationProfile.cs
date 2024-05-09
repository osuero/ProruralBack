using AutoMapper;
using Data.Entities;
using ProRualBackEnd.Dtos.Organization;
using System.Xml;

namespace ProRualBackEnd.Mappers
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<OrganizationCreateDto, Organization>()
                    .ForMember(dest => dest.ProductiveActivityId, opt => opt.MapFrom(src => ConvertToGuid(src.ProductiveActivityId))).ForMember(dest => dest.PresidentId, opt => opt.MapFrom(src => ConvertToGuid(src.PresidentId)));
                    
                   

            CreateMap<OrganizationReadDto, Organization>().ReverseMap();

            CreateMap<OrganizationUpdateDto, Organization>().ForMember(dest => dest.ProductiveActivityId, opt => opt.MapFrom(src => ConvertToGuid(src.ProductiveActivityId))).ForMember(dest => dest.PresidentId, opt => opt.MapFrom(src => ConvertToGuid(src.PresidentId)));

                
        }

        private static Guid? ConvertToGuid(string value)
        {
            if (Guid.TryParse(value, out Guid result))
            {
                return result;
            }
            return null;
        }
    }
}

