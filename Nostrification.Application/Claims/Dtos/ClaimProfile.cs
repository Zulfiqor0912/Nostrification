using AutoMapper;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Claims.Dtos;

public class ClaimProfile : Profile
{
    public ClaimProfile()
    {
        CreateMap<Claim, ClaimDto>()
            .ForMember(does => does.ClaimerType, opt => opt.MapFrom(src => src.ClaimerType))
            .ForMember(does => does.ClaimStatus, opt => opt.MapFrom(src => src.ClaimStatus))
            .ForMember(does => does.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(does => does.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(does => does.District, opt => opt.MapFrom(src => src.District))
            .ForMember(does => does.StudyStep, opt => opt.MapFrom(src => src.StudyStep))
            .ForMember(does => does.StudyType, opt => opt.MapFrom(src => src.StudyType));
    }
}
