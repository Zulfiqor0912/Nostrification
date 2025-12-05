using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserByLoginAsync(string login);
}
