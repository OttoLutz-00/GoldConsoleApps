using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        //field
        private readonly MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedContent();
            Menu();
        }
        public void SeedContent()
        {
            MenuItem item1 = new MenuItem(1, "item name 1", "This is a classic item number 1, straight out the dinglebop.", "pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 13.95);
            MenuItem item2 = new MenuItem(1, "item name 1", "This is a customer-favorite, fresh out the uh machine.", "corn, pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 19.95);
            MenuItem item3 = new MenuItem(1, "item name 1", "This is a special item only made here at Komodo Cafe, it's home baked inside our famous thing.", "so many beans, pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 23.95);
            _repo.AddItemToMenu(item1);
            _repo.AddItemToMenu(item2);
            _repo.AddItemToMenu(item3);
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                DisplayWelcome();
                string input = Console.ReadLine();
                switch (Convert.ToInt32(input))
                {
                    case 1:
                        DisplayMenu();
                        break;
                    case 2:
                        AddItemToMenu();
                        break;
                    case 3:
                        DeleteItemFromMenu();
                        break;
                    case 4:
                        keepRunning = false;
                        break;
                    default:
                        InvalidInputMessage();
                        break;
                }
            }
        }
        //prints the welcome message and the menu options
        public void DisplayWelcome()
        {
            Console.Write("\n   Komodo Cafe Menu Editor!\n\n" +
                    " (1) View Menu\n" +
                    " (2) Add Item to Menu\n" +
                    " (3) Remove Item from Menu\n" +
                    " (4) Exit the Program\n" +
                    "\n What do you want to do? (1, 2, 3, or 4): ");
        }
        //prints all items on the menu
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\n  Komodo Cafe");
            foreach (MenuItem item in _repo.GetMenu())
            {
                Console.WriteLine(" " + item);
            }
            ContinueMessage();
        }
        //add item to menu
        public void AddItemToMenu()
        {
            Console.Write("Item number: ");
            int itemNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Item name: ");
            string itemName = Console.ReadLine();
            Console.Write("Item description:  ");
            string itemDescription = Console.ReadLine();
            Console.Write("Item ingredients: ");
            string ingredients = Console.ReadLine();
            Console.Write("Item price: ");
            string price = Console.ReadLine();
            MenuItem newItem = new MenuItem(itemNumber, itemName, itemDescription, ingredients, Convert.ToDouble(price));
            Console.WriteLine($"{itemName} has been added to the menu.");
            _repo.AddItemToMenu(newItem);
        }
        //delete item from menu
        public void DeleteItemFromMenu()
        {
            Console.Clear();
            Console.WriteLine(" What is the item number of the item you want to remove from the menu?\n" +
                " Item Number: ");
        }
        //prints error message for invalid input
        public void InvalidInputMessage()
        {
            Console.Write("INVALID INPUT, press any key to retry ");
            Console.ReadKey();
        }
        public void ContinueMessage()
        {
            Console.Write("press any key to continue... ");
            Console.ReadKey();
        }

    }
}
