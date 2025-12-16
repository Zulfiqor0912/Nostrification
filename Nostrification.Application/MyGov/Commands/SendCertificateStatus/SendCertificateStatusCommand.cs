using MediatR;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.MyGov.Commands.SendCertificateStatus;

public class SendCertificateStatusCommand : IRequest<bool>
{
    public ClaimDto dto { get; set; }
    public string Version { get; set; }
}
