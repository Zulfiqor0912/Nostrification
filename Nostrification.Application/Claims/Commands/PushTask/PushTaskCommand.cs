using MediatR;

namespace Nostrification.Application.Claims.Commands.PushTask;

public class PushTaskCommand(int TaskId, string Version) : IRequest
{
    public int taskId { get; set; } = TaskId;
    public string version { get; set; } = Version;
}
