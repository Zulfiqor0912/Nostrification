using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.StudyStep.Queries;

public class GetStudyStepsQueryHandler(IOtherRepository otherRepository) : IRequestHandler<GetStudyStepsQuery, IEnumerable<Domain.Entities.StudyStep>>
{
    public async Task<IEnumerable<Domain.Entities.StudyStep>> Handle(GetStudyStepsQuery request, CancellationToken cancellationToken)
    {
        return await otherRepository.GetStudySteps();   
    }
}
