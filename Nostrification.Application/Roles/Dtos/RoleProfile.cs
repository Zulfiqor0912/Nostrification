using AutoMapper;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Roles.Dtos;

public class RoleProfile : Profile
{
    public RoleProfile() 
    {
        CreateMap<RoleDto, Role>();
    }
}
