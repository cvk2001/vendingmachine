using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Capstone.Classes
{
    public class UI
    {
        // Properties
        //-----------
        private VendingMachine Machine { get; set; } = new VendingMachine();

        // Constructor
        //------------

        // Methods
        //--------
        public void Start()
        {
            // Main Menu
            // MainMenuChoice
            // MainMenuSwitch

            // 1) Print Product List

            // 2) Purchase Menu
            //          PurchaseMenuChoice
            //          PurchaseMenuSwitch
            //      1) Feed Money
            //      2) Select Product
            //          Print Product List
            //          SelectProduct
            //      3) Finish Transaction

            // 3) Exit

            // (Hidden) 4) Print Report

            VendingMachine Machine = new VendingMachine();
            bool keepShopping = true;

            Console.WriteLine("Welcome to the...\n");
            TitlePrint();
            Console.WriteLine("\n\n");

            do
            {
                keepShopping = MainMenuSwitch(MainMenuChoice());
            } while (keepShopping);

            Console.WriteLine("\nHave a great day!");
        }
        private string MainMenuChoice()
        {
            string choice = "";

            //Console.Clear();
            Console.Write("Please make a selection form the following options:\n" +
                "(1) Display Vending Machine Items\n" +
                "(2) Purchase\n" +
                "(3) Exit\n" +
                ">> ");
            choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.Write("Sorry, please choose 1, 2, or 3: ");
                choice = Console.ReadLine();
            }

            return choice;
        }
        private void MainMenuPrint()
        {

        }
        private bool MainMenuSwitch(string choice)
        {
            bool keepShopping = true;

            switch (choice)
            {
                case "1":
                    // Product List
                    ProductList();
                    break;
                case "2":
                    // Purchase Menu
                    PurchaseMenuSwitch();
                    break;
                case "3":
                    // Exit
                    keepShopping = false;
                    break;
                case "4":
                    // Print Sales Report
                    break;
                default:
                    keepShopping = true;
                    break;
            }

            return keepShopping;
        }
        private void ProductList()
        {
            Console.WriteLine(); // Give the previous menu some space.

            foreach (KeyValuePair<string, Item> kvp in Machine.Products)
            {
                string slot = kvp.Key;
                Item product = kvp.Value;

                Console.Write($"{slot}) {product.ProductName.PadRight(20)}" +
                    $"{product.Price.ToString("C2").PadLeft(6)}" +
                    $"{Machine.Quantities[slot].ToString().PadLeft(3)}");
                Console.WriteLine(Machine.Quantities[slot].Equals(0) ? " Sold Out" : "");
            }
            Console.WriteLine();
        }
        private string PurchaseMenuChoice()
        {
            string choice = "";

            Console.Write("\nPlease make a selection form the following options:\n" +
                "(1) Feed Money\n" +
                "(2) Select Product\n" +
                "(3) Finish Transaction\n" +
                $"Current Money Provided: {Machine.Balance.ToString("C2").PadLeft(6)}\n" +
                $">> ");
            choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3")
            {
                Console.Write("Sorry, please choose 1, 2, or 3: ");
                choice = Console.ReadLine();
            }

            return choice;
        }
        private void PurchaseMenuSwitch()
        {
            bool moreTransactions = true;
            string choice = "";

            do
            {
                choice = PurchaseMenuChoice();

                switch (choice)
                {
                    case "1":
                        // Feed Money
                        FeedMoney();
                        break;
                    case "2":
                        // Select Product
                        ProductList();
                        SelectProduct();
                        break;
                    case "3":
                        // Finish Transaction
                        PrintChange(Machine.GiveChange());
                        moreTransactions = false;
                        break;
                    default:
                        moreTransactions = true;
                        break;
                }
            } while (moreTransactions);
        }
        private decimal FeedMoney()
        {
            string bill = "";
            decimal balance = 0M;
            bool validBill = false;

            Console.Write("\nPlease enter the bill you would like to insert: ");
            bill = Console.ReadLine();

            do
            {
                try
                {
                    decimal temp = decimal.Parse(bill);
                    balance = Machine.AcceptMoney(temp);
                    validBill = true;
                    //Console.WriteLine($"\nSo far you have inserted {balance.ToString("C2")}.\n");
                    //Thread.Sleep(1500);
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.Write("Please enter a valid bill: ");
                    bill = Console.ReadLine();
                    validBill = false;
                }
            } while (!validBill);

            return balance;
        }
        private string SelectProduct()
        {
            string slotLocation = "";
            bool isDispensed = false;

            Console.Write("\nPlease select which item you would like to purchase: ");
            slotLocation = Console.ReadLine();

            do
            {
                try
                {
                    string itemPrintOut = Machine.DispenseItem(slotLocation);
                    Console.WriteLine(itemPrintOut);
                    isDispensed = true;
                } catch(Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}");
                    Console.Write("Please select another slot (q to return to purchase menu): ");
                    slotLocation = Console.ReadLine();
                    isDispensed = false;
                }

                if (slotLocation == "q")
                {
                    isDispensed = true;     // Exit the loop if the customer would like to enter more money.
                    Console.WriteLine("Returning to purchase menu.");
                    Thread.Sleep(1250);
                    Console.Clear();
                }

            } while (!isDispensed);
            

            return slotLocation;
        }
        private string PrintChange(Dictionary<string, int> change)
        {
            string printChange = "";

            Console.WriteLine("\nYour change is:");
            foreach (KeyValuePair<string, int> kvp in change)
            {
                printChange += $"{kvp.Key}:".PadRight(10) + $"{kvp.Value}\n".PadLeft(6);
            }

            printChange += "\n\n\n";

            Console.WriteLine(printChange);

            return printChange;
        }

        public void TitlePrint()
        {
            Random rand = new Random();

            string workingDirectory = Environment.CurrentDirectory;
            string titleFile = "TitleVendoMatic.txt";
            string fullPath = Path.Combine(workingDirectory, titleFile);

            ConsoleColor[] colors = new ConsoleColor[]
            {
                ConsoleColor.DarkRed,
                ConsoleColor.Red,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.DarkCyan,
                ConsoleColor.Blue
            };
            int colorIndex = rand.Next(colors.Length);

            Console.WindowWidth = 150;

            try
            {
                using(StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        if(colorIndex >= colors.Length)
                        {
                            colorIndex = 0;
                        }
                        Console.ForegroundColor = colors[colorIndex];
                        Console.WriteLine(sr.ReadLine());
                        colorIndex++;
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Vendo-Matic 800");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
