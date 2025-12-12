using AutoMapper;
using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Commands.SendStatusReject;

public class SendStatusRejectCommandHandler(
    IMyGovRepository myGovRepository,
    IMapper mapper) : IRequestHandler<SendStatusRejectCommad, bool>
{
    public async Task<bool> Handle(SendStatusRejectCommad request, CancellationToken cancellationToken)
    {
        var claim = mapper.Map<Claim>(request.dto);
        return await myGovRepository.SendStatusRejectAsync(claim, request.fileString, request.version);
    }
}
