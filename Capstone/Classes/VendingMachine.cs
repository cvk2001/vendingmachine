﻿using System;
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
                Console.WriteLine("There has been a file error after the program began. Please try again");
            }
            
            return false;
        }

        
        public bool WriteLogBalance(string transActionName, decimal amountOfTX)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt",true))
                {
                    sw.WriteLine($"{DateTime.Now} {transActionName}: {amountOfTX} {Balance}");
                }
            }catch (IOException e)
            {
                Console.WriteLine("something happened to the file");
            }

            return false;
        } public bool WriteLogPurchase(string productName, decimal initialBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now} {productName}: {initialBalance} {Balance}");
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
            }
            else
            {
                throw new ArgumentException("That is not a valid Bill");
            }
            WriteLogBalance("FEED MONEY",bill);

            return Balance;
        }
        public string DispenseItem(string slotLocation)
        {
            decimal initialBalance = Balance;
            Quantities[slotLocation]--;
            Balance -= Products[slotLocation].Price;
            WriteLogPurchase(Products[slotLocation].ProductName, initialBalance);
            return $"{Products[slotLocation].ProductName} {Products[slotLocation].Price} " +
                $"{Balance} \n {Products[slotLocation].Sound()}";
        }
        //private bool UpdateQuantity()
        //{
        //    return false;
        //}
        public Dictionary<string, int> GiveChange()
        {

            Dictionary<string, int> change = new Dictionary<string, int>();
            if (Balance % 20 == 0)
            {
                int twenties = Convert.ToInt32(Balance) / 20;
                change["twenties"] = twenties;
                Balance -= twenties * 20;
            }if (Balance % 10 == 0)
            {
                int tens = Convert.ToInt32(Balance) / 10;
                change["tens"] = tens;
                Balance -= tens * 10;
            }if (Balance % 5 == 0)
            {
                int fives = Convert.ToInt32(Balance) / 5;
                change["fives"] = fives;
                Balance -= fives * 5;
            }
            if (Balance % 1 == 0)
            {
                int ones = Convert.ToInt32(Balance);
                change["ones"] = ones;
                Balance -= ones;
            }
            if ((Balance*100) % 25 == 0)
            {
                int quarters = Convert.ToInt32(Balance*100) / 25;
                change["quarters"] = quarters;
                Balance -= quarters * 0.25M;
            }if ((Balance*100) % 10 == 0)
            {
                int dimes = Convert.ToInt32(Balance*100) / 10;
                change["dimes"] = dimes;
                Balance -= dimes * 0.10M;
            }if ((Balance*100) % 5 == 0)
            {
                int nickels = Convert.ToInt32(Balance*100) / 5;
                change["nickels"] = nickels;
                Balance -= nickels * 0.25M;
            }
                       
                change["pennies"] = Convert.ToInt32(Balance)*100;
                       
            return change;
            
        }
    }
}
