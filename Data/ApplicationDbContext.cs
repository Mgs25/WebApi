using Email_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Email_WebAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}