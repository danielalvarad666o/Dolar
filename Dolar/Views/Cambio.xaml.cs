using Syncfusion.Maui.Popup;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Inputs;
using Syncfusion.Maui.Core;

namespace Dolar.Views
{
    public partial class Cambio : ContentPage, INotifyPropertyChanged
    {
        // Propiedades para enlazar en la vista
        private string countryCode;
        private string currencyName;
        private string flagImage;
        private string nombreEmpresa;
        private string direccionEmpresa;


        public event PropertyChangedEventHandler PropertyChanged;

        public string CountryCode
        {
            get => countryCode;
            set
            {
                if (countryCode != value)
                {
                    countryCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrencyName
        {
            get => currencyName;
            set
            {
                if (currencyName != value)
                {
                    currencyName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FlagImage
        {
            get => flagImage;
            set
            {
                if (flagImage != value)
                {
                    flagImage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NombreEmpresa
        {
            get => nombreEmpresa;
            set
            {
                if (nombreEmpresa != value)
                {
                    nombreEmpresa = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DireccionEmpresa
        {
            get => direccionEmpresa;
            set
            {
                if (direccionEmpresa != value)
                {
                    direccionEmpresa = value;
                    OnPropertyChanged();
                }
            }
        }

        public Cambio()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar el BindingContext
            BindingContext = this;

            // Inicializar las propiedades
            CountryCode = "MX";
            CurrencyName = "MXN Peso";
            FlagImage = "mx.png"; // Ruta de la imagen
        }

        // Método para notificar cuando una propiedad cambia
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            // Mostrar el popup de configuración
            popup.Show();
        }

        private async void AceptarButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados
                var nombreEmpresa = NombreEmpresa; // Aquí se enlaza a la propiedad
                // Lógica para obtener los otros campos si están enlazados

                // Mostrar los datos ingresados en un DisplayAlert
                await DisplayAlert("Datos Ingresados",
                                   $"Nombre de la empresa: {nombreEmpresa}\n" +
                                   $"Dirección de la empresa: {DireccionEmpresa}\n",
                                   "Aceptar");

                // Cerrar el popup después de mostrar el alert
                popup.Dismiss();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "Aceptar");
            }
        }

        private void CancelarButton_Clicked(object sender, EventArgs e)
        {
            // Cerrar el popup sin hacer nada
            popup.Dismiss();
        }
    }
}
