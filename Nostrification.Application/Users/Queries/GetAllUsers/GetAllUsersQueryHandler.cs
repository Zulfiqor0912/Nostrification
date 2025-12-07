using MediatR;
using Nostrification.Application.Users.Dtos;

namespace Nostrification.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserDto>
{
}
