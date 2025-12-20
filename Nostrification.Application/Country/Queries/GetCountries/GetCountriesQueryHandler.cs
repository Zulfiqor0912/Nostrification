using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Country.Queries.GetCountries;

public class GetCountriesQueryHandler(IOtherRepository otherRepository) : IRequestHandler<GetCountriesQuery, IEnumerable<Domain.Entities.Country>>
{
    public async Task<IEnumerable<Domain.Entities.Country>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return await otherRepository.GetCountries();
    }
}
