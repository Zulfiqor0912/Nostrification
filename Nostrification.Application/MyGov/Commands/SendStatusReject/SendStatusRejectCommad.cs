using MediatR;
using Nostrification.Application.Claims.Dtos;

namespace Nostrification.Application.MyGov.Commands.SendStatusReject;

public class SendStatusRejectCommad : IRequest<bool>
{
    public ClaimDto dto { get; set; }
    public string fileString { get; set; }
    public string version { get; set; }
}
