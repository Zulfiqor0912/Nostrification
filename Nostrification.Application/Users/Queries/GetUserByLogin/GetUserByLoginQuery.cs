using MediatR;
using Nostrification.Application.Users.Dtos;

namespace Nostrification.Application.Users.Queries.GetUserByLogin;

public class GetUserByLoginQuery(string login) : IRequest<UserDto>
{
    public string Login { get; set; } = login;
}
