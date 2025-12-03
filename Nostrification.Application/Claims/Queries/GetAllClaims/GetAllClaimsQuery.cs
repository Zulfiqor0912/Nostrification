using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.Claims.Queries.GetClaims;

public class GetAllClaimsQuery : IRequest<IEnumerable<ClaimDto>>
{
    public GetAllClaimsQuery()
    {
        
    }
}
