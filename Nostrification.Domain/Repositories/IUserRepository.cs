using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserByLoginAsync(string login);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task<User> GetUserById(User user);
    public Task AddOrUpdateUser(User user);
}
