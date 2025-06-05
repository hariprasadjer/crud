using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Data
{
    // EF Core database context used for CRUD operations
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
    }
}
