using MediatR;

namespace Nostrification.Application.Extension.Region.Queries.GetAllRegions;

public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
{
}
