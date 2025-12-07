using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class UserRepository(NostrificationDbContext dbContext) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await dbContext.Users
            .Include(x => x.Region)
            .Include(x => x.Role)
            .ToListAsync();
        return users;
    }

    public async Task<User?> GetUserByLoginAsync(string login)
    {
        var user = await dbContext.Users
            .Include(x => x.Region)
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Login == login);
        return user;
    }
}
