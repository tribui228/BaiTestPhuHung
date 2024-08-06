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
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
