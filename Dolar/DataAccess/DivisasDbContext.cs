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
                entity.Property(e => e.TipoCambioVenta).IsRequired();
                entity.Property(e => e.TipoCambioCompra).IsRequired();

            });

            modelBuilder.Entity<Monedas>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).HasMaxLength(50);
                entity.Property(e => e.Img).HasMaxLength(2); // Nueva propiedad img
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

        // ================================== CRUD para Monedas ================================== //

        // Método para Leer (Read) todas las monedas
        public async Task<List<Monedas>> GetAllMonedas()
        {
            return await Monedas.ToListAsync();
        }

        // Método para Leer (Read) una moneda por su Id
        public async Task<Monedas> GetMonedaById(int id)
        {
            return await Monedas.FindAsync(id);
        }

        // Método para Crear (Create) una nueva moneda


        //ejemplo por daniel crear

        //var nuevaMoneda = new Monedas
        //  {
        //    Nombre = "Dólar",
        //    img = "US",
        //    ActivoDivisa = true,
        //    monedabase = true
        //   };

        //bool resultado = await context.CreateMoneda(nuevaMoneda);

        //  if (resultado ==true){
        //         sr creo}

        public async Task<bool> CreateMoneda(Monedas nuevaMoneda)
        {
            Monedas.Add(nuevaMoneda);
            await SaveChangesAsync();
            return true; // Si se agrega correctamente
        }

        // Método para Eliminar (Delete) una moneda
        public async Task<bool> DeleteMoneda(int id)
        {
            var moneda = await Monedas.FindAsync(id);
            if (moneda != null)
            {
                Monedas.Remove(moneda);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra la moneda
        }

        // Método para Actualizar (Update) una moneda
        public async Task<bool> UpdateMoneda(int id, Monedas updatedMoneda)
        {
            var moneda = await Monedas.FindAsync(id);
            if (moneda != null)
            {
                moneda.Nombre = updatedMoneda.Nombre;
                moneda.Img = updatedMoneda.Img;
                moneda.ActivoDivisa = updatedMoneda.ActivoDivisa;
                moneda.monedabase = updatedMoneda.monedabase;

                Monedas.Update(moneda);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra la moneda
        }

        // ================================== CRUD para TiposCambio ================================== //

        // Método para Leer (Read) todos los tipos de cambio
        public async Task<List<TiposCambio>> GetAllTiposCambio()
        {
            return await TiposCambio.ToListAsync();
        }

        // Método para Leer (Read) un tipo de cambio por su Id
        public async Task<TiposCambio> GetTipoCambioById(int id)
        {
            return await TiposCambio.FindAsync(id);
        }

        // Método para Crear (Create) un nuevo tipo de cambio


        //var nuevoTipoCambio = new TiposCambio
        //{
        //    MonedaId = 1, // ID de la moneda asociada
        //    TipoCambioCompra = 19.50m,
        //    TipoCambioVenta = 20.00m
        //};

        //bool resultado = await context.CreateTipoCambio(nuevoTipoCambio);



        public async Task<bool> CreateTipoCambio(TiposCambio nuevoTipoCambio)
        {
            TiposCambio.Add(nuevoTipoCambio);
            await SaveChangesAsync();
            return true; // Si se agrega correctamente
        }

        // Método para Eliminar (Delete) un tipo de cambio
        public async Task<bool> DeleteTipoCambio(int id)
        {
            var tipoCambio = await TiposCambio.FindAsync(id);
            if (tipoCambio != null)
            {
                TiposCambio.Remove(tipoCambio);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra el tipo de cambio
        }

        // Método para Actualizar (Update) un tipo de cambio
        public async Task<bool> UpdateTipoCambio(int id, TiposCambio updatedTipoCambio)
        {
            var tipoCambio = await TiposCambio.FindAsync(id);
            if (tipoCambio != null)
            {
                tipoCambio.TipoCambioCompra = updatedTipoCambio.TipoCambioCompra;
                tipoCambio.TipoCambioVenta = updatedTipoCambio.TipoCambioVenta;

                TiposCambio.Update(tipoCambio);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra el tipo de cambio
        }

        // ================= CRUD para Empresas ================= //

        // Método para Leer (Read) todas las empresas
        public async Task<List<Empresas>> GetAllEmpresas()
        {
            return await Empresas.ToListAsync();
        }

        // Método para Crear (Create) una nueva empresa

        //var nuevaEmpresa = new Empresas
        //{
        //    Nombre = "Empresa Ejemplo",
        //    Direccion = "Av. Falsa 123",
        //    Estado = "CDMX"
        //};

        //bool resultado = await context.CreateEmpresa(nuevaEmpresa);

        public async Task<bool> CreateEmpresa(Empresas nuevaEmpresa)
        {
            Empresas.Add(nuevaEmpresa);
            await SaveChangesAsync();
            return true; // Si se agrega correctamente
        }

        // Método para Eliminar (Delete) una empresa
        public async Task<bool> DeleteEmpresa(int id)
        {
            var empresa = await Empresas.FindAsync(id);
            if (empresa != null)
            {
                Empresas.Remove(empresa);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra la empresa
        }

        // Método para Actualizar (Update) una empresa
        public async Task<bool> UpdateEmpresa(int id, Empresas updatedEmpresa)
        {
            var empresa = await Empresas.FindAsync(id);
            if (empresa != null)
            {
                empresa.Nombre = updatedEmpresa.Nombre;
                empresa.Direccion = updatedEmpresa.Direccion;
                empresa.Estado = updatedEmpresa.Estado;

                Empresas.Update(empresa);
                await SaveChangesAsync();
                return true;
            }
            return false; // Si no encuentra la empresa
        }
    }
}

