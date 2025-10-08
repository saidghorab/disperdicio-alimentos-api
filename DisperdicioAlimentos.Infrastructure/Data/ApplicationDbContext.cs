using Microsoft.EntityFrameworkCore;
using DisperdicioAlimentos.Domain.Entities; // Assuming FoodItem will be in Domain.Entities

namespace DisperdicioAlimentos.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity mappings here
        }
    }
}
