using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Dolar.Views
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            // Navegar después de 5 segundos
            this.Appearing += Inicio_Appearing;
            

        }

        private async void Inicio_Appearing(object sender, EventArgs e)
        {
            // Esperar 5 segundos (5000 milisegundos)
            await Task.Delay(5000);

            // Navegar a la siguiente pantalla (Base)
            await  Navigation.PushAsync(new Base());
        }
    }
}

