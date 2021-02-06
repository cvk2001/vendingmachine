using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.UITests
{
    [TestClass]
    public class MainMenuSwitchTests
    {
        public UI TestUI { get; set; } = new UI();

        [TestInitialize]
        public void SetUp()
        {
            TestUI = new UI();
        }

        // I realized that I don't know enough yet to test commandline inputs.
        // I would need to know how to echo I think.
        /*
        [DataTestMethod]
        [DataRow("1", "1")]
        [DataRow("2", "2")]
        [DataRow("3", "3")]
        [DataRow("4", "4")]
        public void HappyPath(string input, string output)
        {
            Assert.AreEqual(output, UI.MainMenu(input));
        }
        */

        // Error because MainMenuSwitch is private.
        //[DataTestClass]
        //[DataRow(1, true)]
        //[DataRow(2, true)]
        //[DataRow(3, true)]
        //[DataRow(4, true)]
        //public void MainMenuSwitchTrueTest(int choice, bool result)
        //{
        //    // Act and Assert
        //    Assert.IsTrue(UI.MainMenuSwitch(choice));
        //}
    }
}
