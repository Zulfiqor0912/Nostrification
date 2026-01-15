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
            var existing = await dbContext.Claims.FirstAsync(x => x.Id == claim.Id);
            //existing.StatusId = claim.StatusId;
            //existing.AnswerComment = claim.AnswerComment;
            //existing.AnswerDate = claim.AnswerDate;
            //existing.UpdateDate = claim.UpdateDate;

            //dbContext.Entry(excisting).CurrentValues.SetValues(claim);

            existing.StatusId = claim.StatusId;
            existing.AnswerComment = claim.AnswerComment;
            existing.AnswerDate = claim.AnswerDate;
            existing.UpdateDate = claim.UpdateDate;
            existing.AnswerFile = claim.AnswerFile;
            existing.refer_registr_numb = claim.refer_registr_numb;
            existing.name_institution_gos = claim.name_institution_gos;
            existing.graduation_year = claim.graduation_year;
            existing.country_educated_gos = claim.country_educated_gos;
            existing.series_doc_diploma_gos = claim.series_doc_diploma_gos;
            existing.doc_number_diploma_gos = claim.doc_number_diploma_gos;
            existing.head_organization = claim.head_organization;
            existing.name_head_education = claim.name_head_education;
            existing.registry_number = claim.registry_number;
            existing.rejection_reason = claim.rejection_reason;
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
