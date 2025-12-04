using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.Claims.Queries.GetClaims;

public class GetAllClaimsQuery : IRequest<List<ClaimDto>>
{
    public GetAllClaimsQuery()
    {
        
    }
}
