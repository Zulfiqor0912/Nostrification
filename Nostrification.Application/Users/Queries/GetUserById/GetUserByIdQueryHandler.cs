using AutoMapper;
using MediatR;
using Nostrification.Application.Users.Dtos;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(
    IUserRepository userRepository,
    IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.Id);
        var dto = mapper.Map<UserDto>(user);
        return dto;
    }
}
