using AutoMapper;
using Data.Entities;
using ProRualBackEnd.Dtos.Fund;

namespace ProRualBackEnd.Mappers
{
    public class FundProfile : Profile
    {
        public FundProfile()
        {
            CreateMap<FundDto, Fund>().ReverseMap();

            CreateMap<FundCreateDto, Fund>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ReverseMap();

            CreateMap<FundReadDto, Fund>().ReverseMap();
        }
    }
}
