using AutoMapper;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Claims.Dtos;

public class ClaimProfile : Profile
{
    public ClaimProfile()
    {
        CreateMap<Claim, ClaimDto>();
    }
}
