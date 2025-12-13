using AutoMapper;
using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Claims.Commands.AddOrUpdateClaim;

public class AddOrUpdateClaimCommandHandler(
    IClaimRepository claimRepository,
    IMapper mapper) : IRequestHandler<AddOrUpdateClaimCommand>
{
    public async Task Handle(AddOrUpdateClaimCommand request, CancellationToken cancellationToken)
    {
        var claim = mapper.Map<Claim>(request.createClaim);
        await claimRepository.AddOrUpdateClaimAsync(claim);
    }
}
