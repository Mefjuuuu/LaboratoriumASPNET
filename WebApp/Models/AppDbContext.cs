using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext {
    public DbSet<ContactEntity?> Type { get; set; }
    private String DbPath { get; set; }

    public AppDbContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ContactEntity>().ToTable("contacts").HasData(
            new ContactEntity() {
                Id = 1, 
                Name = "Jan",
                Surname = "Kowalski",
                Email = "",
                PhoneNumber = "123 456 789",
                BirthDate = new DateOnly(1990, 1, 1),
                Created = DateTime.Now
            },
            new ContactEntity() {
                Id = 2,
                Name = "Anna",
                Surname = "Nowak",
                Email = "", 
                PhoneNumber = "987 654 321",
                BirthDate = new DateOnly(1995, 5, 5),
                Created = DateTime.Now
            }, new ContactEntity() {
                Id = 3, 
                Name = "Piotr", 
                Surname = "Wiśniewski",
                Email = "", 
                PhoneNumber = "456 789 123",
                BirthDate = new DateOnly(2000, 10, 10),
                Created = DateTime.Now
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}