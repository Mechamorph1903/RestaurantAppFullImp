using Microsoft.Maui.Controls.Platform;
using RestaurantAppFullImp.Project.Models;
using System.Collections.ObjectModel;
using System.Xml.Schema;

namespace RestaurantAppFullImp.Project.Views;

public partial class MainMenuPage : ContentPage
{
	bool CartShown = true;
	ObservableCollection<CartPopupItemView> view_items;

    public MainMenuPage()
	{
		InitializeComponent();
        collCart.IsVisible = true;

		view_items = new();

		var controller_items = App.Cart.GetCartItems();

		foreach( var item in controller_items )
		{
			CartPopupItemView cartPopupItemView = new CartPopupItemView();
			cartPopupItemView.Item = item;
			view_items.Add(cartPopupItemView);
		}

		collCart.ItemsSource = view_items;
    }

	private void ButtonToggleCart(object sender, EventArgs e)
	{
		if (CartShown)
		{
			CartShown = false;
			grdPageFrame.ColumnDefinitions[1].Width = 80;
			collCart.IsVisible = false;
			layoutCartControls.IsVisible = false;
        }
		else
		{
			CartShown = true;
            grdPageFrame.ColumnDefinitions[1].Width = 300;
            collCart.IsVisible = true;
			layoutCartControls.IsVisible = true;
        }
	}


    private void ButtonDeleteCartItems(object sender, EventArgs e)
    {
		ObservableCollection<CartPopupItemView> selected = new();

        foreach (var selected_item in collCart.SelectedItems)
		{
            CartPopupItemView? item = (selected_item as CartPopupItemView);
			if (item != null)
			{
				App.Cart.RemoveItem(item.Item.ID);
				selected.Add(item);
			}
		}

		foreach (var item in selected)
			view_items.Remove(item);
    }

    private async void ButtonAddEntree(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ItemAddPage(MenuItemType.ENTREE));
    }

    private async void ButtonAddSide(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ItemAddPage(MenuItemType.SIDE));
    }

    private async void ButtonAddDrink(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ItemAddPage(MenuItemType.DRINK));
    }

    private async void ButtonAddDessert(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ItemAddPage(MenuItemType.DESSERT));
    }

    private async void ButtonBuildCombo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComboBuilderPage());
    }

    private async void ButtonCheckoutCart(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CheckoutView());
    }

   
}