// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using InternetShop.Models;

namespace InternetShop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InternetShopDb;Trusted_Connection=True;");
        }
    }
}
