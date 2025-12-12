using MediatR;

namespace Nostrification.Application.MyGov.Queries.SendStatus;

public class SendStatusGetCommand(int taskId, string version) : IRequest<bool>
{
    public int TaskId { get; set; } = taskId;
    public string Version { get; set; } = version;
}
