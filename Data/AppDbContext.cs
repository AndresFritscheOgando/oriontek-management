using System;
using Microsoft.EntityFrameworkCore;
using Oriontek_management.Models;

namespace Oriontek_management.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Direcciones)
            .WithOne(d => d.Cliente)
            .HasForeignKey(d => d.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
