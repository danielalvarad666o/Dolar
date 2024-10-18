using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dolar.Views
{
    public partial class Cambio : ContentPage, INotifyPropertyChanged
    {
        private string countryCode;
        private string currencyName;
        private string flagImage;

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
        }

        // Método para notificar cuando una propiedad cambia
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
