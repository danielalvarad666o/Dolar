using Dolar.DataAccess;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dolar.Views;

public partial class SeleccionarMoneda : ContentPage
{
    public SeleccionarMoneda()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        this.Padding = new Thickness(0);
        BindingContext = this;
        CargarMonedas();
    }

    // Método para cargar las monedas desde la base de datos
    private void CargarMonedas()
    {
        using (var context = new DolarDbContext())
        {
            // Obtener todas las monedas desde la base de datos
            var monedas = context.Monedas.ToList();

            // Asignar la lista de monedas a la vista
            MonedaListView.ItemsSource = monedas.Select(m => new
            {
                Id = m.Id,  // Ahora incluimos el ID para poder enviarlo luego
                Nombre = m.Nombre,
                FlagImage = $"{m.Img}.png"  // Asumiendo que las imágenes están almacenadas como archivos PNG
            }).ToList();
        }
    }

    // Evento cuando una moneda es seleccionada
    private async void OnMonedaSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var monedaSeleccionada = (dynamic)e.SelectedItem;

            // Navegar de regreso a la vista Cambio y pasar el ID de la moneda seleccionada
            var cambioPage = new Cambio();
            cambioPage.EstablecerIdMoneda(monedaSeleccionada.Id);  // Pasa el ID de la moneda

            // Navegamos a la página anterior
            await Navigation.PopAsync(true);  // Regresa a la página anterior en la pila de navegación

            // Asegurar que el elemento no quede seleccionado
            MonedaListView.SelectedItem = null;
        }
    }
}
