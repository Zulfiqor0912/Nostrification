using AutoMapper;
using MediatR;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;

namespace Nostrification.Application.Users.Command.AddOrUpdateUser;

public class AddOrUpdateCommandHandler(
    IUserRepository userRepository,
    IOtherRepository otherRepository,
    IMapper mapper) : IRequestHandler<AddOrUpdateUserCommand>
{
    public async Task Handle(AddOrUpdateUserCommand request, CancellationToken cancellationToken)
    {
        var region = await otherRepository.GetRegionById(request.RegionId);
        var role = await otherRepository.GetRoleById(request.RoleId);

        var user = mapper.Map<User>(request);

        user.Region = region;
        user.Role = role;

        await userRepository.AddOrUpdateUser(user);
    }
}
