

using Dolar.Views;

namespace Dolar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MainPage =  new  NavigationPage(new ListaDivisas());
            

        }
    }
}
