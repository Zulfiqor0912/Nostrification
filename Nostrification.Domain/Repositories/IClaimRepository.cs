using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IClaimRepository
{
    public Task<IEnumerable<Claim>> GetClaimsAsyn();
    public Task<Claim?> GetClaimByIdAsync(int  id);
}
