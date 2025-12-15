using AutoMapper;
using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Commands.SendStatusAccept;

public class SendStatusAcceptAsyncHandler(
    IMyGovRepository myGovRepository): IRequestHandler<SendStatusAcceptCommand, bool>
{
    public async Task<bool> Handle(SendStatusAcceptCommand request, CancellationToken cancellationToken)
    {
        return await myGovRepository.SendStatusAcceptAsync(request.TaskId, request.FileBase64, request.Version);
    }
}
