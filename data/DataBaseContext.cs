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
        //add seed data 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Tunisia", ShortName = "TN" },
                new Country { Id = 2, Name = "Russia", ShortName = "RU" },
                new Country { Id = 3, Name = "USA", ShortName = "US" },
                new Country { Id = 4, Name = "Ukraine", ShortName = "UA" }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel1", Adress = "Adress1", Rating = "5", CountryId = 1 },
                new Hotel { Id = 2, Name = "Hotel2", Adress = "Adress2", Rating = "4", CountryId = 2 },
                new Hotel { Id = 3, Name = "Hotel3", Adress = "Adress3", Rating = "3", CountryId = 3 },
                new Hotel { Id = 4, Name = "Hotel4", Adress = "Adress4", Rating = "2", CountryId = 4 }
            );
        }
    }
}