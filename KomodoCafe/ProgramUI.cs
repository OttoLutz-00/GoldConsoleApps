using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//TODO
//input validation
namespace KomodoCafe
{
    class ProgramUI
    {
        //field
        private readonly MenuRepository _repo = new MenuRepository();
        //seeds content and runs the menu
        public void Run()
        {
            SeedContent();
            Menu();
        }
        //adds what should already be on the menu
        public void SeedContent()
        {
            Console.Write("Seeding Content");
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }
            MenuItem item1 = new MenuItem(1, "French Bread", "This is a classic item number 1, straight out the dinglebop.", "pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 13.95);
            MenuItem item2 = new MenuItem(2, "Ravioli", "This is a customer-favorite, fresh out the uh machine.", "corn, pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 19.95);
            MenuItem item3 = new MenuItem(3, "Big Pizza", "This is a special item only made here at Komodo Cafe, it's home baked inside our famous thing.", "so many beans, pepper, salt, tomatoes, ketchup, lettuce, mayo, and non-digestable plastic", 23.95);
            _repo.AddItemToMenu(item1);
            _repo.AddItemToMenu(item2);
            _repo.AddItemToMenu(item3);
        }
        //puts the user in the menu with all the options
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                DisplayWelcome();
                string input = Console.ReadLine();
                input = validateInputForNumber(input, 1);
                switch (Int32.Parse(input))
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n INPUT OUT OF BOUNDS: Please enter a number between 1 and 4. Press any key to retry.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        break;
                }
            }
            Console.Clear();
            string closingMessage = "Saving Menu, Please Do Not Close The Program...";
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (char letter in closingMessage)
            {
                Thread.Sleep(70);
                Console.Write(letter);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(2000);
            Console.WriteLine("\n All Done!");
            Thread.Sleep(2000);
        }
        //takes in a string, makes sure it is not null, is less than or equal to the max number of digits, and can be parsed into a double without error. returns a valid string.
        public string validateInputForNumber(string input, int maxDigits)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(input.Length <= maxDigits) || !(int.TryParse(input, out int asInt)) || !(Int32.Parse(input) >= 0))
            {
                Console.Write($"\n INVALID INPUT: please enter a positive number that is {maxDigits} digit(s) or less: ");
                input = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
        //takes in a string, makes sure it is not null, is positive, and can be parsed into a double without error. returns a valid string.
        public string validateInputForDouble(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(double.TryParse(input, out double asDouble)) || !(Double.Parse(input) >= 0))
            {
                Console.Write($"\n INVALID INPUT: please enter a positive decimal: ");
                input = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
        //takes in a string, makes sure it is not null and is less than or equal to the max number of characters. returns a valid string.
        public string validateInputForString(string input, int maxCharacters)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(input.Length <= maxCharacters) || string.IsNullOrEmpty(input))
            {
                Console.Write($"\n INVALID INPUT: please enter a valid string of characters that is less than or equal to {maxCharacters} characters: ");
                input = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
        //prints the welcome message and the menu options
        public void DisplayWelcome()
        {
            Console.Write("\n   Komodo Cafe Menu Editor\n\n" +
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
            Console.WriteLine("\n  Komodo Cafe Menu\n");
            foreach (MenuItem item in _repo.GetMenu())
            {
                Console.WriteLine(" " + item);
            }
            ContinueMessage();
        }
        //add item to menu
        public void AddItemToMenu()
        {
            Console.Clear();
            Console.Write("\n Item number: ");
            string itemNumber = Console.ReadLine();
            //this will make sure the itemNumber is valid and within the specified maximum of 2 digits. and can be parsed into an int without error.
            itemNumber = validateInputForNumber(itemNumber,2);
            Console.Write("\n Item name: ");
            string itemName = Console.ReadLine();
            //this will make sure the itemName is valid and within the specified maximum of 100 characters.
            itemName = validateInputForString(itemName, 100);
            Console.Write("\n Item description:  ");
            string itemDescription = Console.ReadLine();
            //this will make sure the itemDescription is valid and within the specified maximum of 140 characters.
            itemDescription = validateInputForString(itemDescription, 140);
            Console.Write("\n Item ingredients: ");
            string ingredients = Console.ReadLine();
            //this will make sure the ingredients is valid and within the specified maximum of 140 characters.
            ingredients = validateInputForString(ingredients, 140);
            Console.Write("\n Item price: ");
            string price = Console.ReadLine();
            //this will make sure the price is valid, and can be parsed into a double without error.
            price = validateInputForDouble(price);
            MenuItem newItem = new MenuItem(Convert.ToInt32(itemNumber), itemName, itemDescription, ingredients, Convert.ToDouble(price));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n {itemName} has been added to the menu.\n ");
            Console.ForegroundColor = ConsoleColor.White;
            _repo.AddItemToMenu(newItem);
            Thread.Sleep(2000);
            ContinueMessage();
        }
        //delete item from menu
        public void DeleteItemFromMenu()
        {
            Console.Clear();
            Console.WriteLine(" What is the item number of the item you want to remove from the menu?\n" +
                " Item Number: ");
            string input = Console.ReadLine();
            //this will make sure the itemNumber is valid and within the specified maximum of 2 digits. and can be parsed into an int without error.
            input = validateInputForNumber(input,2);
            string itemNumber = _repo.GetMenuItemByItemNumber(Convert.ToInt32(input)).ItemName;
            if(_repo.RemoveItemFromMenu(Convert.ToInt32(input)))
                Console.WriteLine($"{itemNumber} removed successfully");
            else
                Console.WriteLine("Could not find an item with that number.");
            ContinueMessage();
        }
        //prints error message for invalid input
        public void InvalidInputMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("INVALID INPUT: if this code is ever reached, that means the validateInput(input) method did not work properly. ");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        //waits for the user input to move on to the next screen
        public void ContinueMessage()
        {
            Console.Write(" press any key to continue... ");
            Console.ReadKey();
        }

    }
}
