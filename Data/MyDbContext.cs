using CORS.Sample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CORS.Sample.Data {
  public class MyDbContext : DbContext {
    public MyDbContext (DbContextOptions<MyDbContext> options) : base (options) {
      Database.EnsureCreated();
     }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Entity<Product> (b => {
        b.HasKey (_ => _.ProductId);
        b.Property (_ => _.ProductId).ValueGeneratedOnAdd ();
      });
    }
  }
}