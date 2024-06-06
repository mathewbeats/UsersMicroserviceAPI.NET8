using Microsoft.EntityFrameworkCore;
using UsersMicroserviceAPI.Data;
using UsersMicroserviceAPI.Models;
using UsersMicroserviceAPI.Repository.IRepository;

namespace UsersMicroserviceAPI.Repository
{
    public class InterestRepository : IInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public InterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetAllInterestAsync()
        {
            return await _context.Interests.OrderBy(c => c.Id).ThenBy(c => c.Name).ToListAsync();
        }

        public async Task<Interest> GetInterestByUserAsync(int id)
        {
            return await _context.Interests.FirstOrDefaultAsync(c => c.Id == id); // Ajusta la condición si es necesario
        }


        public async Task<bool> UpdateInterestAsync(int id, Interest interest)
        {
            var existingInterest = await _context.Interests.FindAsync(id);
            if (existingInterest == null)
            {
                return false;
            }

            _context.Entry(existingInterest).CurrentValues.SetValues(interest);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var interest = await _context.Interests.FindAsync(id);
                if (interest == null)
                {
                    return false;
                }

                _context.Interests.Remove(interest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (you could use a logging framework here)
                Console.WriteLine(ex);
                return false;
            }
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Interest> CreateInterestAsync(Interest interest)
        {
            await _context.Interests.AddAsync(interest);
            await _context.SaveChangesAsync();

            return interest;
        }
    }
}