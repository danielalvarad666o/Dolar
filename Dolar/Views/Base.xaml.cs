namespace Dolar.Views;

public partial class Base : ContentPage
{
	public Base()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        this.Padding = new Thickness(0);

    }
}