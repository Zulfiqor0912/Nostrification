using MediatR;

namespace Nostrification.Application.Logs.Command.AddOrUpdate;

public class AddOrUpdateLogCommand(int TaskId, string Login, string Action, DateTime DateTime) : IRequest
{
    public int TaskId { get; set; } = TaskId;
    public string Login { get; set; } = Login;
    public string Action { get; set; } = Action;
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
