using System.ComponentModel;

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
            // Asignar el BindingContext a la página
            NavigationPage.SetHasNavigationBar(this, false);
            this.Padding = new Thickness(0);
            BindingContext = this;

            // Valores iniciales
            CountryCode = "MX";
            CurrencyName = "MXN Peso";
            FlagImage = "mx.png"; // Ruta a la imagen de la bandera
            picker.SelectedIndex = 0;

        }

        // Método que maneja el cambio en el Picker
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.Items[selectedIndex])
                {
                    case "MXN Peso":
                        CountryCode = "MX";
                        CurrencyName = "MXN Peso";
                        FlagImage = "mx.png";
                        break;
                    case "USD Dólar":
                        CountryCode = "US";
                        CurrencyName = "USD Dólar";
                        FlagImage = "us.png";
                        break;
                    case "EUR Euro":
                        CountryCode = "EU";
                        CurrencyName = "EUR Euro";
                        FlagImage = "eu.png";
                        break;
                }
            }
        }

        // Notifica cuando una propiedad cambia
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnEstablecerClicked(object sender, EventArgs e)
        {
            // Navega a la vista "Cambio"
            await Navigation.PushAsync(new Cambio());
        }
    }
}

