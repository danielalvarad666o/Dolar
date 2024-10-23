namespace Dolar.Views;

public partial class SeleccionarMoneda : ContentPage
{
	public SeleccionarMoneda()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        this.Padding = new Thickness(0);
        BindingContext = this;
    }
}