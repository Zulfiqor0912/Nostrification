using MediatR;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Country.Queries.GetCountries;

public class GetCountriesQuery : IRequest<IEnumerable<Domain.Entities.Country>>
{

}
