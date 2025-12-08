using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class OtherRepository(NostrificationDbContext dbContext) : IOtherRepository
{
    public async Task<IEnumerable<Region>> GetAllRegions()
    {
        return await dbContext.Regions.ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await dbContext.Roles.ToListAsync();
    }

    public async Task<Region?> GetRegionById(int id)
    {
        return await dbContext.Regions
             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Role?> GetRoleById(int id)
    {
        return await dbContext.Roles
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
