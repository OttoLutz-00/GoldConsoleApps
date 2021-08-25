using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceBadges
{
    public class ProgramUI
    {
       //private thing
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
