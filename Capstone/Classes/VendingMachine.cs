using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        // Properties
        //-----------
        public decimal Balance { get; private set; }
        private string LogFile {get; set;}
        public int Quantity { get; private set; }
        private Dictionary<string, Item> Products { get; set; } = new Dictionary<string, Item>();

        // Constructor
        //------------

        // Methods
        //--------
    }
}
