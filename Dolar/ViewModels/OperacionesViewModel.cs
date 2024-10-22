using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dolar.Models;

namespace Dolar.ViewModels
{
    public class OperacionesViewModel : BaseViewModel
    {
        private string _txtSearch;
        private ObservableCollection<Monedas> _monedas;
        private ObservableCollection<Monedas> _filteredMonedas;

        public ObservableCollection<Monedas> Monedas
        {
            get => _monedas;
            set
            {
                _monedas = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Monedas> FilteredMonedas
        {
            get => _filteredMonedas;
            set
            {
                _filteredMonedas = value;
                OnPropertyChanged();
            }
        }

        public string TxtSearch
        {
            get => _txtSearch;
            set
            {
                if (_txtSearch != value)
                {
                    _txtSearch = value;
                    OnPropertyChanged();
                    FilterMonedas();
                }
            }
        }

        public OperacionesViewModel()
        {
            Monedas = new ObservableCollection<Monedas>();
            FilteredMonedas = new ObservableCollection<Monedas>();
        }

        public async Task GetMonTipoCambiConfig()
        {
            // Simulación de obtención de datos. Aquí deberías hacer la llamada a tu servicio o API.
            var monedas = await Task.Run(() => new List<Monedas>
            {
                new Monedas { Id = 1, Nombre = "USD", ActivoDivisa = true },
                new Monedas { Id = 2, Nombre = "EUR", ActivoDivisa = true },
                new Monedas { Id = 3, Nombre = "JPY", ActivoDivisa = false }
            });

            Monedas = new ObservableCollection<Monedas>(monedas);
            FilteredMonedas = new ObservableCollection<Monedas>(monedas);
        }

        private void FilterMonedas()
        {
            if (string.IsNullOrEmpty(TxtSearch))
            {
                FilteredMonedas = new ObservableCollection<Monedas>(Monedas);
            }
            else
            {
                // Filtrar ignorando mayúsculas/minúsculas y manejando posibles valores nulos en "Nombre"
                var filtered = Monedas.Where(m => m.Nombre != null &&
                                                  m.Nombre.ToLower().Contains(TxtSearch.ToLower()));
                FilteredMonedas = new ObservableCollection<Monedas>(filtered);
            }
        }
    }
}
