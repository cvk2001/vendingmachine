using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        // Constructor
        //------------
        public Gum(string productName, decimal price) : base(productName, price) { }

        // Methods
        //--------
        public override string Sound()
        {
            return "Chew Chew, Yum!";
        }
    }
}
