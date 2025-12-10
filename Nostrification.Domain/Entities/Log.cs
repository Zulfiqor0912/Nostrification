namespace Nostrification.Domain.Entities;

public class Log
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Login { get; set; }
    public string Action { get; set; }
    public DateTime CreateDate { get; set; }
}
