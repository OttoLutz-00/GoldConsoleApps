using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedContent();
            Main();
        }
        public void SeedContent()
        {

        }
        public void Main()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Write("Choose a menu item:\n" +
                    "(1) See all claims\n" +
                    "(2) Take care of next claim" +
                    "(3) Enter a new claim\n" +
                    "What would you like to do? (1, 2, 3, or 4): ");
                string input = Console.ReadLine();
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

        }
        public void TakeCareOfNextClaim()
        {

        }
        public void EnterNewClaim()
        {

        }
    }
}
