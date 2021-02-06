using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests.VendingMachineTests
{
    [TestClass]
    public class GiveChangeTests
    {
        private VendingMachine Machine = new VendingMachine();

        [TestInitialize]
        public void SetUp()
        {
            Machine = new VendingMachine();
        }

        [TestMethod]
        public void HappyPathTest()
        {
            Dictionary<string, int> expectedPrintOut = new Dictionary<string, int>()
            {
                {"Twenties", 4},
                {"Tens", 1 },
                {"Fives", 1 },
                {"Ones", 1 },
                {"Quarters", 3 },
                {"Dimes", 2 },
            };
            Machine.AcceptMoney(100);
            Machine.DispenseItem("A1");

            // Act and Assert
            CollectionAssert.AreEqual(expectedPrintOut, Machine.GiveChange());
        }

        [TestMethod]
        public void ZeroBalanceTest()
        {
            Dictionary<string, int> expectedPrintOut = new Dictionary<string, int>();

            CollectionAssert.AreEqual(expectedPrintOut, Machine.GiveChange());
        }

        // Successful Failure
        [TestMethod]
        public void NegativeBalanceTest()
        {
            // Arrange
            Dictionary<string, int> expectedPrintOut = new Dictionary<string, int>();
            string expectedError = "Your Balance is insufficient. Please enter more bills, or select a different item.";

            try
            {
                Machine.DispenseItem("A1");

                CollectionAssert.AreEqual(expectedPrintOut, Machine.GiveChange());
            } catch(Exception e)
            {
                Assert.AreEqual(expectedError, e.Message);
            }
            
        }
    }
}
