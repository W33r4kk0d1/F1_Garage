using F1_Garage.Models;
using F1_Models;
using Microsoft.EntityFrameworkCore;

namespace F1_Garage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    Id = 1,
                    Name = "Pirelli",
                    DisplayOrder = 1,
                    Description = "Official tyre supplier for Formula 1..."
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "McLaren Applied",
                    DisplayOrder = 2,
                    Description = "Develops advanced electronic control systems..."
                },
                new Manufacturer
                {
                    Id = 3,
                    Name = "Brembo",
                    DisplayOrder = 3,
                    Description = "World-leading braking systems manufacturer..."
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "ECU"
                },
                new Category
                {
                    Id = 2,
                    Name = "Tyres"
                }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Name = "2JZ ECU",
                    Description = "High performance ECU for racing engines",
                    Price = 250,
                    Image = "ecu.png",
                    CategoryId = 1
                },
                new Products
                {
                    Id = 2,
                    Name = "RB26 ECU",
                    Description = "Advanced ECU tuning system",
                    Price = 300,
                    Image = "ecu2.png",
                    CategoryId = 1
                },
                new Products
                {
                    Id = 3,
                    Name = "Pirelli Soft Tyres",
                    Description = "High grip racing tyres",
                    Price = 400,
                    Image = "tyres.png",
                    CategoryId = 2
                }
            );
        }
    }
}