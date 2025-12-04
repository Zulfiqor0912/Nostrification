using AutoMapper;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Claims.Dtos;

public class ClaimProfile : Profile
{
    public ClaimProfile()
    {
        CreateMap<Claim, ClaimDto>()
            .ForMember(does => does.ClaimStatus, opt => opt.MapFrom(src => src.ClaimStatus))
            .ForMember(does => does.Region, opt => opt.MapFrom(src => src.Region));
    }
}
