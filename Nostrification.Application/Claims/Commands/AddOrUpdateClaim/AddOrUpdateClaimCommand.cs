using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.Claims.Commands.AddOrUpdateClaim;

public class AddOrUpdateClaimCommand(ClaimDto claim) : IRequest
{
    public ClaimDto createClaim { get; set; } = claim;
}
