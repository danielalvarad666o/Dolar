

using Dolar.Views;
using Dolar.DataAccess;
namespace Dolar
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH9ccnRXQmRfWEF/V0Y=");
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
