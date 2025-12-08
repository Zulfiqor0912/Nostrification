using MediatR;
using Nostrification.Application.Region.Dtos;

namespace Nostrification.Application.Region.Queries.GetAllRegions;

public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
{
}
