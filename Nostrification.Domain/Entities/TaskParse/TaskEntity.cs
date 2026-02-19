namespace Nostrification.Domain.Entities.TaskParse;

public class TaskEntity
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string CurrentNode { get; set; }
    public bool FromOperator { get; set; }
    public string OperatorOrg { get; set; }
    public DateTime OwnCreateDate { get; set; }
}
