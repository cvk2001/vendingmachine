using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        // Constructor
        //------------
        public Drink(string productName, decimal price) : base(productName, price) { }

        // Methods
        //--------
        public override string Sound()
        {
            return "Glug Glug, Yum!";
        }
    }
}
