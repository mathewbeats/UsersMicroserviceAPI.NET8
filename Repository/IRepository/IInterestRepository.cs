using UsersMicroserviceAPI.Models;

namespace UsersMicroserviceAPI.Repository.IRepository;

public interface IInterestRepository
{
    Task<IEnumerable<Interest>> GetAllInterestAsync();

    Task<Interest> GetInterestByUserAsync(int id);

    Task<bool> UpdateInterestAsync(int id, Interest interest);

    Task<bool> DeleteAsync(int id);

    Task<bool> SaveChangesAsync();

    Task<Interest> CreateInterestAsync(Interest interest);
}