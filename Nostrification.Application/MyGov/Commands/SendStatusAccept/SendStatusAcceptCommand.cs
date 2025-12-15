using MediatR;

namespace Nostrification.Application.MyGov.Commands.SendStatusAccept;

public class SendStatusAcceptCommand(int taskId, string fileBase64, string version) : IRequest<bool>
{
    public int TaskId { get; set; } = taskId;
    public string FileBase64 { get; set;} = fileBase64;
    public string Version { get; set;} = version;
}
