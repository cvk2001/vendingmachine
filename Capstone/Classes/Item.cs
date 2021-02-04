using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Item
    {
        // Properties
        //-----------
        public static string[] TypeOfProduct { get; } = new string[] { "Candy", "Chip", "Drink", "Gum" };
        public string SlotLocation { get; }
        public string ProductName { get; }
        public decimal Price { get; }

        // Constructor
        //------------
        public Item(string slotLocation, string productName, decimal price)
        {
            if(slotLocation != null)
            {
                SlotLocation = slotLocation;
            } else
            {
                throw new ArgumentException("Please make sure all slot locations are accurate.");
            }
            
            if(productName != null)
            {
                ProductName = productName;
            }
            else
            {
                throw new ArgumentException("Please make sure all product names are accurate.");
            }
            
            if(price > 0.0M)
            {
                Price = price;
            } else
            {
                throw new ArgumentException("Please make sure product prices are accurate.");
            }
            
        }

        // Methods
        //--------
        public abstract string Sound();
    }
}
