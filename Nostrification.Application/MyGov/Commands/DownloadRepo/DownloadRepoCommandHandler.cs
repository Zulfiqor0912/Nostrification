using MediatR;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.MyGov.Commands.DownloadRepo;

public class DownloadRepoCommandHandler(IMyGovRepository myGovRepository) : IRequestHandler<DownloadRepoCommand, (byte[] fileBytes, string fileName)>
{
    public async Task<(byte[] fileBytes, string fileName)> Handle(DownloadRepoCommand request, CancellationToken cancellationToken)
    {
        return await myGovRepository.GetRepoFileAsunc(request.Id, request.Version);
    }
}
