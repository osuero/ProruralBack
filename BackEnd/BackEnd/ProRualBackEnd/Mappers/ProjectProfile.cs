using AutoMapper;
using Data.Entities;
using ProRualBackEnd.Dtos.project;
using ProRualBackEnd.Dtos.User;

namespace ProRualBackEnd.Mappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();
                      //.ForMember(dest => dest.ProruralFunds, opt => opt.MapFrom(src => src.ProruralFunds))
                      //.ForMember(dest => dest.OrganizationFunds, opt => opt.MapFrom(src => src.OrganizationFunds))
                      //.ForMember(dest => dest.CreditFunds, opt => opt.MapFrom(src => src.CreditFunds))
                      //.ForMember(dest => dest.GorbermentFunds, opt => opt.MapFrom(src => src.GobermentFunds))
                      //.ForMember(dest => dest.FinancingGroup, opt => opt.MapFrom(src => src.FinancingGroup));


            // Mapeo de Project a ProjectReadDto (para lectura)
            CreateMap<Project, ProjectReadDto>();
        }
        private static decimal DecimalToZero(decimal? input)
        {
            return input ?? 0;
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
