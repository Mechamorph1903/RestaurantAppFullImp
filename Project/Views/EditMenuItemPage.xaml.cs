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
    public partial class EditMenuItemPage : ContentPage
    {
        private MenuItem _itemToEdit;

        public EditMenuItemPage(MenuItem item)
        {
            InitializeComponent();
            _itemToEdit = item;

           
            entryName.Text = item.ItemName;
            entryPrice.Text = item.ItemPrice.ToString();
            switchHasSize.IsToggled = item.HasSize;
            pickerType.SelectedIndex = (int)item.Type;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
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

            // Update item
            _itemToEdit.ItemName = entryName.Text;
            _itemToEdit.ItemPrice = price;
            _itemToEdit.HasSize = switchHasSize.IsToggled;
            _itemToEdit.Type = (MenuItemType)pickerType.SelectedIndex;

            await App.Menu.UpdateItem(_itemToEdit);

            await DisplayAlert("Success", "Item updated successfully.", "OK");
            await Navigation.PopAsync();
        }
    }
}
