using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        // Constructor
        //------------
        public Chip(string productName, decimal price) : base(productName, price) { }

        // Methods
        //--------
        public override string Sound()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
