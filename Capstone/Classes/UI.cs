using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {
        // Properties
        //-----------
        private VendingMachine infernalMachine { get; set; }

        // Constructor
        //------------

        // Methods
        //--------
        public void Start()
        {
            VendingMachine infernalMachine = new VendingMachine();
            //Console.WriteLine(Machine.Balance);

            bool doneShopping = false;
            string mainMenu = "";
            string purchaseMenu = "";
            string slotLocation = "";

            Console.WriteLine("Welcome to the Vending Machine!\n" +
                "We can supply you with all your snacking needs.");

            do
            {
                mainMenu = MainMenu();
                doneShopping = MainMenuSwitch(mainMenu);
            } while (!doneShopping);
            
        }
        private string MainMenu()
        {
            string choice = "";

            Console.Write("Please make a selection form the following options:\n" +
                "(1) Display Vending Machine Items\n" +
                "(2) Purchase\n" +
                "(3) Exit\n" +
                ">> ");
            choice = Console.ReadLine();

            while(choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("Sorry, please choose 1, 2, or 3: ");
                choice = Console.ReadLine();
            }

            return choice;
        }
        private string PurchaseMenu()
        {
            string choice = "";

            Console.Write("Please make a selection form the following options:\n" +
                "(1) Feed Money\n" +
                "(2) Select Product\n" +
                "(3) Finish Transaction\n" +
                $"Current Money Provided: \n" + //{Machine.Balance.ToString("C2").PadLeft(6)}\n" +
                $">>");
            choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Sorry, please choose 1, 2, or 3: ");
                choice = Console.ReadLine();
            }

            return choice;
        }
        private string ProductList()
        {
            string slotLocation = "";

            Console.WriteLine("Please select which item you would like to purchase:");

            foreach(KeyValuePair<string, Item> kvp in infernalMachine.Products)
            {
                string slot = kvp.Key;
                Item product = kvp.Value;
                Console.Write($"{slot}) {product.ProductName}");
                Console.WriteLine(infernalMachine.Quantities[slot].Equals(0) ? " Sold Out" : "");
            }
            Console.WriteLine();

            slotLocation = Console.ReadLine();

            return slotLocation;
        }
        private decimal FeedMoney()
        {
            decimal money = 0M;
            string bills = "";
            bool finished = false;
            string yn = "";

            do
            {
                bool validBill = false;

                Console.Write("Please enter the amount of mouney you would like to insert: ");
                bills = Console.ReadLine();

                do
                {
                    try             // This try should stay incase something is entered that is not a numeral.
                    {               // however, the checking if is valid bill should be moved to VendingMachine.
                        decimal temp = decimal.Parse(bills);
                        if (temp == 1 || temp == 2 || temp == 5 || temp == 10 || temp == 20 || temp == 50 || temp == 100)
                        {
                            money += temp;
                            validBill = true;
                            Console.WriteLine($"So far you have inserted {money.ToString("C2")}.\n");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter real money.");
                        validBill = false;
                    }

                    Console.Write("Please enter a valid bill: ");
                    bills = Console.ReadLine();
                    validBill = false;

                } while (!validBill);

                do
                {
                    Console.Write("Would you like to insert more (Y/N): ");
                    yn = Console.ReadLine().Trim().ToLower().Substring(0, 1);
                } while (yn != "y" && yn != "n");

                finished = yn == "y" ? true : false;

            } while (!finished);
            
            return money;
        }
        private bool MainMenuSwitch(string mainMenu)
        {
            bool doneShopping = false;
            string choice = "";

            switch (mainMenu)
            {
                case "1":
                    choice = ProductList();
                    break;
                case "2":
                    choice = PurchaseMenu();
                    break;
                case "3":
                    Console.WriteLine("Have a great day!");
                    doneShopping = true;
                    break;
                case "4":
                    Console.WriteLine("Ssshh... The secret file is not ready yet.\n");
                    break;
                default:
                    mainMenu = MainMenu();
                    break;
            }

            return doneShopping;
        }
    }
}
