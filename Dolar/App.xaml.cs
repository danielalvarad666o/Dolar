

using Dolar.Views;
using Dolar.DataAccess;
using Dolar.Models;

namespace Dolar
{
    public partial class App : Application
    {
        public App(Inicio inicio)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            using (var context = new DolarDbContext())
            {
                context.Database.EnsureCreated();  // Esto asegura que la base de datos esté creada
            }
            var listaMonedas = new List<Monedas>
            { 
    new Monedas { Nombre = "Dólar Estadounidense", img = "us", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Euro", img = "eu", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Yen Japonés", img = "jp", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Libra Esterlina", img = "gb", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Dólar Canadiense", img = "ca", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Franco Suizo", img = "ch", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Dólar Australiano", img = "au", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Yuan Chino", img = "cn", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Dólar Neozelandés", img = "nz", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Peso Mexicano", img = "mx", ActivoDivisa = true, monedabase = true },
    new Monedas { Nombre = "Rublo Ruso", img = "ru", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Real Brasileño", img = "br", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Rupia India", img = "in", ActivoDivisa = true, monedabase = false },
    new Monedas { Nombre = "Rand Sudafricano", img = "za", ActivoDivisa = true, monedabase = false }
};



            MainPage =  inicio;


        }
    }
}
