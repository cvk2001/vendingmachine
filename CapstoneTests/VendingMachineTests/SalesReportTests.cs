using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using System.IO;

namespace CapstoneTests.VendingMachineTests
{
    [TestClass]
    public class SalesReportTests
    {
        private VendingMachine Machine = new VendingMachine();

        [TestInitialize]
        public void Setup()
        {
            Machine = new VendingMachine();
        }

        [TestMethod]
        public void SalesReportFileExistsTest()
        {
            // Arrange
            //string directory = GetWorkingDirectory();
            Machine.AcceptMoney(5);
            Machine.DispenseItem("A1");

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "ongoingsales.txt")));
        }
    }
}
