using MediatR;
using Microsoft.Extensions.Logging;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Commands.JsonString;

public class GetJsonStringCommandHandler(
    ILogger<GetJsonStringCommandHandler> logger,
    IMyGovRepository myGovRepository) : IRequestHandler<GetJsonStringCommand, string>
{
    public async Task<string> Handle(GetJsonStringCommand request, CancellationToken cancellationToken)
    {
        var json = await myGovRepository.GetJsonStringAsync(request.TaskId, request.Version);
        return json;
    }
}
