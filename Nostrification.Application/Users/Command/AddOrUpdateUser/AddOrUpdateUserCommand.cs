using MediatR;
using Nostrification.Domain.Entities;

namespace Nostrification.Application.Users.Command.AddOrUpdateUser;

public class AddOrUpdateUserCommand : IRequest
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public virtual Region Region { get; set; }
    public virtual Role Role { get; set; }
}
