using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Claims.Queries.GetClaims;

public class GetAllClaimsQueryHandler(
    ILogger<GetAllClaimsQueryHandler> logger,
    IMapper mapper,
    IClaimRepository claimRepository
    ) : IRequestHandler<GetAllClaimsQuery, IEnumerable<ClaimDto>>
{
    public async Task<IEnumerable<ClaimDto>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var allClaims = await claimRepository.GetClaimsAsyn();
        }
        catch (Exception e)
        {
            
        }
    }
}
