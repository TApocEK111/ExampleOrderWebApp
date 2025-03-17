using Microsoft.EntityFrameworkCore;

namespace VerstaTestTask.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }


}
