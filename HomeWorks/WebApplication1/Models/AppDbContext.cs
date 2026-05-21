using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Record> Records { get; set; } = null!;
        public DbSet<GreenStore> GreenStores { get; set; } = null!;
    }
}
