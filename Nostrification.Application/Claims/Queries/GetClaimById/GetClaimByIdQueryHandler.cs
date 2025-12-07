using AutoMapper;
using MediatR;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Claims.Queries.GetClaimById;

public class GetClaimByIdQueryHandler(
    IClaimRepository claimRepository,
    IMapper mapper) : IRequestHandler<GetClaimByIdQuery, ClaimDto>
{
    public async Task<ClaimDto> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
    {
        var claim = await claimRepository.GetClaimByIdAsync(request.Id);
        var dto = mapper.Map<ClaimDto>(claim);
        return dto;
    }
}
