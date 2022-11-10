using MyPasswordManager.Views;

namespace MyPasswordManager;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginCredentialItemPage), typeof(LoginCredentialItemPage));
	}
}
