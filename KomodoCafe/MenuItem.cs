using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuItem
    {
        //properties
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemIngredients { get; set; }
        public double ItemPrice { get; set; }

        //constructors
        public MenuItem() { }
        public MenuItem(int itemNumber, string itemName, string itemDescription, string ingredients, double price)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            ItemDescription = itemDescription;
            ItemIngredients = ingredients;
            ItemPrice = price;
        }
        public override string ToString()
        {
            return $" - #{ItemNumber}, {ItemName} - - - - - - - - ${ItemPrice}\n" +
                $"   ·{ItemDescription}\n" +
                $"   ·{ItemIngredients}\n";
        }
    }
}






