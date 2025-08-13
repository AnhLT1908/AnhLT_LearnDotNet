using CSharpLifeCycle.Models; 
using Microsoft.EntityFrameworkCore;

namespace CSharpLifeCycle.Data 
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<User> Users => Set<User>(); 
        public DbSet<Product> Products => Set<Product>(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}