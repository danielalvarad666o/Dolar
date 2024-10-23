using System;
using System.Collections.ObjectModel;
using Dolar.DataAccess;
using Dolar.Models;
using Microsoft.Maui.Controls;

namespace Dolar.Views
{
    public partial class SeleccionarMoneda : ContentPage
    {
        public ObservableCollection<Monedas> Monedas { get; set; }

        public SeleccionarMoneda()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Padding = new Thickness(0);

            // Inicializamos la colección de monedas
            Monedas = new ObservableCollection<Monedas>();

            // Cargar las monedas
            CargarMonedas();

            // Establecer el BindingContext
            BindingContext = this;
        }

        private async void CargarMonedas()
        {
            using (var context = new DolarDbContext())
            {
                var monedasList = await context.GetAllMonedas();
                foreach (var moneda in monedasList)
                {
                    // Verificar si la propiedad monedabase es diferente de true
                    if (!moneda.monedabase)
                    {
                        // Asignar la ruta de la imagen
                        moneda.Img = $"{moneda.Img}.png"; // Ruta relativa a las imágenes
                        Monedas.Add(moneda);
                    }
                }
            }
        }


        // Manejador de eventos para el cambio de selección en el CollectionView
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMoneda = e.CurrentSelection.FirstOrDefault() as Monedas;
            if (selectedMoneda != null)
            {
                // Guardar el ID de la moneda seleccionada o realizar otras acciones
                int monedaSeleccionadaId = selectedMoneda.Id;
                // Navega a la vista "Cambio" con el ID de la moneda seleccionada
                OnEstablecerClicked(monedaSeleccionadaId);
            }
        }

        // Este método maneja la navegación a la página "Cambio"
        private async void OnEstablecerClicked(int id)
        {
            // Navega a la vista "Cambio" como una nueva página
            await Navigation.PushAsync(new Cambio(id), true);
        }
    }
}

