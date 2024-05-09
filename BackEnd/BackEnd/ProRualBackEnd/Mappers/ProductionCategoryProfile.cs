using Data.Entities;
using AutoMapper;
using ProRualBackEnd.Dtos.Ruble;
namespace ProRualBackEnd.Mappers
{
    public class ProductionCategoryProfile : Profile
    {
        public ProductionCategoryProfile() 
        {
            CreateMap<ProductionCategoryDto, ProductionCategory>().ReverseMap();
            CreateMap<ProductionCategoryCreateDto, ProductionCategory>().ReverseMap();
        }
    }
}
