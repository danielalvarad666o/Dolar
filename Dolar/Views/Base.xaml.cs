using System.ComponentModel;
using Dolar.DataAccess;
using Dolar.Models;
using System.Linq;

namespace Dolar.Views
{
    public partial class Base : ContentPage, INotifyPropertyChanged
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
                    OnPropertyChanged(nameof(CountryCode));
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
                    OnPropertyChanged(nameof(CurrencyName));
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
                    OnPropertyChanged(nameof(FlagImage));
                }
            }
        }

        public Base()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.Padding = new Thickness(0);
            BindingContext = this;

            // Usar el contexto para obtener la moneda con monedabase = true
            using (var context = new DolarDbContext())
            {
                var monedaBase = context.Monedas.FirstOrDefault(m => m.monedabase);
                
                if (monedaBase != null)
                {
                    var img = $"{monedaBase.Img}.png";

                  
                    // Asignar valores a las propiedades desde la moneda base
                    CountryCode = $"{monedaBase.Img}";
                    CurrencyName = $"{monedaBase.Nombre}";
                    FlagImage = img;
                }
                else
                {
                    // Si no hay moneda base, asignar valores predeterminados
                    CountryCode = "MX";
                    CurrencyName = "MXN Peso";
                    FlagImage = "banderas/mx.png";
                }
            }

            // Inicializar el Picker si lo tienes en la interfaz
            
        }

        // Método que maneja el cambio en el Picker
     
        // Notifica cuando una propiedad cambia
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnEstablecerClicked(object sender, EventArgs e)
        {
            // Navega a la vista "Cambio"
            await Navigation.PushAsync(new Cambio(5));
        }
    }
}
