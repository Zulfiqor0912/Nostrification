using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;
using Nostrification.Infrastructure.Repositories;

namespace Nostrification.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("LocalConnectionString");
        services
            .AddDbContext<NostrificationDbContext>(options =>
                options.UseSqlServer(connectionstring)
                .EnableSensitiveDataLogging());

        services.AddScoped<IClaimRepository, ClaimRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
