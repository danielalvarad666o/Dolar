using Dolar.Views;
using Dolar.DataAccess;
using Dolar.Models;
using System.Linq;
using System.Collections.Generic;

namespace Dolar
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH9ccnZURGRZUEBxWUY=");
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Crear y asegurar que la base de datos exista
            using (var context = new DolarDbContext())
            {
                context.Database.EnsureCreated();  // Esto asegura que la base de datos esté creada

                // Verifica si ya hay monedas en la base de datos
                if (!context.Monedas.Any())
                {
                    System.Diagnostics.Debug.WriteLine("No se encontraron monedas en la base de datos. Agregando nuevas monedas...");
                    // Lista de monedas a insertar si no hay monedas en la base de datos
                    var listaMonedas = new List<Monedas>
                    {
                        new Monedas { Nombre = "Dólar Estadounidense", Img = "us", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Euro", Img = "eu", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Yen Japonés", Img = "jp", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Libra Esterlina", Img = "gb", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Dólar Canadiense", Img = "ca", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Franco Suizo", Img = "ch", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Dólar Australiano", Img = "au", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Yuan Chino", Img = "cn", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Dólar Neozelandés", Img = "nz", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Peso Mexicano", Img = "mx", ActivoDivisa = true, monedabase = true },
                        new Monedas { Nombre = "Rublo Ruso", Img = "ru", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Real Brasileño", Img = "br", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Rupia India", Img = "in", ActivoDivisa = true, monedabase = false },
                        new Monedas { Nombre = "Rand Sudafricano", Img = "za", ActivoDivisa = true, monedabase = false }
                    };

                    // Agregar la lista de monedas a la base de datos
                    context.Monedas.AddRange(listaMonedas);
                    context.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("Monedas agregadas:");
                    foreach (var moneda in context.Monedas.ToList())
                    {
                        System.Diagnostics.Debug.WriteLine($"Nombre: {moneda.Nombre}, MonedaBase: {moneda.monedabase}, Img: {moneda.Img}");
                    }
                }

                // Verifica si ya hay tipos de cambio en la base de datos
                if (!context.TiposCambio.Any())
                {
                    // Recuperar la moneda base (Peso Mexicano)
                    var pesoMexicano = context.Monedas.FirstOrDefault(m => m.Nombre == "Peso Mexicano");

                    if (pesoMexicano != null)
                    {
                        // Lista de tipos de cambio en relación con el peso mexicano
                        var listaTiposCambio = new List<TiposCambio>
                        {
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Dólar Estadounidense").Id, TipoCambioCompra = 20.09m, TipoCambioVenta = 20.15m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Euro").Id, TipoCambioCompra = 23.30m, TipoCambioVenta = 23.40m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Yen Japonés").Id, TipoCambioCompra = 0.19m, TipoCambioVenta = 0.20m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Libra Esterlina").Id, TipoCambioCompra = 27.10m, TipoCambioVenta = 27.20m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Dólar Canadiense").Id, TipoCambioCompra = 15.20m, TipoCambioVenta = 15.30m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Franco Suizo").Id, TipoCambioCompra = 22.00m, TipoCambioVenta = 22.10m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Dólar Australiano").Id, TipoCambioCompra = 14.50m, TipoCambioVenta = 14.60m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Yuan Chino").Id, TipoCambioCompra = 3.10m, TipoCambioVenta = 3.15m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Dólar Neozelandés").Id, TipoCambioCompra = 13.00m, TipoCambioVenta = 13.10m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Rublo Ruso").Id, TipoCambioCompra = 0.25m, TipoCambioVenta = 0.26m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Real Brasileño").Id, TipoCambioCompra = 3.90m, TipoCambioVenta = 3.95m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Rupia India").Id, TipoCambioCompra = 0.27m, TipoCambioVenta = 0.28m },
                            new TiposCambio { MonedaId = context.Monedas.FirstOrDefault(m => m.Nombre == "Rand Sudafricano").Id, TipoCambioCompra = 1.10m, TipoCambioVenta = 1.12m }
                        };

                        // Agregar los tipos de cambio a la base de datos
                        context.TiposCambio.AddRange(listaTiposCambio);
                        context.SaveChanges();
                    }
                }
            }

            // Iniciar la página principal
            MainPage = new NavigationPage(new Inicio());
        }
    }
}
