using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Nostrification.Application.Users.Dtos;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Exceptions;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Users.Queries.GetUserByLogin;

public class GetUserByLoginQueryHandler(
    ILogger<GetUserByLoginQueryHandler> logger,
    IMapper mapper,
    IUserRepository userRepository) : IRequestHandler<GetUserByLoginQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
    {
            var user = await userRepository.GetUserByLoginAsync(request.Login)
                ?? throw new NotFoundException(nameof(UserDto), request.Login);
        if (user == null)
        {
            user = new User
            {
                Fullname = "Developer",
                Login = request.Login,
                PhoneNumber = "+90xxxxxxx",
                RoleId = 1,
                RegionId = -1
            };
            //await userRepository.AddOrUpdateUserAsync(user);
        }
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
    }
}
