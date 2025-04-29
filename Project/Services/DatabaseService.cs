using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using RestaurantAppFullImp.Project.Models;
using MenuItem = RestaurantAppFullImp.Project.Models.MenuItem;

namespace RestaurantAppFullImp.Project.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;

        public async Task Init() 
        {
            if (_db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MenuDatabase.db");
            _db = new SQLiteAsyncConnection(databasePath);

            await _db.CreateTableAsync<MenuItem>();

        }

        public async Task<List<MenuItem>> GetAllMenuItems()
        {
            await Init();
            return await _db.Table<MenuItem>().ToListAsync();
        }

        public async Task AddMenuItem(MenuItem item)
        {
            await Init();
            await _db.InsertAsync(item);
        }

        public async Task UpdateMenuItem(MenuItem item)
        {
            await Init();
            await _db.UpdateAsync(item);
        }

        public async Task DeleteMenuItem(MenuItem item)
        {
            await Init();
            await _db.DeleteAsync(item);
        }

        public async Task<List<MenuItem>> SearchMenuItemsByName(string searchText)
        {
            await Init();
            return await _db.Table<MenuItem>()
                           .Where(i => i.ItemName.ToLower().Contains(searchText.ToLower()))
                           .ToListAsync();
        }
    }
}
