using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Country.Queries.GetDistrictes;

public class GetDistricesQueryHandler(IOtherRepository otherRepository) : IRequestHandler<GetDistrictesQuery, IEnumerable<Domain.Entities.Region>>
{
    public async Task<IEnumerable<Domain.Entities.Region>> Handle(GetDistrictesQuery request, CancellationToken cancellationToken)
    {
        return await otherRepository.GetDistricts(request.PerentId);
    }
}
