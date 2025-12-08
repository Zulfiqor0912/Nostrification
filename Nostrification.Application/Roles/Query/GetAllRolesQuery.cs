using MediatR;
using Nostrification.Application.Roles.Dtos;

namespace Nostrification.Application.Roles.Query;

public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
}
