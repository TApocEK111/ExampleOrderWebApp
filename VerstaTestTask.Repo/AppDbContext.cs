using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Domain;

namespace VerstaTestTask.Repo;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
