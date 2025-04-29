using RestaurantAppFullImp.Project.Services;

namespace RestaurantAppFullImp.Project.Views;

public partial class KioskStartPage : ContentPage
{
    public KioskStartPage()
    {
        InitializeComponent();
        
    }

    private async void StartOrderButton(object sender, EventArgs e)
    {
        //Go to Main Menu Page
        await Navigation.PushAsync(new MainMenuPage());
    }

    private async void OpenMenuDashboard(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MenuDashboard());
    }

    private async void ShowDatabasePathClicked(object sender, EventArgs e)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, "MenuDatabase.db");
        await DisplayAlert("Database Path", path, "OK");
    }
}
