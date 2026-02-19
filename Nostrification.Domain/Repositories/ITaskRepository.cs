using Newtonsoft.Json.Linq;
using Nostrification.Domain.Entities.TaskParse;

namespace Nostrification.Domain.Repositories;

public interface ITaskRepository
{
    public Task<(TaskEntity Task, JToken Entities)> ParseAsync(string json, int taskId);
    public Task<(object taskEntity, object entities)> ParseAsync(Task<string> json, int taskId);
}
