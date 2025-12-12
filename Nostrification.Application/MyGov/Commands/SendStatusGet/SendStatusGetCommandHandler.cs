using AutoMapper;
using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Queries.SendStatus;

public class SendStatusGetCommandHandler(
    IMapper mapper,
    IMyGovRepository myGovRepository) : IRequestHandler<SendStatusGetCommand, bool>
{
    public async Task<bool> Handle(SendStatusGetCommand request, CancellationToken cancellationToken)
    {
        return await myGovRepository.SendStatusGetAsync(request.TaskId, request.Version);
    }
}
