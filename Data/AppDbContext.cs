using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Models;

namespace LibreriaDigital.Data {
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Review> Reviews { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Review>()
        .HasOne(r => r.User)
        .WithMany()
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Restrict); // <-- 🔧 NO CASCADE

    modelBuilder.Entity<Review>()
        .HasOne(r => r.Book)
        .WithMany(b => b.Reviews)
        .HasForeignKey(r => r.BookId)
        .OnDelete(DeleteBehavior.Cascade); // <-- SOLO UNA CASCADE
}

  }
}
