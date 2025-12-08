using AutoMapper;
using MediatR;
using Nostrification.Application.Roles.Dtos;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Roles.Query;

public class GetAllRolesQueryHandler(
    IOtherRepository otherRepository,
    IMapper mapper) : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await otherRepository.GetAllRoles();
        var dto = mapper.Map<IEnumerable<RoleDto>>(roles);
        return dto;
    }
}
