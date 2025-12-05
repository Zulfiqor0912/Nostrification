using Nostrification.Domain.Entities;

namespace Nostrification.Application.Users.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public int? RegionId { get; set; }
    public string Login { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public int? RoleId { get; set; }
    public long? ChatId { get; set; }
    public virtual Region Region { get; set; }
    public virtual Role Role { get; set; }
}
