using System.ComponentModel.DataAnnotations.Schema;

namespace Nostrification.Domain.Entities;

public class Region
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int Type { get; set; }
    public string? NameUz { get; set; }
    public string? XtbName { get; set; }
    [ForeignKey("Id")]
    public virtual Region District { get; set; }
}