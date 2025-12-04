using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class ClaimRepository(NostrificationDbContext dbContext) : IClaimRepository
{
    public async Task<IEnumerable<Claim>> GetClaimsAsyn()
    {
        var claims = await dbContext.Claims
            .Where(c => c.StatusId != 5) // soft delete 
            .Include(x => x.Region)
            .Include(x => x.ClaimStatus)
            .ToListAsync();
        return claims;
    }
}
