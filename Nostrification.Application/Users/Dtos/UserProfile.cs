using AutoMapper;
using Nostrification.Application.Users.Command.AddOrUpdateUser;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Users.Dtos;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(does => does.Region, opt => opt.MapFrom(src => src.Region))
            .ForMember(does => does.Role, opt => opt.MapFrom(src => src.Role));

        CreateMap<AddOrUpdateUserCommand, User>();
    }
}
