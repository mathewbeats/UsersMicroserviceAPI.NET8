using UsersMicroserviceAPI.Models;

namespace UsersMicroserviceAPI.Repository.IRepository;

public interface IUsersRepository
{
    Task<IEnumerable<UserProfile>> GetAllUsersAsync();

    Task<UserProfile> GetUserIdAsync(int id);

    Task<bool> UpdateUserAsync(int id, UserProfile userProfile);

    Task<UserProfile> CreateUserAsync(UserProfile userProfile);

    Task<bool> DeleteUserAsync(int id);

    Task<bool> SaveChangesAsync();
}