using MediatR;

namespace Nostrification.Application.StudyStep.Queries;

public class GetStudyStepsQuery : IRequest<IEnumerable<Domain.Entities.StudyStep>>
{
}
