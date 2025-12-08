using AutoMapper;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Extension.Region.Dtos;

public class RegionProfile : Profile
{
    public RegionProfile() 
    {
        CreateMap<RegionDto, Region>();
    }
}
