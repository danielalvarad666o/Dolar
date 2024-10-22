

using Dolar.Views;
using Dolar.DataAccess;
namespace Dolar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            using (var context = new DolarDbContext())
            {
                context.Database.EnsureCreated();  // Esto asegura que la base de datos esté creada
            }

            MainPage =  new  NavigationPage(new Inicio());
            

        }
    }
}
