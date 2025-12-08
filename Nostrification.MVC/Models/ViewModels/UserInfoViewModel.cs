using Nostrification.Domain.Entities;

namespace Nostrification.MVC.Models.ViewModels;

public class UserInfoViewModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public int RegionId { get; set; }
    public int RoleId { get; set; }
}
