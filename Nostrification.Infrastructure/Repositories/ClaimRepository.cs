using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class ClaimRepository(NostrificationDbContext dbContext) : IClaimRepository
{
    public async Task AddOrUpdateClaimAsync(Claim claim)
    {
        if (claim.Id > 0)
        {
            var excisting = await dbContext.Claims.FirstAsync(x => x.Id == claim.Id);
            excisting.StatusId = claim.StatusId;
            excisting.AnswerComment = claim.AnswerComment;
            excisting.AnswerDate = claim.AnswerDate;
            excisting.UpdateDate = claim.UpdateDate;
        } 
        else await dbContext.Claims.AddAsync(claim);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Claim?> GetClaimByIdAsync(int id)
    {
        return await dbContext.Claims
            .Include(x => x.ClaimerType)
            .Include(x => x.ClaimStatus)
            .Include(x => x.Country)
            .Include(x => x.Region)
            .Include(x => x.District)
            .Include(x => x.StudyType)
            .Include(x => x.StudyStep)
            .FirstOrDefaultAsync(x => x.TaskId == id);
    }

    public async Task<IEnumerable<Claim>> GetClaimsAsyn()
    {
        var claims = await dbContext.Claims 
            .Include(x => x.Region)
            .Include(x => x.ClaimStatus)
            .Include(x => x.ClaimerType)
            .ToListAsync();
        return claims;
    }
}
