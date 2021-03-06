using Microsoft.EntityFrameworkCore;
using OrderProcessor.API.Models;

namespace OrderProcessor.API.Data
{
    public class OrderProcessorContext : DbContext
    {
        public OrderProcessorContext(DbContextOptions<OrderProcessorContext> options) : base (options) {}
        
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}