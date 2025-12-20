using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.StudyTypes.Queries;

public class GetStudyTypesQueriesHandler(IOtherRepository otherRepository) : IRequestHandler<GetStudyTypesQueries, IEnumerable<Domain.Entities.StudyType>>
{
    public async Task<IEnumerable<StudyType>> Handle(GetStudyTypesQueries request, CancellationToken cancellationToken)
    {
        return await otherRepository.GetStudyTypes();
    }
}
