using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
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
            Badge b1 = new Badge(111, new List<string>() {"A1","B1","C1" });
            Badge b2 = new Badge(222, new List<string>() {"A1","B2","C2" });
            Badge b3 = new Badge(333, new List<string>() {"A1","B3","C3" });
            _repo.AddBadge(b1);
            _repo.AddBadge(b2);
            _repo.AddBadge(b3);
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
                    "What would you like to do? ");
                string input = Console.ReadLine();

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
            Console.Write("What is the badge number to update? ");
            string badgeName = Console.ReadLine();
            Console.Write($"Badge {badgeName} has access to doors: ");
            List<string> doors = _repo.GetAllBadges()[Int32.Parse(badgeName)];
            foreach (string door in doors)
            {
                Console.Write(door + " ");
            }
            Console.Write("\nOptions:\n" +
                "(1) Add door\n" +
                "(2) Remove door\n" +
                "What would you like to do? ");
            string input = Console.ReadLine();
            string doorName;
            switch (Int32.Parse(input))
            {
                case 1:
                    Console.Write("Name of door: ");
                    doorName = Console.ReadLine();
                    _repo.UpdateBadge(Int32.Parse(badgeName), doorName);
                    Console.WriteLine("Door added.");
                    break;
                case 2:
                    Console.Write("Name of door: ");
                    doorName = Console.ReadLine();
                    _repo.DeleteBadge(Int32.Parse(badgeName), doorName);
                    Console.WriteLine("Door removed.");
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
            string input = Console.ReadLine();
            newBadge.BadgeID = Int32.Parse(input);
            bool moreDoorsToAdd = true;
            while (moreDoorsToAdd)
            {
                moreDoorsToAdd = false;
                Console.Write("\nList a door that it needs access to: ");
                listOfDoors.Add(Console.ReadLine());
                Console.Write("\nAny other doors(y/n)?: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "y":
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
                Console.Write("{0,-15}",key);
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
    }
}
