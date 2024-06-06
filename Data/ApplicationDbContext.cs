using Microsoft.EntityFrameworkCore;
using UsersMicroserviceAPI.Models;

namespace UsersMicroserviceAPI.Data;

public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<UserProfile> UserProfiles { get; set; }
    
    public DbSet<Photo> Photos { get; set; }
    
    public DbSet<Interest> Interests { get; set; }
    
    
    
}