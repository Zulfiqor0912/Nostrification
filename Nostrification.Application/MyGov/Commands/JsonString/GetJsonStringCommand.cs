using MediatR;

namespace Nostrification.Application.MyGov.Commands.JsonString;

public class  GetJsonStringCommand(int taskId, string version) : IRequest<string>
{
    public int TaskId { get; set; } = taskId;
    public string Version { get; set; } = version;
}
