using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();
        public void Run()
        {
            SeedContent();
            Main();
        }
        public void SeedContent()
        {
            Claim claim1 = new Claim(1, ClaimType.Theft, "Stolen pancake.", 24.00, new DateTime(2021, 7, 4), new DateTime(2021, 8, 2));
            Claim claim2 = new Claim(2, ClaimType.Car, "Car accident on 465.", 3275.00, new DateTime(2021, 7, 8), new DateTime(2021, 8, 4));
            Claim claim3 = new Claim(3, ClaimType.Home, "House fire in kitchen.", 5500.00, new DateTime(2021, 7, 9), new DateTime(2021, 8, 9));
            Claim claim4 = new Claim(4, ClaimType.Home, "House fire in bedroom.", 4000.00, new DateTime(2021, 8, 9), new DateTime(2021, 8, 11));
            Claim claim5 = new Claim(5, ClaimType.Theft, "Stolen TV.", 1150.00, new DateTime(2021, 9, 10), new DateTime(2021, 9, 12));
            Claim claim6 = new Claim(6, ClaimType.Car, "Wreck on 465.", 8500.00, new DateTime(2021, 9, 20), new DateTime(2021, 9, 27));
            _claimRepository.AddClaimToRepository(claim1);
            _claimRepository.AddClaimToRepository(claim2);
            _claimRepository.AddClaimToRepository(claim3);
            _claimRepository.AddClaimToRepository(claim4);
            _claimRepository.AddClaimToRepository(claim5);
            _claimRepository.AddClaimToRepository(claim6);
        }
        public void Main()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.Write("Choose a menu item:\n" +
                    "(1) See all claims\n" +
                    "(2) Take care of next claim\n" +
                    "(3) Enter a new claim\n" +
                    "(4) Exit\n" +
                    "What would you like to do? (1, 2, 3, or 4): ");
                string input = ValidateInputForNumber(Console.ReadLine(), 1, 4);
                switch (Convert.ToInt32(input))
                {
                    case 1:
                        DisplayClaims();
                        break;
                    case 2:
                        TakeCareOfNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void DisplayClaims()
        {
            Console.Clear();
            Console.WriteLine(" |ClaimID |Type        |Description                     |Amount         |DateOfAccident |DateOfClaim    |IsValid  |\n" +
                              " |________|____________|________________________________|_______________|_______________|_______________|_________|");
            foreach (Claim claim in _claimRepository.GetClaimRepository())
            {
                Console.WriteLine(claim);
            }
            ContinueMessage();
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("\n Here are the details for the next claim to be handled:\n");
            Console.WriteLine(" |ClaimID |Type        |Description                     |Amount         |DateOfAccident |DateOfClaim    |IsValid  |\n" +
                              " |________|____________|________________________________|_______________|_______________|_______________|_________|");
            if (_claimRepository.GetClaimRepository().Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no claims left.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine(_claimRepository.PeekNextClaim());
                Console.Write("\n Do you want to deal with this claim now(y/n)? ");
                string input = ValidateInputForStringYesOrNo(Console.ReadLine(), 3);
                switch (input)
                {
                    case "y":
                    case "ye":
                    case "yes":
                        _claimRepository.RemoveNextClaim();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Claim removed successfully!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Claim not removed.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            ContinueMessage();
        }
        public void EnterNewClaim()
        {
            Console.Clear();
            Console.Write("Enter the claim id: ");
            string input = Console.ReadLine();
            input = ValidateInputForNumber(input, 6, 999999);
            int claimID = Int32.Parse(input);
            ClaimType claimType = ClaimType.NA;
            while (claimType == ClaimType.NA)
            {
            Console.Write("Enter the claim type: ");
            input = Console.ReadLine();
                switch (input)
                {
                    case "Car":
                    case "car":
                    case "CAR":
                        claimType = ClaimType.Car;
                        break;
                    case "Theft":
                    case "theft":
                    case "THEFT":
                        claimType = ClaimType.Theft;
                        break;
                    case "Home":
                    case "home":
                    case "HOME":
                        claimType = ClaimType.Home;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid claim type, options are: (Car, Theft, or Home).");
                        Console.ForegroundColor = ConsoleColor.White;
                        claimType = ClaimType.NA;
                        break;
                }
            }
            Console.Write("Enter a claim description: ");
            string description = ValidateInputForString(Console.ReadLine(), 30);
            Console.Write("Amount of damage: ");
            string damage = ValidateInputForDouble(Console.ReadLine());
            Console.Write("Date of accident (month/day/year): ");
            string unSplitDates = ValidateInputForString(Console.ReadLine(), 13);
            DateTime dateOfIncident = MakeDateTime(unSplitDates);
            Console.Write("Date of claim (month/day/year): ");
            unSplitDates = ValidateInputForString(Console.ReadLine(), 13);
            DateTime dateOfClaim = MakeDateTime(unSplitDates);
            Claim claim = new Claim(claimID, claimType, description, Double.Parse(damage), dateOfIncident, dateOfClaim);
            if (claim.IsValid)
                Console.WriteLine("This claim is valid.");
            else
                Console.WriteLine("This claim is invalid.");
            _claimRepository.AddClaimToRepository(claim);
            ContinueMessage();
        }
        public DateTime MakeDateTime(string unSplitString)
        {
            string[] split = unSplitString.Split('/');
            int month, day, year;
            month = Convert.ToInt32(split[0]);
            day = Convert.ToInt32(split[1]);
            year = Convert.ToInt32(split[2]);
            DateTime newDate = new DateTime(year, month, day);
            return newDate;
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
        public string ValidateInputForDouble(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            while (!(double.TryParse(input, out double asDouble)) || !(Double.Parse(input) >= 0))
            {
                Console.Write($"\n INVALID INPUT: please enter a positive decimal: ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
