namespace Nostrification.Domain.Entities.TaskParse;

public class ParsedTaskResult
{
    public TaskEntity Task { get; set; }
    public Dictionary<string, object> Entities { get; set; }
}
