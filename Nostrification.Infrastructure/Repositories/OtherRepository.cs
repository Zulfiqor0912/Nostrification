using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class OtherRepository(NostrificationDbContext dbContext) : IOtherRepository
{
    public async Task AddOrUpdateLog(Log log)
    {
        if (log.Id > 0) dbContext.Logs.Update(log);
        else dbContext.Logs.Add(log);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Region>> GetAllRegions()
    {
        return await dbContext.Regions.ToListAsync();
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await dbContext.Roles.ToListAsync();
    }

    public async Task<IEnumerable<Country>> GetCountries()
    {
        return await dbContext.Countries.ToListAsync();
    }

    public async Task<IEnumerable<Region>> GetDistricts(int parentId)
    {
        return await dbContext.Regions.Where(x => x.ParentId == parentId).ToListAsync();
    }

    public async Task<Region?> GetRegionById(int? id)
    {
        return await dbContext.Regions
             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Role?> GetRoleById(int? id)
    {
        return await dbContext.Roles
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<StudyStep>> GetStudySteps()
    {
        return await dbContext.StudySteps.ToListAsync();
    }

    public async Task<IEnumerable<StudyType>> GetStudyTypes()
    {
        return await dbContext.StudyTypes.ToListAsync();
    }
}
