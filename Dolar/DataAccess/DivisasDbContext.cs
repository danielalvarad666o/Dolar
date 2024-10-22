using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dolar.Models;
using Microsoft.EntityFrameworkCore;

namespace Dolar.DataAccess
{
    public class DolarDbContext : DbContext
    {
        public DbSet<TiposCambio> TiposCambio { get; set; }
        public DbSet<Monedas> Monedas { get; set; }
        public DbSet<Empresas> Empresas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = "Dolar.db";  // Ajusta esta ruta según la ubicación donde desees almacenar tu base de datos.
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposCambio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

                entity.HasOne(e => e.Moneda)
                      .WithMany()
                      .HasForeignKey(e => e.MonedaId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Monedas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).HasMaxLength(50);
                entity.Property(e => e.img).HasMaxLength(2); // Nueva propiedad img
                entity.Property(e => e.ActivoDivisa).IsRequired();
                entity.Property(e => e.monedabase).IsRequired(); // Nueva propiedad monedabase
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).HasMaxLength(50);
                entity.Property(e => e.Direccion).HasMaxLength(50);
                entity.Property(e => e.Estado).HasMaxLength(50);
            });
        }



    }
}
