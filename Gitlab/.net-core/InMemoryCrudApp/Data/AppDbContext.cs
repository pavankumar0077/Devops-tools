using Microsoft.EntityFrameworkCore;
using InMemoryCrudApp.Models;

namespace InMemoryCrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
