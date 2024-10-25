using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
<<<<<<< Updated upstream

=======
using Dolar.DataAccess;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Diagnostics;
>>>>>>> Stashed changes

namespace Dolar.Views
{
    public partial class Cambio : ContentPage, INotifyPropertyChanged
    {
<<<<<<< Updated upstream
        private string countryCode;
        private string currencyName;
        private string flagImage;
        private decimal exchangeRate;

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

        public decimal ExchangeRate
        {
            get => exchangeRate;
            set
            {
                if (exchangeRate != value)
                {
                    exchangeRate = value;
                    OnPropertyChanged();
                }
            }
        }

=======
        private string countryCode, currencyName, flagImage, tipoCambioInfo, tipoCambioEquivalente;
        private decimal exchangeRate, tipoCambioCompra, tipoCambioVenta;
        private bool isResultadoVisible;

        private string countryCodeC, currencyNameC, flagImageC, tipoCambioMXN;

        public event PropertyChangedEventHandler PropertyChanged;

        private int? monedaId;

        // Constructor
>>>>>>> Stashed changes
        public Cambio()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar el BindingContext
            BindingContext = this;

<<<<<<< Updated upstream
            // Valores iniciales
            CountryCode = "MX";
            CurrencyName = "MXN Peso";
            FlagImage = "mx.png"; // Ruta de la imagen

            // Cargar datos de la API
            
        }

  
        // Método para notificar cuando una propiedad cambia
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
=======
            // Dejar los campos en blanco inicialmente
            CargarMonedaBase();
        }

        // Propiedades con OnPropertyChanged simplificado
        public string TipoCambioInfo { get => tipoCambioInfo; set => SetProperty(ref tipoCambioInfo, value); }
        public string TipoCambioEquivalente { get => tipoCambioEquivalente; set => SetProperty(ref tipoCambioEquivalente, value); }
        public decimal TipoCambioCompra { get => tipoCambioCompra; set => SetProperty(ref tipoCambioCompra, value); }
        public decimal TipoCambioVenta { get => tipoCambioVenta; set => SetProperty(ref tipoCambioVenta, value); }
        public string CurrencyNameC { get => currencyNameC; set => SetProperty(ref currencyNameC, value); }
        public string FlagImageC { get => flagImageC; set => SetProperty(ref flagImageC, value); }
        public string CountryCodeC { get => countryCodeC; set => SetProperty(ref countryCodeC, value); }
        public string CountryCode { get => countryCode; set => SetProperty(ref countryCode, value); }
        public bool IsResultadoVisible { get => isResultadoVisible; set => SetProperty(ref isResultadoVisible, value); }
        public string CurrencyName { get => currencyName; set => SetProperty(ref currencyName, value); }
        public string FlagImage { get => flagImage; set => SetProperty(ref flagImage, value); }
        public decimal ExchangeRate { get => exchangeRate; set => SetProperty(ref exchangeRate, value); }
        public string TipoCambioMXN { get => tipoCambioMXN; set => SetProperty(ref tipoCambioMXN, value); }

        // Método para establecer la propiedad y notificar cambios
        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }

        // Método para cargar la moneda base (sin cambios)
        private void CargarMonedaBase()
        {
            using (var context = new DolarDbContext())
            {
                var monedaBase = context.Monedas.FirstOrDefault(m => m.monedabase);

                if (monedaBase != null)
                {
                    CountryCode = $"{monedaBase.Img}";
                    CurrencyName = $"{monedaBase.Nombre}";
                    FlagImage = $"{monedaBase.Img}.png";
                }
                else
                {
                    LimpiarCampos();
                }
            }
        }

        // Método para cargar los datos de la moneda una vez que se reciba un ID
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
                        CountryCodeC = monedaCambio.Img;
                        CurrencyNameC = monedaCambio.Nombre;
                        FlagImageC = $"{monedaCambio.Img}.png";

                        var tipoCambio = context.TiposCambio.FirstOrDefault(t => t.Moneda.Id == id);

                        if (tipoCambio != null)
                        {
                            TipoCambioCompra = tipoCambio.TipoCambioCompra;
                            TipoCambioVenta = tipoCambio.TipoCambioVenta;
                            ActualizarInformacionTipoCambio();

                        }
                        else
                        {
                            DisplayAlert("Error", "Tipo de cambio no encontrado.", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Moneda no encontrada.", "OK");
                    }
                }
                else
                {
                    LimpiarCampos();
                }
            }
        }

        // Método para limpiar los campos cuando no hay moneda seleccionada
        private void LimpiarCampos()
        {
            CountryCodeC = string.Empty;
            CurrencyNameC = string.Empty;
            FlagImageC = string.Empty;
            TipoCambioCompra = 0;
            TipoCambioVenta = 0;
            TipoCambioInfo = string.Empty;
            TipoCambioEquivalente = string.Empty;
        }

        // Método para recibir un ID posteriormente y cargar los datos
        public void EstablecerIdMoneda(int id)
        {
            CargarMonedaCambio(id);
        }

        // Actualiza la información de tipo de cambio
        private void ActualizarInformacionTipoCambio()
        {
            TipoCambioInfo = $"1 {CurrencyNameC} = {1 / TipoCambioVenta:N3} MXN";
            TipoCambioEquivalente = $"1 MXN = {TipoCambioVenta:N2} {CurrencyNameC}";
        }

        // Cargar tipos de cambio
        private void CargarTiposDeCambio(int id)
        {
            using var context = new DolarDbContext();
            var tipoCambioMoneda = context.TiposCambio.FirstOrDefault(t => t.Moneda.Id == id) ?? context.TiposCambio.FirstOrDefault(t => t.Moneda.Nombre == "Dólar Estadounidense");

            if (tipoCambioMoneda?.Moneda != null)
            {
                var monedaNombre = tipoCambioMoneda.Moneda.Nombre;
                TipoCambioMXN = $"1 MXN = {1 / tipoCambioMoneda.TipoCambioVenta:N3} {monedaNombre}";
                TipoCambioUSDLabel.Text = $"1 {monedaNombre} = {tipoCambioMoneda.TipoCambioVenta:N2} MXN";
            }
            else
            {
                MostrarErrorTipoCambio();
            }
        }

        // Manejo de errores
        private void MostrarErrorTipoCambio() => DisplayAlert("Error", "Tipo de cambio no encontrado.", "OK");
        private void MostrarErrorMoneda() => DisplayAlert("Error", "Moneda no encontrada, incluyendo USD.", "OK");

        // Operaciones de compra y venta
        private void OnComprarClicked(object sender, EventArgs e) => ProcesarOperacion("Compra", TipoCambioVenta);
        private void OnVenderClicked(object sender, EventArgs e) => ProcesarOperacion("Venta", TipoCambioCompra);

        private void ProcesarOperacion(string operacion, decimal tipoCambio)
        {
            if (decimal.TryParse(MontoEntry.Text, out decimal monto) && tipoCambio > 0)
            {
                decimal resultado = operacion == "Compra" ? monto * (1 / tipoCambio) : monto * tipoCambio;
                OperacionLabel.Text = $"Operación: {operacion} de {CurrencyNameC}";
                ResultadoLabel.Text = $"Valor final: {resultado:N2} {(operacion == "Compra" ? CurrencyNameC : "MXN")}";
                IsResultadoVisible = true;
            }
            else
            {
                DisplayAlert("Error", tipoCambio > 0 ? "Ingrese un monto válido." : "Tipo de cambio no válido.", "OK");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void OnFrameTapped(object sender, EventArgs e) => await Navigation.PushAsync(new SeleccionarMoneda());
>>>>>>> Stashed changes
    }
}

