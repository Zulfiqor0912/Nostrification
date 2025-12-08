using AutoMapper;
using MediatR;
using Nostrification.Application.Region.Dtos;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Region.Queries.GetAllRegions;

public class GetAllRegionsQueryHandler(
    IOtherRepository otherRepository,
    IMapper mapper) : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDto>>
{
    public async Task<IEnumerable<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await otherRepository.GetAllRegions();
        var dtos = mapper.Map<IEnumerable<RegionDto>>(regions);
        return dtos;
    }
}
