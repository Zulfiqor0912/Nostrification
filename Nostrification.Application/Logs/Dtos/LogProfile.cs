using AutoMapper;
using Nostrification.Application.Logs.Command.AddOrUpdate;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Logs.Dtos;

internal class LogProfile : Profile
{
    public LogProfile() 
    {
        CreateMap<AddOrUpdateLogCommand, Log>();
    }
}
