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
    ) : IRequestHandler<GetAllClaimsQuery, List<ClaimDto>>
{
    public async Task<List<ClaimDto>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
    {
            var allClaims = await claimRepository.GetClaimsAsyn();
            var claims = allClaims.ToList();
            var result = mapper.Map<List<ClaimDto>>(claims);
            return result;
    }
}
