using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.ItemTests
{
    [TestClass]
    public class SoundTests
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
            // Arange
            Dictionary<Item, string> allItems = new Dictionary<Item, string>()
            {
                { new Candy("CandyBar", 1.00M), "Munch Munch, Yum!" },
                { new Chip("Tortillas", 0.50M), "Crunch Crunch, Yum!" },
                { new Drink("Kool-Aid", 2.50M), "Glug Glug, Yum!" },
                { new Gum("Zabra", 0.05M), "Chew Chew, Yum!" }
            };

            foreach(KeyValuePair<Item, string> kvp in allItems)
            {
                // Act
                string testSound = kvp.Key.Sound();

                // Assert
                Assert.AreEqual(kvp.Value, testSound);
            }
        }

    }
}
