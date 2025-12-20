using MediatR;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Country.Queries.GetDistrictes;

public class GetDistrictesQuery(int parentId) : IRequest<IEnumerable<Domain.Entities.Region>>
{
    public int PerentId { get; set; } = parentId;
}
