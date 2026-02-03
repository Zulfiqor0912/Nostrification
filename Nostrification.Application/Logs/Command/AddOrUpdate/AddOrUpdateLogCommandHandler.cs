using AutoMapper;
using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Logs.Command.AddOrUpdate;

public class AddOrUpdateLogCommandHandler(
    IMapper mapper,
    IOtherRepository otherRepository) : IRequestHandler<AddOrUpdateLogCommand>
{
    public async Task Handle(AddOrUpdateLogCommand request, CancellationToken cancellationToken)
    {
        var log = mapper.Map<Log>(request);
        await otherRepository.AddOrUpdateLog(log);
    }
}
