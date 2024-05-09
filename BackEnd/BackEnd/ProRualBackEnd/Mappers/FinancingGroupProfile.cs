using AutoMapper;
using Data.Entities;
using ProRualBackEnd.Dtos.Financing;

namespace ProRualBackEnd.Mappers
{
    public class FinancingGroupProfile : Profile
    {
        public FinancingGroupProfile()
        {
            CreateMap<FinancingGroupCreateDto, FinancingGroup>();
            CreateMap<FinancingGroupUpdateDto, FinancingGroup>().ReverseMap();
            CreateMap<FinancingGroupReadDto, FinancingGroup>().ReverseMap();
        }
    }
}
