using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests.VendingMachineTests
{
    [TestClass]
    public class DispenseItemTests
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
            // Arrange
            Dictionary<string, string> expectedPrintOut = new Dictionary<string, string>() 
            {
                {"name", "Potato Crisps"},
                {"price", "$3.05" },
                {"balance", "$1.95" },
                {"sound", "Crunch Crunch, Yum!" }
            };
            Machine.AcceptMoney(5);

            // Act and Assert
            CollectionAssert.AreEqual(expectedPrintOut, Machine.DispenseItem("A1"));
        }

        [TestMethod]
        public void LowerCase()
        {
            // Arrange
            Dictionary<string, string> expectedPrintOut = new Dictionary<string, string>()
            {
                {"name", "Potato Crisps"},
                {"price", "$3.05" },
                {"balance", "$1.95" },
                {"sound", "Crunch Crunch, Yum!" }
            };
            Machine.AcceptMoney(5);

            // Act and Assert
            CollectionAssert.AreEqual(expectedPrintOut, Machine.DispenseItem("a1"));
        }

        [TestMethod]
        public void InvalidSlot()
        {
            // Arrange
            string expectedErrorMessage = "Invalid slot. Please select an existing slot.";
            string errorMessage = "";

            // Act and Assert
            try
            {
                Machine.DispenseItem("z9");
            }catch(Exception e)
            {
                errorMessage = e.Message;
            }

            Assert.AreEqual(expectedErrorMessage, errorMessage);
        }
    }
}
