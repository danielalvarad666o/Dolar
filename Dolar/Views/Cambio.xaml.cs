using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Dolar.DataAccess;
using Microsoft.Maui.Controls;
using System.Linq;
using Syncfusion.Maui.Popup;
using Syncfusion.Maui.Inputs;
using Syncfusion.Maui.Core;

namespace Dolar.Views
{
    public partial class Cambio : ContentPage, INotifyPropertyChanged
    {
        private string countryCode;
        private string currencyName;
        private string flagImage;
        private decimal exchangeRate;
        private bool isResultadoVisible;
        private string tipoCambioInfo;
        private string tipoCambioEquivalente;

        // Propiedades para los valores de tipo de cambio
        private decimal tipoCambioCompra;
        private decimal tipoCambioVenta;

        // Valores de moneda de cambio
        private string countryCodeC;
        private string currencyNameC;
        private string flagImageC;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TipoCambioInfo
        {
            get => tipoCambioInfo;
            set
            {
                if (tipoCambioInfo != value)
                {
                    tipoCambioInfo = value;
                    OnPropertyChanged();
                }
            }
        }
        private void ActualizarInformacionTipoCambio()
        {
            TipoCambioInfo = $"1 {CurrencyNameC} = {1 / TipoCambioVenta:N3} MXN";
            TipoCambioEquivalente = $"1 MXN = {TipoCambioVenta:N2} {CurrencyNameC}";
        }

        public string TipoCambioEquivalente
        {
            get => tipoCambioEquivalente;
            set
            {
                if (tipoCambioEquivalente != value)
                {
                    tipoCambioEquivalente = value;
                    OnPropertyChanged();
                }
            }
        }

