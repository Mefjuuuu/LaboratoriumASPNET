using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext {
    public DbSet<ContactEntity?> Type { get; set; }
    public DbSet<OrganizationEntity> OrganizationEntities { get; set; }
    private String DbPath { get; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }

    public AppDbContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity { Id = 101, Name = "Firma 1", NIP = "1234567890", REGON = "0987654321" },
                new OrganizationEntity { Id = 102, Name = "Firma 2", NIP = "0987654321", REGON = "1234567890" },
                new OrganizationEntity { Id = 103, Name = "Firma 3", NIP = "1357924680", REGON = "2468013579" }
            );

        modelBuilder.Entity<Address>()
            .HasData(
                new Address { Id = 1, City = "Warszawa", Street = "Marszałkowska 1", OrganizationEntityId = 101 },
                new Address { Id = 2, City = "Kraków", Street = "Rynek 1", OrganizationEntityId = 102 },
                new Address { Id = 3, City = "Gdańsk", Street = "Długa 1", OrganizationEntityId = 103 }
            );

        modelBuilder.Entity<ContactEntity>()
            .HasOne(c => c.Organization)
            .WithMany(o => o.ContactEntities)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<ContactEntity>().ToTable("contacts").HasData(
            new ContactEntity { Id = 1, Name = "Jan", Surname = "Kowalski", Email = "", PhoneNumber = "123 456 789", BirthDate = new DateOnly(1990, 1, 1), Created = DateTime.Now, OrganizationId = 101 },
            new ContactEntity { Id = 2, Name = "Anna", Surname = "Nowak", Email = "", PhoneNumber = "987 654 321", BirthDate = new DateOnly(1995, 5, 5), Created = DateTime.Now, OrganizationId = 102 },
            new ContactEntity { Id = 3, Name = "Piotr", Surname = "Wiśniewski", Email = "", PhoneNumber = "456 789 123", BirthDate = new DateOnly(2000, 10, 10), Created = DateTime.Now, OrganizationId = 103 }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}