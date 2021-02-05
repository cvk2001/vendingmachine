using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CapstoneTests.Vending_Machine_Tests
{
    [TestClass]
    public class VendingMachinetest
    {
        [TestMethod]
        public void WriteLogTest()
        {
            // Assert
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory + "log.txt")));
        }
    }
}
