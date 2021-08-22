using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuItem
    {
        //fields, not sure if every challenge needs a field, but just in case i am pretending that in this challenge the ingredients are something secret, like the Krabby Patty Formula, and should not be easily changed.
        private readonly string SecretIngredients;
        //properties
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }

        //constructors
        public MenuItem() { }
        public MenuItem(int itemNumber, string itemName, string itemDescription, string ingredients, double price)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            SecretIngredients = ingredients;
            ItemPrice = price;
        }
        public override string ToString()
        {
            return $" - #{ItemNumber}, {ItemName} - - - - - - - - ${ItemPrice}\n" +
                $"   ·{ItemDescription}\n" +
                $"   ·{SecretIngredients}\n";
        }
    }
}






