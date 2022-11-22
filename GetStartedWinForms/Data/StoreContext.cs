using GetStartedWinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace GetStartedWinForms.Data;

public class StoreContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=orders.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, OrderDate = new DateTime(2022,11,21), DeliveredDate = new DateTime(2022, 11, 23) }, 
            new Order { Id = 2, OrderDate = new DateTime(2022, 11, 21), DeliveredDate = new DateTime(2022, 11, 26) },
            new Order { Id = 3, OrderDate = new DateTime(2022, 11, 21), DeliveredDate = new DateTime(2022, 11, 27) },
            new Order { Id = 4, OrderDate = new DateTime(2022, 11, 21), DeliveredDate = new DateTime(2022, 11, 19) }
        );
    }
}