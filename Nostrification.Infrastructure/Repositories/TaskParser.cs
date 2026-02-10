using Newtonsoft.Json.Linq;
using Nostrification.Domain.Entities.TaskParse;
using Nostrification.Domain.Repositories;

namespace Nostrification.Infrastructure.Repositories;

public class TaskParser : ITaskRepository
{

    Task<(TaskEntity Task, JToken Entities)> ITaskRepository.ParseAsync(string json, int taskId)
    {
        var root = JObject.Parse(json);
        var taskJson = root["task"];
        var entities = root["entities"]?["SecondaryIssuedForeign"];

        var task = new TaskEntity
        {
            TaskId = taskId,
            Status = taskJson["status"]?.Value<string>(),
            CreateDate = taskJson["created_date"]?.Value<DateTime>() ?? DateTime.MinValue,
            UpdateDate = taskJson["last_update"]?.Value<DateTime>() ?? DateTime.MinValue,
            CurrentNode = taskJson["current_node"]?.Value<string>(),
            FromOperator = taskJson["from_operator"]?.Value<bool>() ?? false,
            OperatorOrg = taskJson["operator_org"]?.Value<string>(),
            OwnCreateDate = DateTime.Now
        };
    }
}
