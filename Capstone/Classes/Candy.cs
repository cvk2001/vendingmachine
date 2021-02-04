using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        // Constructor
        //------------
        public Candy(string productName, decimal price) : base(productName, price) { }

        // Methods
        //--------
        public override string Sound()
        {
            return "Munch Munch, Yum!";
        }
    }
}
