using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;


namespace CapstoneTests.VendingMachineTests
{
    [TestClass]
    public class AcceptMoneyTests
    {
        // Properties
        //-----------
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
            List<decimal> bills = new List<decimal>() { 1, 2, 5, 10, 20, 50, 100 };
            decimal balance = 0;

            // Act and Assert
            foreach (decimal bill in bills)
            {
                balance += bill;
                Assert.AreEqual(balance, Machine.AcceptMoney(bill));
            }
        }
    }
}
