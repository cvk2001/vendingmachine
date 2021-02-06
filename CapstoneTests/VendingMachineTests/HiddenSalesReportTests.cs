using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using System.IO;

namespace CapstoneTests.VendingMachineTests
{
    [TestClass]
    public class HiddenSalesReportTests
    {
        private VendingMachine Machine = new VendingMachine();

        [TestInitialize]
        public void Setup()
        {
            Machine = new VendingMachine();
        }

        [TestMethod]
        public void HiddenSalesReportFileExistsTest()
        {
            // Arrange
            //string directory = GetWorkingDirectory();
            Machine.AcceptMoney(5);
            Machine.DispenseItem("A1");
            Machine.HiddenSalesReport();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, $"SalesReport{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.txt")));
        }
    }
}
