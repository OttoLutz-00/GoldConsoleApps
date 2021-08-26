using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges2
{
    public class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            Main();
        }
        public void SeedContent()
        {
            Badge b1 = new Badge(123, new List<string>() { "A1", "B1", "C13" });
            Badge b2 = new Badge(22, new List<string>() { "A1", "B12", "C2" });
            Badge b3 = new Badge(111, new List<string>() { "A2", "B1", "C12" });
            Badge b4 = new Badge(333, new List<string>() { "A1", "B12", "C2" });
            Badge b5 = new Badge(576, new List<string>() { "A9", "B3", "C3", "D7" });
            _repo.AddBadge(b1);
            _repo.AddBadge(b2);
            _repo.AddBadge(b3);
            _repo.AddBadge(b4);
            _repo.AddBadge(b5);
        }
        public void Main()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.Write("Hello Security Admin\n" +
                    "(1) Add a badge\n" +
                    "(2) Edit a badge\n" +
                    "(3) List all badges\n" +
                    "(4) Exit\n" +
                    "What would you like to do? ");
                string input = ValidateInputForNumber(Console.ReadLine(), 1, 4);

                switch (Convert.ToInt32(input))
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        EditBadge();
                        break;
                    case 3:
                        ListAllBadges();
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            }
            ContinueMessage();
        }
        public void EditBadge()
        {
            Console.Clear();
            Console.Write("All badge numbers: ");
            foreach (KeyValuePair<int, List<string>> pair in _repo.GetAllBadges())
            {
                Console.Write(pair.Key + ", ");
            }
            Console.Write("\nWhat is the number of the badge to update? ");
            string badgeName = ValidateInputForNumber(Console.ReadLine(), 3, 999);
            while (!(_repo.GetAllBadges().ContainsKey(Int32.Parse(badgeName))))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n There was no badge with that number, enter a valid badge number: ");
                Console.ForegroundColor = ConsoleColor.White;
                badgeName = ValidateInputForNumber(Console.ReadLine(), 3, 999);
            }
            Console.Write($"\nBadge {badgeName} has access to doors: ");
            List<string> doors = _repo.GetAllBadges()[Int32.Parse(badgeName)];
            foreach (string door in doors)
            {
                Console.Write(door + " ");
            }
            Console.Write("\nOptions:\n" +
                "(1) Add door\n" +
                "(2) Remove door\n" +
                "What would you like to do? ");
            string input = ValidateInputForNumber(Console.ReadLine(), 1, 2);
            string doorName;
            switch (Int32.Parse(input))
            {
                case 1:
                    Console.Write("Name of door: ");
                    doorName = ValidateInputForString(Console.ReadLine(), 4);
                    _repo.UpdateBadge(Int32.Parse(badgeName), doorName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Door added.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.Write("Name of door: ");
                    doorName = ValidateInputForString(Console.ReadLine(), 4);
                    while (!(_repo.GetAllBadges()[Int32.Parse(badgeName)].Contains(doorName)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n There is no door with that name, enter a different door to remove: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        doorName = ValidateInputForString(Console.ReadLine(), 4);
                    }
                    _repo.DeleteBadge(Int32.Parse(badgeName), doorName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Door removed.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
            ContinueMessage();
        }
        public void AddBadge()
        {
            Badge newBadge = new Badge();
            List<string> listOfDoors = new List<string>();
            Console.Clear();
            Console.Write("What is the number on the badge: ");
            string input = ValidateInputForNumber(Console.ReadLine(), 3, 999);
            while (_repo.GetAllBadges().ContainsKey(Int32.Parse(input)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nA badge with that key already exists, pick a different number: ");
                Console.ForegroundColor = ConsoleColor.White;
                input = ValidateInputForNumber(Console.ReadLine(), 3, 999);
            }
            newBadge.BadgeID = Int32.Parse(input);
            bool moreDoorsToAdd = true;
            while (moreDoorsToAdd)
            {
                moreDoorsToAdd = false;
                Console.Write("\nList a door that it needs access to: ");
                listOfDoors.Add(ValidateInputForString(Console.ReadLine(), 4));
                Console.Write("\nAny other doors(y/n)?: ");
                input = ValidateInputForStringYesOrNo(Console.ReadLine(), 3);
                switch (input)
                {
                    case "y":
                    case "ye":
                    case "yes":
                        moreDoorsToAdd = true;
                        break;
                    default:
                        break;
                }
            }
            newBadge.AccessibleDoors = listOfDoors;
            _repo.AddBadge(newBadge);
            ContinueMessage();
        }
        public void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Key\nBadge#         Door Access");
            foreach (KeyValuePair<int, List<string>> element in _repo.GetAllBadges())
            {
                int key = element.Key;
                List<string> values = element.Value;
                Console.Write("{0,-15}", key);
                foreach (string door in values)
                {
                    Console.Write(door + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            ContinueMessage();
        }
        public void ContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress any key to continue... ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        public string ValidateInputForNumber(string input, int maxDigits, int maxNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(input.Length <= maxDigits) || !(int.TryParse(input, out int asInt)) || !(Int32.Parse(input) > 0) || !(Int32.Parse(input) <= maxNumber))
            {
                Console.Write($"\n INVALID INPUT: please enter a positive number that is {maxDigits} digit(s) or less and less than or equal to {maxNumber}: ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
        public string ValidateInputForStringYesOrNo(string input, int maxCharacters)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(input.Length <= maxCharacters) || string.IsNullOrEmpty(input) || !(input == "y" || input == "ye" || input == "yes" || input == "n" || input == "no"))
            {
                Console.Write($"\n INVALID INPUT: please enter a 'yes' or 'no': ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
        public string ValidateInputForString(string input, int maxCharacters)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(input.Length <= maxCharacters) || string.IsNullOrEmpty(input))
            {
                Console.Write($"\n INVALID INPUT: please enter a valid string of characters that contains less than {maxCharacters + 1} characters: ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
