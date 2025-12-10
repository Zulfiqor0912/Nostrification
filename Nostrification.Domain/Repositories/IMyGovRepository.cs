namespace Nostrification.Domain.Repositories;

public interface IMyGovRepository
{
    Task<bool> SendStatusGetAsync(int taskId, string version = "v2");
}
