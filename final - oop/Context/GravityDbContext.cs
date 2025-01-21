using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Context;

public partial class GravityDbContext : DbContext
{
    public GravityDbContext()
    {
    }

    public GravityDbContext(DbContextOptions<GravityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> addresses { get; set; }

    public virtual DbSet<Address_status> address_statuses { get; set; }

    public virtual DbSet<Author> authors { get; set; }

    public virtual DbSet<Book> books { get; set; }

    public virtual DbSet<Book_language> book_languages { get; set; }

    public virtual DbSet<Country> countries { get; set; }

    public virtual DbSet<Cust_order> cust_orders { get; set; }

    public virtual DbSet<Customer> customers { get; set; }

    public virtual DbSet<Customer_address> customer_addresses { get; set; }

    public virtual DbSet<Order_history> order_histories { get; set; }

    public virtual DbSet<Order_line> order_lines { get; set; }

    public virtual DbSet<Order_status> order_statuses { get; set; }

    public virtual DbSet<Publisher> publishers { get; set; }

    public virtual DbSet<Shipping_method> shipping_methods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=c:\\data\\gravity.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.address_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Address_status>(entity =>
        {
            entity.Property(e => e.status_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.author_id).ValueGeneratedNever();
            entity.Property(e => e.author_name).HasDefaultValueSql("NULL");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.book_id).ValueGeneratedNever();

            entity.HasMany(d => d.authors).WithMany(p => p.books)
                .UsingEntity<Dictionary<string, object>>(
                    "book_author",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("book_id", "author_id");
                        j.ToTable("book_author");
                    });
        });

        modelBuilder.Entity<Book_language>(entity =>
        {
            entity.Property(e => e.language_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.country_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Cust_order>(entity =>
        {
            entity.Property(e => e.order_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.customer_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer_address>(entity =>
        {
            entity.HasOne(d => d.address).WithMany(p => p.customer_addresses).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.customer).WithMany(p => p.customer_addresses).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Order_history>(entity =>
        {
            entity.Property(e => e.history_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order_line>(entity =>
        {
            entity.Property(e => e.line_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order_status>(entity =>
        {
            entity.Property(e => e.status_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.publisher_id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Shipping_method>(entity =>
        {
            entity.Property(e => e.method_id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
