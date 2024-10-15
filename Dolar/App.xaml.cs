

using Dolar.Views;

namespace Dolar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Title = string.Empty;
            MainPage =  new  NavigationPage(new Inicio());

        }
    }
}
