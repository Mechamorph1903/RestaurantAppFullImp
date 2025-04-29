using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Views
{
    public partial class EditMenuItemPage : ContentPage
    {
        private MenuItem _itemToEdit;

        public EditMenuItemPage(MenuItem item)
        {
            InitializeComponent();
            _itemToEdit = item;

            // Pre-fill UI with item values
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
