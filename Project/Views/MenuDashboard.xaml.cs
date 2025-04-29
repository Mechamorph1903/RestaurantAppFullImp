using System.Collections.ObjectModel;
using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Views;


public partial class MenuDashboard : ContentPage
{
	private ObservableCollection<MenuItem> _menuItems = new();
    public MenuDashboard()
	{
		InitializeComponent();
        LoadMenuItems();
    }

    private async void LoadMenuItems()
    {
        var items = await App.Menu.GetItems();
        _menuItems = new ObservableCollection<MenuItem>(items);
        menuCollectionView.ItemsSource = _menuItems;
    }
    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchText = searchBar.Text ?? "";
        var items = await App.Menu.GetItems();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            items = items.Where(i => i.ItemName.ToLower().Contains(searchText.ToLower())).ToList();
        }

        _menuItems = new ObservableCollection<MenuItem>(items);
        menuCollectionView.ItemsSource = _menuItems;


    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMenuItemPage());
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {

        var selectedItem = menuCollectionView.SelectedItem as MenuItem;
        if (selectedItem == null)
        {
            await DisplayAlert("Error", "Please select an item to edit.", "OK");
            return;
        }

        await Navigation.PushAsync(new EditMenuItemPage(selectedItem));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var selectedItem = menuCollectionView.SelectedItem as MenuItem;
        if (selectedItem == null)
        {
            await DisplayAlert("Error", "Please select an item to delete.", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Confirm", $"Delete {selectedItem.ItemName}?", "Yes", "No");
        if (confirm)
        {
            await App.Menu.DeleteItem(selectedItem);
            LoadMenuItems();
        }
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadMenuItems();
    }
}