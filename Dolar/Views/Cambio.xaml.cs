using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Dolar.Views
{
    public partial class Cambio : ContentPage, INotifyPropertyChanged
    {
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

        public Cambio()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar el BindingContext
            BindingContext = this;

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
    }
}
