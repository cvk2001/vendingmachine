using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Reflection;

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
            WorkingDirectory = Environment.CurrentDirectory;
            Stock();
        }

        // Methods
        //--------
        private void Stock()
        {
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(WorkingDirectory, fileName);

            Item temp;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineSeperated = line.Split('|',StringSplitOptions.RemoveEmptyEntries);
                        string productName = lineSeperated[1];
                        decimal price = decimal.Parse(lineSeperated[2]);

                        switch (lineSeperated[3])
                        {
                            case "Candy":
                                temp = new Candy(productName, price);
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
                                
                        }

                        Products[lineSeperated[0]] = temp;
                        Quantities[lineSeperated[0]] = 5;
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("There has been a file error after the program began. Please try again.");
            }
            catch(Exception e)
            {
                Console.WriteLine("An unexpected error occured. Please try again.");
            }
        }

        
        public bool WriteLogBalance(string transactionName, decimal amountOfTX)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt",true))
                {
                    sw.WriteLine($"{DateTime.Now} {transactionName.PadRight(23)}" +
                        $" {amountOfTX.ToString("C2").PadLeft(8)} {Balance.ToString("C2").PadLeft(8)}");
                }
            }catch (IOException e)
            {
                Console.WriteLine("something happened to the file");
            }

            return false;
        } public bool WriteLogPurchase(string productName, string slotLocation, decimal initialBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now} {productName.PadRight(20)}" +
                        $"{slotLocation.PadRight(4)}" +
                        $"{initialBalance.ToString("C2").PadLeft(8)} " +
                        $"{Balance.ToString("C2").PadLeft(8)}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("something happened to the file");
            }



            return false;
        }
        public decimal AcceptMoney(decimal bill)
        {
            
            if (bill == 1 || bill == 2 || bill == 5 || bill == 10 || bill == 20 || bill == 50 || bill == 100)
            {
                Balance += bill;
                WriteLogBalance("FEED MONEY:", bill);
            }
            else
            {
                throw new ArgumentException("That is not a valid bill.");
            }

            return Balance;
        }
        public string DispenseItem(string slotLocation)
        {
            string itemDispensed = "";

            if (Products.ContainsKey(slotLocation))
            {
                if(Quantities[slotLocation] > 0)
                {
                    if(Balance >= Products[slotLocation].Price)
                    {
                        decimal initialBalance = Balance;
                        Quantities[slotLocation]--;
                        Balance -= Products[slotLocation].Price;
                        WriteLogPurchase(Products[slotLocation].ProductName, slotLocation, initialBalance);
                        itemDispensed = $"\nThank you for purchasing: {Products[slotLocation].ProductName}\n" +
                            $"It cost {Products[slotLocation].Price.ToString("C2")}\n" +
                            $"Your current Balance is {Balance.ToString("C2")}\n" +
                            $"{Products[slotLocation].Sound()}";
                    }
                    else
                    {
                        throw new ArgumentException("Your Balance is insufficient. Please enter more bills, or select a different item.");
                    }
                }
                else
                {
                    throw new ArgumentException("The product you have selected is out of stock. Please select another item.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid slot. Please select an existing slot.");
            }

            return itemDispensed;
        }
        //private bool UpdateQuantity() // If we should ever decide to add a restock feature.
        //{
        //    return false;
        //}
        public Dictionary<string, int> GiveChange()
        {
            decimal intialBalance = Balance;

            Dictionary<string, int> change = new Dictionary<string, int>();

            Dictionary<string, decimal> denominationsOfChange = new Dictionary<string, decimal>()
            {
                {"Twenties", 20 },
                {"Tens", 10 },
                {"Fives", 5 },
                {"Ones", 1 },
                {"Quarters", 0.25M },
                {"Dimes", 0.10M },
                {"Nickles", 0.05M },
                {"Pennies", 0.01M }
            };

            foreach(KeyValuePair<string, decimal> kvp in denominationsOfChange)
            {
                string type = kvp.Key;
                decimal amount = kvp.Value;

                if(Balance / amount >= 1)
                {
                    int howMany = (int)(Balance / amount);
                    change[type] = howMany;
                    Balance -= howMany * amount;
                }
            }

            WriteLogBalance("GIVE CHANGE:", intialBalance);
                       
            return change;
        }
        public void HiddenSalesReport()
        {
            int itemCount = 0;
            Dictionary<string,int> salesItems = new Dictionary<string, int>();
            string fileName = "log.txt";
            string fullPath = Path.Combine(WorkingDirectory, fileName);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (!line.Contains("FEED") || !line.Contains("GIVE"))
                        { 

                            for (int i = 0; i < line.Length; i++)
                            {
                                
                                    //salesItems[line[3]] = itemCount + 1;
                            }
                        }
                        
                        
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found...no report for you");
            }catch (Exception e)
            {
                Console.WriteLine("Some other error occurred that Zach could not figure out");
            }
            try
            {
                using (StreamWriter sw = new StreamWriter("SalesReport" + DateTime.Now + ".txt"))
                {
                    sw.WriteLine($"{salesItems.Keys}|{salesItems.Values}");
                }
            }
            catch (FileNotFoundException error)
            {
                Console.WriteLine("something happened to the file");
            }catch (Exception e)
            {
                Console.WriteLine("Zach missed something again");
            }
                    
        }
    }
}


    

