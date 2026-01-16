using AutoMapper;

namespace Nostrification.Application.Region.Dtos;

public class RegionProfile : Profile
{
    public RegionProfile() 
    {
        CreateMap<RegionDto, Domain.Entities.Region>();
        CreateMap<Domain.Entities.Region, RegionDto>();
    }
}
