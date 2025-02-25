using Microsoft.EntityFrameworkCore;
using MyBook2.Models;

namespace MyBook2.Data;

public class AppDbContext:DbContext
{
    public DbSet<Book> Books { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
    }
}