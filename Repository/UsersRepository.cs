using Microsoft.EntityFrameworkCore;
using UsersMicroserviceAPI.Data;
using UsersMicroserviceAPI.Models;
using UsersMicroserviceAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UsersMicroserviceAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UsersRepository> _logger;

        public UsersRepository(ApplicationDbContext context, ILogger<UsersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<UserProfile>> GetAllUsersAsync()
        {
            try
            {
                return await _context.UserProfiles.OrderBy(c => c.Id).ThenBy(c => c.UserName).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                throw;
            }
        }

        public async Task<UserProfile> GetUserIdAsync(int id)
        {
            try
            {
                return await _context.UserProfiles.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user with ID {id}");
                throw;
            }
        }

        public async Task<bool> UpdateUserAsync(int id, UserProfile userProfile)
        {
            try
            {
                var existingUser = await _context.UserProfiles.FindAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning($"User with ID {id} not found for update");
                    return false;
                }

                _context.Entry(existingUser).CurrentValues.SetValues(userProfile);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating user with ID {id}");
                throw;
            }
        }

        public async Task<UserProfile> CreateUserAsync(UserProfile userProfile)
        {
            try
            {
                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();
                return userProfile;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.UserProfiles.FindAsync(id);
                if (user == null)
                {
                    _logger.LogWarning($"User with ID {id} not found for deletion");
                    return false;
                }

                _context.UserProfiles.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting user with ID {id}");
                throw;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes to the database");
                throw;
            }
        }
    }
}
