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
                new Manufacturer { Id = 1, Name = "Pirelli", DisplayOrder = 1, Description = "Official tyre supplier for Formula 1, " +
                "providing high-performance compounds designed for speed, durability, and race strategy."},
                new Manufacturer { Id = 2, Name = "McLaren Applied", DisplayOrder = 2, Description= "Develops advanced electronic control " +
                "systems and telemetry solutions used across Formula 1 for precision performance and data analysis." },
                new Manufacturer { Id = 3, Name = "Brembo", DisplayOrder = 3, Description = "World-leading manufacturer of high-performance " +
                "braking systems, delivering reliability and extreme stopping power in Formula 1." }
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
