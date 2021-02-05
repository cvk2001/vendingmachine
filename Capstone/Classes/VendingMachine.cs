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
        public decimal Balance { get; private set; } = 0;
        private string LogFile {get; set;}
        private string WorkingDirectory { get; }
        public Dictionary<string, Item> Products { get; private set; } = new Dictionary<string, Item>();
        public Dictionary<string, int> Quantities { get; private set; } = new Dictionary<string, int>();

        // Constructor
        //------------
        public VendingMachine()
        {
            Balance = 0;
            Stock();
        }

        // Methods
        //--------
        public bool Stock()
        {
            string directory = Environment.CurrentDirectory;    // Eventually we will want to have this set in the constructor to the Working Directory property.
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);

            Item temp;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream) 
                    { 
                        string line = sr.ReadLine();
                        string[] lineSeperated = line.Split('|');
                        string productName = lineSeperated[1];
                        decimal price = decimal.Parse(lineSeperated[2]);

                        switch (lineSeperated[3])
                        {
                            case "Candy":
                                temp = new Candy(productName,price);
                                break;
                            case "Chip":
                                temp = new Chip(productName, price);
                                break;
                            case "Drink":
                                temp = new Drink(productName, price);
                                break;
                            case "Gum":
                                temp = new Gum(productName, price);
                                break;
                            default:
                                throw new FormatException("Something is terribly wrong Dave");
                                break;
                        }
                        
                                                                    // This makes me think we should be setting the item name here and getting it from the vending machine though an item should know its name
                        Products[lineSeperated[0]] = temp;          // I tried some things with item, but what I tried didn't work.
                        Quantities[lineSeperated[0]] = 5;           // maybe the dictionary statement should read public Dictionary<string,string> Products{get; private set;} = new Dictionary<string,item>;?
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("There has been a file error after the program began. Please try again");
            }
            
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
