using AutoMapper;
using MediatR;
using Nostrification.Application.Users.Dtos;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(
    IUserRepository userRepository,
    IMapper mapper) : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllUsers();
        var usersDto = mapper.Map<List<UserDto>>(users);
        return usersDto;
    }
}
