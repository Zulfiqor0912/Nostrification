using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.Claims.Commands.AddOrUpdateClaim;

public class AddOrUpdateClaimCommand : IRequest
{
    public ClaimDto createClaim { get; set; }
}
