using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Claims.Commands.PushTask;

public class PushTaskCommandHandler(
    IMyGovRepository myGovRepository,
    IClaimRepository claimRepository,
    ITaskRepository taskRepository) : IRequestHandler<PushTaskCommand>
{
    public async Task Handle(PushTaskCommand request, CancellationToken cancellationToken)
    {
        var json = myGovRepository.GetJsonStringAsync(request.taskId, request.version);
        var (taskEntity, entities) = await taskRepository.ParseAsync(json, request.taskId);
        var claim = await claimRepository.GetClaimByIdAsync(request.taskId);

        if (claim != null)
        {

        }
    }
}