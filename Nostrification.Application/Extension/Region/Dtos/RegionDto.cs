using System.ComponentModel.DataAnnotations.Schema;

namespace Nostrification.Application.Extension.Region.Dtos;

public class RegionDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int Type { get; set; }
    public string? NameUz { get; set; }
    public string? XtbName { get; set; }
    //public virtual Region District { get; set; }
}
