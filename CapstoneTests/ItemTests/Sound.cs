using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.ItemTests
{
    [TestClass]
    public class Sound
    {
        public Item TestItem { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            TestItem = new Candy("CandyBar", 1.00M);
        }

        [TestMethod]
        public void MakesSoundTest()
        {
            // Act
            string testSound = TestItem.Sound();

            // Assert
            Assert.AreEqual("Munch Munch, Yum!", testSound);
        }

    }
}
