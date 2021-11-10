using KineticCoinJar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KineticTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        private USCoinJar usCoinJar;
        public UnitTest()
        {
            usCoinJar = new USCoinJar() { };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateANewUSCoin()
        {
            Quarter quarter = new Quarter();
            Assert.AreEqual(quarter.Amount.Value, 0.25f);
        }

        [TestMethod]
        public void CreateListOfCoins()
        {
            List<USCoin> coins = new List<USCoin>();
            coins.Add(new Cent());
            coins.Add(new Dime());
            coins.Add(new Quarter());

            Assert.IsTrue(coins.Count > 0);
        }


        [TestMethod]
        public void AddCoinToJar()
        {
            usCoinJar.Add(new Dollar());
            Assert.IsTrue(usCoinJar.Coins.Count() > 0);
        }

        [TestMethod]
        public void ResetACoinJar()
        {
            usCoinJar.Reset();
            Assert.IsTrue(usCoinJar.Coins.Count() == 0);
            Assert.IsTrue(usCoinJar.CurrentAmount.Value == 0.0f);
            Assert.IsTrue(usCoinJar.CurrentVolume.Unit == 0);
        }

        [TestMethod]
        public void AddOverflowCoin()
        {
            //Define an inline function to add multiple of coins
            Func<USCoin, byte, USCoinJar> AddCoins = (usCoin, count) =>
            {
                for (byte i = 0; i < count; i++)
                    usCoinJar.Add(usCoin);
                return usCoinJar;
            };

            try
            {
                //Add coins to the list of Coins in Jar
                AddCoins(new Dollar(), 200);
                AddCoins(new HalfDollar(), 100);
            }
            catch (Exception Ex)
            {
                Assert.AreSame(Ex.Message, "Coins overflowed the jar");
            }
        }
    }
}