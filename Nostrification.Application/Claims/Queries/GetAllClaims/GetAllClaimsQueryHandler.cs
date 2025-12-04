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
        try
        {
            var allClaims = await claimRepository.GetClaimsAsyn();

            if (allClaims == null || !allClaims.Any())
            {
                logger.LogInformation("No claims found.. Query: {Query}", nameof(GetAllClaimsQuery));
                return new List<ClaimDto>();
            }
            var claims = allClaims.ToList();
            var result = mapper.Map<List<ClaimDto>>(claims);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error GetAllClaimsQuery");
            throw new ApplicationException("There was an error retrieving claims.", ex);
        }
    }
}
