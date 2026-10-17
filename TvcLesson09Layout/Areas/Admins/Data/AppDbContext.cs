
using Microsoft.EntityFrameworkCore;
using TvcLesson09Layout.Areas.Admins.Models;

namespace TvcLesson09Layout.Areas.Admins.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<Blog> Blogs => Set<Blog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<Blog>().ToTable("Blog");

            base.OnModelCreating(modelBuilder);
        }
    }
}
