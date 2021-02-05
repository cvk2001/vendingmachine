using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace CapstoneTests.Vending_Machine_Tests
{[TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void FileExistTest()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            //Act
            bool actualResult = vendingMachine.Stock();
            //Assert
            Assert.IsTrue(actualResult);
        }
        [TestMethod]
        public void AddItemsHappyPathTest()
        {

        }
        [TestMethod]
        public void StockItemsHappyPathTest()
        {
            //Arrange
            VendingMachine vendingMachine = new VendingMachine();
            Dictionary<string, string> expectedDictionary = new Dictionary<string, string>();
            expectedDictionary["A1"] = "Potato Crisps";
            expectedDictionary["A2"] = "Stackers";
            expectedDictionary["A3"] = "Grain Waves";
            expectedDictionary["A4"] = "Could Popcorn";
            expectedDictionary["B1"] = "Moonpie";
            expectedDictionary["B2"] = "Cowtales";
            expectedDictionary["B3"] = "Wonka Bar";
            expectedDictionary["B4"] = "Crunchie";
            expectedDictionary["C1"] = "Cola";
            expectedDictionary["C2"] = "Dr. Salt";
            expectedDictionary["C3"] = "Mountain Melter";
            expectedDictionary["C4"] = "Heavy";
            expectedDictionary["D1"] = "U-Chews";
            expectedDictionary["D2"] = "Little League Chew";
            expectedDictionary["D3"] = "Chiclets";
            expectedDictionary["D4"] = "Triplemint";
            //Act
            vendingMachine.Stock();

            //assert
            CollectionAssert.AreEqual(expectedDictionary, vendingMachine.Products.Values);

        }

    }
}
