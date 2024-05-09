using AutoMapper;
using Data.Entities;
using ProRualBackEnd.Dtos.Beneficiary;
using ProRural.Data.Enums;

namespace ProRualBackEnd.Mappers
{
    public class BeneficiaryProfile : Profile
    {
        public BeneficiaryProfile()
        {
            CreateMap<BeneficiaryCreateDto, Beneficiary>()
         .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Sex, true)));

    

            // Mapeo de BeneficiaryUpdateDto a Beneficiary (para actualización)
            CreateMap<BeneficiaryUpdateDto, Beneficiary>().ForMember(dest => dest.Sex, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Sex, true)));

            CreateMap<Beneficiary, BeneficiaryReadDto>()
                       .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))  // Direct mapping
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                       .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                       .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                       .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                       .ForMember(dest => dest.CivilStatus, opt => opt.MapFrom(src => src.CivilStatus))
                       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                       .ForMember(dest => dest.OtherPhoneNumber, opt => opt.MapFrom(src => src.OtherPhoneNumber))
                       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                       .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.Profession))
                       .ForMember(dest => dest.EducationLevel, opt => opt.MapFrom(src => src.EducationLevel))
                       .ForMember(dest => dest.CanRead, opt => opt.MapFrom(src => src.CanRead))
                       .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                       .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                       .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                       .ForMember(dest => dest.IsForeign, opt => opt.MapFrom(src => src.IsForeign))
                      ;  // Assume IcvType is not directly mapped
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

