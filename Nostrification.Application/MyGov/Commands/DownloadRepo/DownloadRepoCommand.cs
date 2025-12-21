using MediatR;

namespace Nostrification.Application.MyGov.Commands.DownloadRepo;

public class DownloadRepoCommand(int taskId, string version = "v2") : IRequest<(byte[] fileBytes, string fileName)>
{
    public int Id { get; set; } = taskId;
    public string Version { get; set; } = version;
}
