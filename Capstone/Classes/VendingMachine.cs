using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        // Properties
        //-----------
        public decimal Balance { get; private set; }
        private string LogFile {get; set;}
        private string WorkingDirectory { get; }
        private Dictionary<string, Item> Products { get; set; } = new Dictionary<string, Item>();
        private Dictionary<string, int> Quantities { get; set; } = new Dictionary<string, int>();

        // Constructor
        //------------

        // Methods
        //--------
        public bool Stock()
        {
            return false;
        }
        public bool WriteLog()
        {
            return false;
        }
        public decimal AcceptMoney()
        {
            return Balance;
        }
        public decimal DispenseItem()
        {
            return Balance;
        }
        private bool UpdateQuantity()
        {
            return false;
        }
        public Dictionary<string, int> GiveChange()
        {
            return new Dictionary<string, int>()
            {
                {"a", 0 }
            };
        }
    }
}
