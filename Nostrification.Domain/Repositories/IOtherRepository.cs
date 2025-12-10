using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IOtherRepository
{
    public Task<IEnumerable<Region>> GetAllRegions();
    public Task<Region?> GetRegionById(int? id);

    public Task<IEnumerable<Role>> GetAllRoles();
    public Task<Role?> GetRoleById(int? id);
    public Task AddOrUpdateLog(Log log);
}
