using CineHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CineHub.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<Dvorana> Dvorane { get; set; }
    public DbSet<Film> Filmi { get; set; }
    public DbSet<TerminFilma> TerminiFilma { get; set; }
    public DbSet<Sedez> Sedezi { get; set; }
    public DbSet<Vstopnica> Vstopnice { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Dvorana>().ToTable("Student");
        modelBuilder.Entity<Film>().ToTable("Film");
        modelBuilder.Entity<TerminFilma>().ToTable("TerminFilma");
        modelBuilder.Entity<Sedez>().ToTable("Sedez");
        modelBuilder.Entity<Vstopnica>().ToTable("Vstopnica");
    
    }
}