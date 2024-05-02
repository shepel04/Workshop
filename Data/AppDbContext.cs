using Microsoft.EntityFrameworkCore;
using Workshop.Models;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.Windows.Controls;

namespace Workshop.Data
{
    class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1111;Database=workshop;");
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Inventory> inventoryItems { get; set; }
        public DbSet<Finance> finances { get; set; }
        public DbSet<ServiceLog> serviceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Ignore(o => o.TotalPrice);
        }

    }

}

