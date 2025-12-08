using MediatR;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Users.Command.AddOrUpdateUser;

public class AddOrUpdateUserCommand(int id, string login, string fullname, string phonenumber, int regionId, int roleId) : IRequest
{
    public int Id { get; set; } = id;
    public string Login { get; set; } = login;
    public string Fullname { get; set; } = fullname;
    public string PhoneNumber { get; set; } = phonenumber;
    public int RegionId { get; set; } = regionId;
    public int RoleId { get; set; } = roleId;
}
