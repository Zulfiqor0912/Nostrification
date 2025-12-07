using MediatR;
using Nostrification.Application.Users.Dtos;

namespace Nostrification.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<UserDto>
{
}
