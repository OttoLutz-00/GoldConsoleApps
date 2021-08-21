using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class MenuRepository
    {
        private readonly List<MenuItem> _menuDirectory = new List<MenuItem>();
        
        //CRUD

        //Create
        public void AddItemToMenu(MenuItem item)
        {
            _menuDirectory.Add(item);
        }

        //Read
        public List<MenuItem> GetMenu()
        {
            return _menuDirectory;
        }
        public MenuItem GetMenuItemByItemNumber(int id)
        {
            foreach (MenuItem item in _menuDirectory)
            {
                if (item.ItemNumber == id)
                return item;
            }
            Console.WriteLine("There was no item on the menu with that item number.");
            return null;
        }

        //Update - no updates needed as specified in directions
        //Delete
        public bool RemoveItemFromMenu(int id)
        {
            if (_menuDirectory.Remove(GetMenuItemByItemNumber(id)))
                return true;
            return false;
        }


    }
}
