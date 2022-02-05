using Microsoft.EntityFrameworkCore;

namespace MyAPIProject.data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        // public DbSet<User> Users { get; set; }
    }
}