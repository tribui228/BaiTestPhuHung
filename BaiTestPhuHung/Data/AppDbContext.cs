using BaiTestPhuHung.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTestPhuHung.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductID)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .IsUnique();
            
        }
    }
}
