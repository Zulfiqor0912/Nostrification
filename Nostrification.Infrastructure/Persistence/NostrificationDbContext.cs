using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;

namespace Nostrification.Infrastructure.Persistence;

public class NostrificationDbContext(DbContextOptions<NostrificationDbContext> options)
    : DbContext(options)
{
    public DbSet<Claim> Claims { get; set; }
    public DbSet<ClaimerType> ClaimerTypes { get; set; }
    public DbSet<ClaimStatus> ClaimStatus { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<StudyStep> StudySteps { get; set; }
    public DbSet<StudyType> StudyTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


    }
}
