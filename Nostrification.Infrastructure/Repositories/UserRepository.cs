using Microsoft.EntityFrameworkCore;
using Nostrification.Domain.Entities;
using Nostrification.Domain.Repositories;
using Nostrification.Infrastructure.Persistence;

namespace Nostrification.Infrastructure.Repositories;

public class UserRepository(NostrificationDbContext dbContext) : IUserRepository
{
    public async Task AddOrUpdateUser(User user)
    {
        if (user.Id > 0) dbContext.Users.Update(user);
        else dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var users = await dbContext.Users
            .Include(x => x.Region)
            .Include(x => x.Role)
            .ToListAsync();
        return users;
    }

    public async Task<User?> GetUserById(int id)
    {
        return await dbContext.Users
                .Include(x => x.Region)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
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
