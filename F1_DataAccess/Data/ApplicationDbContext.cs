using F1_Garage.Models;
using F1_Models;
using Microsoft.EntityFrameworkCore;

namespace F1_Garage.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Manufacturers
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Pirelli", DisplayOrder = 1 },
                new Manufacturer { Id = 2, Name = "McLaren Applied", DisplayOrder = 2},
                new Manufacturer { Id = 3, Name = "Brembo", DisplayOrder = 3}
                );
        }

        // Tyres
        public DbSet<Tyres> Tyres { get; set; }

        // ECU
        public DbSet<ECU> ECUs { get; set; }

        // Users for Login
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // Shopping Cart
        public DbSet<CartItem> CartItems { get; set; }
    }
}
