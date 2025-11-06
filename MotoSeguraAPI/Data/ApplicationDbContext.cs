using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
    }
}