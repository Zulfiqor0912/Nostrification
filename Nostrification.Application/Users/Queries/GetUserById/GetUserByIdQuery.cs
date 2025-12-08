using MediatR;
using Nostrification.Application.Users.Dtos;

namespace Nostrification.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery(int Id) : IRequest<UserDto>
{
    public int Id { get; set; } = Id;
}
