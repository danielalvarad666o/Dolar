﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dolar.Models;
using Dolar.ConexionDB;
using Microsoft.EntityFrameworkCore;


namespace Dolar.DataAccess
{


     public class DolarDbContext : DbContext
    {
        public DbSet<Configuracion> Configuraciones { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<TiposCambio> TiposCambio { get; set; }
        public DbSet<Monedas> Monedas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = "Dolar.db";  // Ajusta esta ruta según la ubicación donde desees almacenar tu base de datos.
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

                entity.HasOne(e => e.TipoCambioBase)
                      .WithOne()
                      .HasForeignKey<Configuracion>(e => e.TipoCambioBaseId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Operaciones>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();

                entity.HasOne(e => e.Configuracion)
                      .WithMany()
                      .HasForeignKey(e => e.ConfiguracionId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

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
                entity.Property(col => col.Id).IsRequired().ValueGeneratedOnAdd();
            });
        }
    }
    }
