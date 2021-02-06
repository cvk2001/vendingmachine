using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Capstone.Classes;

namespace CapstoneTests.Vending_Machine_Tests
{
    [TestClass]
    public class VendingMachinetest
    {
        // Properties
        //-----------
        VendingMachine Machine = new VendingMachine();


        // Methods
        //--------
        private string GetWorkingDirectory()
        {
            // Arrange
            string directory = Environment.CurrentDirectory;

            for (int i = 0; i < 4; i++)
            {
                directory = Directory.GetParent(directory).ToString();
            }
            directory += @"\Capstone\bin\Debug\netcoreapp2.1";

            return directory;
        }

        [TestInitialize]
        public void Setup()
        {
            Machine = new VendingMachine();
        }

        [TestMethod]
        public void WriteLogBalanceTest()
        {
            // Arrange
            string directory = GetWorkingDirectory();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(directory, "log.txt")));
        }

        [TestMethod]
        public void WriteLogPurchaseTest()
        {
            // Arrange
            string directory = GetWorkingDirectory();

            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(directory, "log.txt")));
        }
    }
}
