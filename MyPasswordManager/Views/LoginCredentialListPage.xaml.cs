using MyPasswordManager.Data;
using MyPasswordManager.Models;
using System.Collections.ObjectModel;

namespace MyPasswordManager.Views;

public partial class LoginCredentialListPage : ContentPage
{
	private readonly Database database;

    public ObservableCollection<LoginCrendential> Items { get; set; } = new();

	public LoginCredentialListPage(Database database)
	{
		InitializeComponent();

		this.database = database;

        BindingContext = this;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GetItemsAsync();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not LoginCrendential item)
            return;

        await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }

    private async void OnItemAdd(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
		{
			["Item"] = new LoginCrendential()
		});
    }
}

