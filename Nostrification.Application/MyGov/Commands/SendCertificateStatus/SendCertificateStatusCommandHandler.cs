using AutoMapper;
using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Commands.SendCertificateStatus;

public class SendCertificateStatusCommandHandler(
    IMyGovRepository myGovRepository,
    IMapper mapper) : IRequestHandler<SendCertificateStatusCommand, bool>
{
    public async Task<bool> Handle(SendCertificateStatusCommand request, CancellationToken cancellationToken)
    {
        var claim = mapper.Map<Claim>(request.dto);
        return await myGovRepository.SendCertificateStatusAsync(claim, request.Version);
    }
}
