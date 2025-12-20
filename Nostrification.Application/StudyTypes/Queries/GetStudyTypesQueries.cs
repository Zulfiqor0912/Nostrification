using MediatR;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.StudyTypes.Queries;

public class GetStudyTypesQueries : IRequest<IEnumerable<Domain.Entities.StudyType>>
{
}
