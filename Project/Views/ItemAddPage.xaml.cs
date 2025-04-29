namespace RestaurantAppFullImp.Project.Views;
using Project.Models;
using System.Collections.ObjectModel;

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

/*
    Hint: A class called ItemSelectView is defined that "wraps" around the data model and provides properties 
    that are referenced in the collection view's data template.  The collection view should be an observable
    list of ItemSelectView objects that bind to the menu items being shown.
*/


public partial class ItemAddPage : ContentPage
{


    //Add any page attributes here...
    private MenuItemType _itemType;
    public ObservableCollection<ItemSelectView> Items { get; set; } = new ObservableCollection<ItemSelectView>();
    private ItemSelectView selectedItem;
    private MenuSizeType selectedSize = MenuSizeType.SMALL;




    public ItemAddPage(MenuItemType type)
    {
        InitializeComponent();
        _itemType = type;
        BindingContext = this;
        LoadItems(); // Fire-and-forget
    }

    private async void LoadItems()
    {
        var menuItems = await App.Menu.GetItems(_itemType);
        foreach (var item in menuItems)
        {
            Items.Add(new ItemSelectView { Item = item });
        }
    }





    private void SelectItem(object sender, SelectionChangedEventArgs e)
    {
        //This method is called when an item is selected in the Collection View...
        selectedItem = e.CurrentSelection.FirstOrDefault() as ItemSelectView;

    }

    private void SelectSize(object sender, SelectionChangedEventArgs e)
    {
        //This method is called when a new size is selected...
        selectedSize = (MenuSizeType)e.CurrentSelection.FirstOrDefault();
    }

    private async void AddItemClicked(object sender, EventArgs e)
    {
        // This method is called when the Add Item button is clicked.
        if (selectedItem == null)
        {
            await DisplayAlert("Error", "Please select an item first.", "OK");
            return;
        }

        var itemToAdd = selectedItem.Item;

        if (itemToAdd.HasSize)
        {
            itemToAdd.Size = selectedSize;
        }

        App.Cart.AddItem(itemToAdd);

        await DisplayAlert("Success", $"{itemToAdd.ItemName} added to cart.", "OK");
        await Navigation.PopAsync();
    }
}