using System.Collections.ObjectModel;
using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;
using RestaurantAppFullImp.Project.Services;
using System.Diagnostics; // Ensure this namespace is included for Debug.WriteLine
using System.IO; // Ensure this namespace is included for Path


namespace RestaurantAppFullImp.Project.Controllers
{
    public class MenuController
    {
        DatabaseService _dbService = new(); 

        public MenuController()
        {
            

            _ = PreloadMenuItems();
        }


        public async Task<List<MenuItem>> GetItems(MenuItemType? type = null)
        {
            var items = await _dbService.GetAllMenuItems();

            if (type == null)
                return items;

            return items.Where(i => i.Type == type).ToList();
        }

        public async Task AddItem(MenuItem item)
        {
            await _dbService.AddMenuItem(item);
        }

        public async Task UpdateItem(MenuItem item)
        {
            await _dbService.UpdateMenuItem(item);
        }

        public async Task DeleteItem(MenuItem item)
        {
            await _dbService.DeleteMenuItem(item);
        }


        private async Task PreloadMenuItems()
        {
            var items = await _dbService.GetAllMenuItems();
            if (items.Count == 0)
            {
                // Only seed if empty
                List<MenuItem> starterItems = new()
        {
           new MenuItem { ItemName = "Seafood Alfredo", Type = MenuItemType.ENTREE, ItemPrice=15.95M},
                new MenuItem { ItemName = "Chicken Alfredo", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Chicken Picatta", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Turkey Club", Type = MenuItemType.ENTREE, ItemPrice=11.95M },
                new MenuItem { ItemName = "Lobster Pie", Type = MenuItemType.ENTREE, ItemPrice=19.95M },
                new MenuItem { ItemName = "Prime Rib", Type = MenuItemType.ENTREE, ItemPrice=20.95M },
                new MenuItem { ItemName = "Shrimp Scampi", Type = MenuItemType.ENTREE, ItemPrice=18.95M },
                new MenuItem { ItemName = "Turkey Dinner", Type = MenuItemType.ENTREE, ItemPrice=13.95M },
                new MenuItem { ItemName = "Stuffed Chicken", Type = MenuItemType.ENTREE, ItemPrice=14.95M },
                new MenuItem { ItemName = "Classic Fries", Type = MenuItemType.SIDE, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Spicy Fries", Type = MenuItemType.SIDE, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Mashed Potatoes", Type = MenuItemType.SIDE, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Steamed Vegetables", Type = MenuItemType.SIDE, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Garden Salad", Type = MenuItemType.SIDE, ItemPrice=2.95M },
                new MenuItem { ItemName = "Loaded Potatos", Type = MenuItemType.SIDE, ItemPrice=3.50M },
                new MenuItem { ItemName = "Mac and Cheese", Type = MenuItemType.SIDE , ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Soda", Type = MenuItemType.DRINK, ItemPrice=1.95M, HasSize=true },
                new MenuItem { ItemName = "Tea", Type = MenuItemType.DRINK, ItemPrice=1.50M, HasSize=true },
                new MenuItem { ItemName = "Coffee", Type = MenuItemType.DRINK, ItemPrice=1.25M, HasSize=true },
                new MenuItem { ItemName = "Mineral Water", Type = MenuItemType.DRINK, ItemPrice=2.95M, HasSize=true },
                new MenuItem { ItemName = "Juice", Type = MenuItemType.DRINK, ItemPrice=2.50M, HasSize=true },
                new MenuItem { ItemName = "Buffalo Wings", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Buffalo Fingers", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Potato Skins", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Nachos", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Mushrooms Caps", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Shrimp Cocktail", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Chips and Salsa", Type = MenuItemType.APPETIZER, ItemPrice=15.95M },
                new MenuItem { ItemName = "Apple Pie", Type = MenuItemType.DESSERT, ItemPrice=5.95M },
                new MenuItem { ItemName = "Sundae", Type = MenuItemType.DESSERT, ItemPrice=3.95M },
                new MenuItem { ItemName = "Carrot Cake", Type = MenuItemType.DESSERT, ItemPrice=5.95M },
                new MenuItem { ItemName = "Mud Pie", Type = MenuItemType.DESSERT , ItemPrice=4.95M },
                new MenuItem { ItemName = "Apple Crisp", Type = MenuItemType.DESSERT, ItemPrice=5.95M }

                };

                foreach (var item in starterItems)
                {
                    await _dbService.AddMenuItem(item);
                }
            }



        }
    }
}
