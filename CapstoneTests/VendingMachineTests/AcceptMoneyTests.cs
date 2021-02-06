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

        [TestMethod]
        public void InvalidBillBalanceTest()
        {
            // Arrange
            List<decimal> bills = new List<decimal>() { 0.25M, 0.10M, 0, 3, 4, 15, 30, 45, 85, 101, 1000 };
            decimal balance = 0;

            // Act and Assert
            foreach (decimal bill in bills)
            {
                try
                {
                    Machine.AcceptMoney(bill);
                }
                catch (Exception e)
                {
                    // Need to ignore Exception to make sure that it is not adding the money to balance.
                }

                Assert.AreEqual(balance, Machine.Balance);
            }
        }

        [TestMethod]
        public void InvalidBillExceptionTest()
        {
            // Arrange
            List<decimal> bills = new List<decimal>() { 0.25M, 0.10M, 0, 3, 4, 15, 30, 45, 85, 101, 1000 };
            decimal balance = 0;
            string errorMessage = "";
            string expectedErrorMessage = "That is not a valid bill.";

            // Act and Assert
            foreach (decimal bill in bills)
            {
                try
                {
                    Machine.AcceptMoney(bill);
                } catch(Exception e)
                {
                    errorMessage = e.Message;
                }

                Assert.AreEqual(expectedErrorMessage, errorMessage);
            }
        }
    }
}
