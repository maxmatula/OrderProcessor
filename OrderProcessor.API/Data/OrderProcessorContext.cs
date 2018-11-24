using Microsoft.EntityFrameworkCore;
using OrderProcessor.API.Models;

namespace OrderProcessor.API.Data
{
    public class OrderProcessorContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}