        // Propiedades ligadas a la UI
        public decimal TipoCambioCompra
        {
            get => tipoCambioCompra;
            set
            {
                if (tipoCambioCompra != value)
                {
                    tipoCambioCompra = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal TipoCambioVenta
        {
            get => tipoCambioVenta;
            set
            {
                if (tipoCambioVenta != value)
                {
                    tipoCambioVenta = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrencyNameC
        {
            get => currencyNameC;
            set
            {
                if (currencyNameC != value)
                {
                    currencyNameC = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FlagImageC
        {
            get => flagImageC;
            set
            {
                if (flagImageC != value)
                {
                    flagImageC = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CountryCodeC
        {
            get => countryCodeC;
            set
            {
                if (countryCodeC != value)
                {
                    countryCodeC = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public bool IsResultadoVisible
        {
            get => isResultadoVisible;
            set
            {
                if (isResultadoVisible != value)
                {
                    isResultadoVisible = value;
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

        public decimal ExchangeRate
        {   get => exchangeRate;   set{ if (exchangeRate != value) { exchangeRate = value; OnPropertyChanged();} }
       }
        private string tipoCambioMXN;

        public string TipoCambioMXN
        {
            get => tipoCambioMXN;
            set
            {
                if (tipoCambioMXN != value)
                {
                    tipoCambioMXN = value;
                    OnPropertyChanged();
                }
            }
        }

        // Constructor
        public Cambio(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar el BindingContext
            BindingContext = this;
            CargarMonedaBase();
            CargarTiposDeCambio(id);
            CargarMonedaCambio(id);
        }

        public void CargarMonedaCambio(int id)
        {
            using (var context = new DolarDbContext())
            {
                
                if (id > 0)
                {
                    var monedaCambio = context.Monedas.FirstOrDefault(m => m.Id == id);
               
                    if (monedaCambio != null)
                    {
                        // Asignar valores para la moneda seleccionada
                        CountryCodeC = $"{monedaCambio.Img}";
                        CurrencyNameC = $"{monedaCambio.Nombre}";
                        FlagImageC = $"{monedaCambio.Img}.png";

                        var tipoCambio = context.TiposCambio.FirstOrDefault(t => t.Moneda.Id == id);

                        if (tipoCambio != null)
                        {
                            TipoCambioCompra = tipoCambio.TipoCambioCompra;
                            TipoCambioVenta = tipoCambio.TipoCambioVenta;
                        }
                        else
                        {
                            DisplayAlert("Error", "Tipo de cambio no encontrado.", "OK");
                        }
                    }
                    else
                    {
                        // Si no se encuentra la moneda con el id proporcionado, buscar la moneda con Img == "us"
                        var monedaBaseC = context.Monedas.FirstOrDefault(m => m.Img == "us");
                       

                        if (monedaBaseC != null)
                        {
                            // Asignar valores de la moneda con Img "us"
                            CountryCodeC = $"{monedaBaseC.Img}";
                            CurrencyNameC = $"{monedaBaseC.Nombre}";
                            FlagImageC = $"{monedaBaseC.Img}.png";

                            var tipoCambioMXN = context.TiposCambio.FirstOrDefault(t => t.Moneda.Id == monedaBaseC.Id);

                            if (tipoCambioMXN != null)
                            {
                                TipoCambioCompra = tipoCambioMXN.TipoCambioCompra;
                                TipoCambioVenta = tipoCambioMXN.TipoCambioVenta;
                            }
                            else
                            {
                                DisplayAlert("Error", "Tipo de cambio para USD no encontrado.", "OK");
                            }
                        }
                        else
                        {
                            // Si tampoco se encuentra la moneda "us", mostrar alerta
                            DisplayAlert("Error", "Moneda no encontrada, incluyendo USD.", "OK");
                        }
                    }
                }
                else
                {
                    var monedaBaseC = context.Monedas.FirstOrDefault(m => m.Img == "us");
                    DisplayAlert("Error", $"{monedaBaseC}", "OK");

                    if (monedaBaseC != null)
                    {
                        // Asignar valores de la moneda con Img "us"
                        CountryCodeC = $"{monedaBaseC.Img}";
                        CurrencyNameC = $"{monedaBaseC.Nombre}";
                        FlagImageC = $"{monedaBaseC.Img}.png";

                        var tipoCambioMXN = context.TiposCambio.FirstOrDefault(t => t.Moneda.Id == monedaBaseC.Id);

                        if (tipoCambioMXN != null)
                        {
                            TipoCambioCompra = tipoCambioMXN.TipoCambioCompra;
                            TipoCambioVenta = tipoCambioMXN.TipoCambioVenta;
                            TipoCambioInfo = $"1 {CurrencyNameC} = {1 / TipoCambioVenta:N3} MXN";
                        }
                        else
                        {
                            DisplayAlert("Error", "Tipo de cambio para USD no encontrado.", "OK");
                        }
                    }
                }
            }
        }

        // Cargar los detalles de la moneda base (MXN)
        private void CargarMonedaBase()
        {
            using (var context = new DolarDbContext())
            {
                var monedaBase = context.Monedas.FirstOrDefault(m => m.monedabase);

                if (monedaBase != null)
                {
                    // Asignar valores a las propiedades desde la moneda base
                    CountryCode = $"{monedaBase.Img}";
                    CurrencyName = $"{monedaBase.Nombre}";
                    FlagImage = $"{monedaBase.Img}.png";
                }
                else
                {
                    // Si no hay moneda base, asignar valores predeterminados
                    CountryCode = "MX";
                    CurrencyName = "MXN Peso";
                    FlagImage = "mx.png";
                }
            }
        }

        // Cargar tipos de cambio
        private void CargarTiposDeCambio(int id)
        {
            using (var context = new DolarDbContext())
            {
                
                if (id > 0)
                {
                    var monedaCambio = context.Monedas.FirstOrDefault(m => m.Id == id);
                    var tipoCambioMoneda = context.TiposCambio.FirstOrDefault(t => t.Moneda.Nombre == monedaCambio.Nombre);
                    var monedaNombre = monedaCambio.Nombre;
                    if (tipoCambioMoneda != null)
                    {
                        // Actualizar los valores dinámicos en la interfaz
                        TipoCambioMXN = $"1 MXN = {1 / tipoCambioMoneda.TipoCambioVenta:N3} {monedaNombre}";
                        TipoCambioUSDLabel.Text = $"1 {monedaNombre} = {tipoCambioMoneda.TipoCambioVenta:N2} MXN";
                    }
                    else
                    {
                        DisplayAlert("Error", $"Tipo de cambio para {monedaNombre} no encontrado.", "OK");
                    }
                }
                else
                {
                      var tipoCambioMoneda = context.TiposCambio.FirstOrDefault(t => t.Moneda.Nombre == "Dólar Estadounidense");
                    var monedaNombre = "Dólar Estadounidense";
                    if (tipoCambioMoneda != null)
                    {
                        // Actualizar los valores dinámicos en la interfaz
                        TipoCambioMXN = $"1 MXN = {1 / tipoCambioMoneda.TipoCambioVenta:N3} {monedaNombre}";
                        TipoCambioUSDLabel.Text = $"1 {monedaNombre} = {tipoCambioMoneda.TipoCambioVenta:N2} MXN";
                    }
                    else
                    {
                        DisplayAlert("Error", $"Tipo de cambio para {monedaNombre} no encontrado.", "OK");
                    }
                }

                // Obtener el tipo de cambio de la moneda pasada como parámetro
              

            }
        }


        // Lógica para el botón "Comprar"
        private void OnComprarClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(MontoEntry.Text, out decimal monto))
            {
                if (TipoCambioVenta > 0)
                {
                    decimal resultado = monto * (1 / TipoCambioVenta);

                    OperacionLabel.Text = $"Operación: Compra de {CurrencyNameC}";
                    ResultadoLabel.Text = $"Valor final: {resultado:N2} {CurrencyNameC}";

                    IsResultadoVisible = true;
                }
                else
                {
                    DisplayAlert("Error", "Tipo de cambio no válido.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Ingrese un monto válido.", "OK");
            }
        }


        // Lógica para el botón "Vender"
        private void OnVenderClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(MontoEntry.Text, out decimal monto))
            {
                if (TipoCambioCompra > 0)
                {
                    decimal resultado = monto * TipoCambioCompra;

                    OperacionLabel.Text = $"Operación: Venta de {CurrencyNameC}";
                    ResultadoLabel.Text = $"Valor final: {resultado:N2} MXN";

                    IsResultadoVisible = true;
                }
                else
                {
                    DisplayAlert("Error", "Tipo de cambio no válido.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Ingrese un monto válido.", "OK");
            }
        }



        // Notificar cambios de propiedad
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnFrameTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeleccionarMoneda());
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            // Mostrar el popup de configuración
            popup.Show();
        }

        private async void AceptarButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Configuración", "Configuración guardada.", "OK");
        }

        private void CancelarButton_Clicked(object sender, EventArgs e)
        {
            // Cerrar el popup sin hacer nada
            popup.Dismiss();
        }
    }

}

