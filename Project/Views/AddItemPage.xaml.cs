using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;


/*
    I acknowledge the following statements:
    That the code I provide below is my own work and NOT copied from any outside resource,
    unless given explicit permission by the instructor.
    That the code I provide below is my own work and NOT the work of my peers or any other individual,
    unless given explicit permission by the instructor.
    That if the code below is in violation of the above statements, I may be subject to penalties.
    Your Name: Daniel Anorue
    Your Student ID: 10166216
*/

namespace RestaurantAppFullImp.Project.Views
{
    public partial class AddMenuItemPage : ContentPage
    {
        public AddMenuItemPage()
        {
            InitializeComponent();
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(entryName.Text) || string.IsNullOrWhiteSpace(entryPrice.Text) || pickerType.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            if (!decimal.TryParse(entryPrice.Text, out decimal price))
            {
                await DisplayAlert("Error", "Invalid price.", "OK");
                return;
            }

            // Create new MenuItem
            var newItem = new MenuItem
            {
                ItemName = entryName.Text,
                ItemPrice = price,
                HasSize = switchHasSize.IsToggled,
                Type = (MenuItemType)pickerType.SelectedIndex,
                Size = MenuSizeType.SMALL, 
                Icon = "eagle.png" 
            };

            await App.Menu.AddItem(newItem);

            await DisplayAlert("Success", $"{newItem.ItemName} added to menu!", "OK");

            
            await Navigation.PopAsync();
        }
    }
}
