using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmaM.Infrastructure.Data.Models;
using PharmaM.Infrastructure.Data.SeedDb;

namespace PharmaM.Data
{
    public class PharmaMDbContext : IdentityDbContext<ApplicationUser>
    {
        public PharmaMDbContext(DbContextOptions<PharmaMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderItem>()
                .HasKey(oi => new
                {
                    oi.OrderId,
                    oi.ProductId
                });

            builder.Entity<Category>()
                .HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Medicines"
                },
                 new Category()
                 {
                     Id = 2,
                     Name = "Food supplements"
                 },
                new Category()
                {
                    Id = 3,
                    Name = "Homeopathy"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Diet"
                },
                 new Category()
                 {
                     Id = 5,
                     Name = "Cosmetics"
                 },
                new Category()
                {
                    Id = 6,
                    Name = "Appliances"
                });

            base.OnModelCreating(builder);

            new SeedData(builder).SeedProduct();
            new SeedData(builder).SeedUserAndRole();


        }
    }
}