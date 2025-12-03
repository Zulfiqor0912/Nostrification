using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IClaimRepository
{
    Task<IEnumerable<Claim>> GetClaimsAsyn();
}
