using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Models;

namespace VerstaTestTask.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().Property(o => o.Id).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.SenderCity).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.SenderAdress).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.PickUpDate).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.RecieverAdress).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.RecieverCity).IsRequired();
        modelBuilder.Entity<Order>().Property(o => o.WeightInGrams).IsRequired();
    }
}
