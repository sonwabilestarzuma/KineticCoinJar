using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Models
{
    /// <summary>
    /// public abstract generic class Coin Jar. 
    /// </summary>
    /// <typeparam name="T">Type of Currency like USCurrency</typeparam>
    public abstract class CoinJar<T> where T : Currency
    {
        // Maximum Volume that Coin Jar can hold
        public Volume MaxVolume { get; protected set; }
        // Current Amount of Coin Jar.
        public T CurrentAmount { get; protected set; }
        // Current Volume of Coin Jar
        public Volume CurrentVolume { get; protected set; }
        // List of Coins in Coin Jar
        public abstract IEnumerable<Coin<T>> Coins { get; }

        // Method to add a new coim
        public abstract void Add(Coin<T> coin);

        // Method to add a get total amount
        public abstract decimal GetTotalAmount();

        // Method to reset the Coin Jar
        public abstract void Reset();


    }

    /// <summary>
    /// US Coin jar which implemend actual Coin Jar.
    /// </summary>
    public class USCoinJar : CoinJar<USCurrency>
    {
        // define list of Coins
        private List<Coin<USCurrency>> _coins = new List<Coin<USCurrency>>();

        // List of Coins
        public override IEnumerable<Coin<USCurrency>> Coins
        {
            get { return _coins; }
        }

        // Default constructor of class
        public USCoinJar()
        {
            CurrentVolume = new FluidOunces();
            MaxVolume = new FluidOunces(42);
            Reset();
        }


        /// <summary>
        /// public method of Add coin
        /// </summary>
        /// <param name="coin">US coin that needs to be added</param>
        public override void Add(Coin<USCurrency> coin)
        {
            // if volume of Coin Jar is not enough to add a new coin, raise an appropriate exception
            if ((CurrentVolume.Unit + coin.Volume.Unit) > MaxVolume.Unit)
                // throw new CoinOverFlowException
                throw new CoinOverFlowException();

            _coins.Add(coin);
            CurrentVolume = CurrentVolume + (Volume)coin.Volume;
            CurrentAmount = CurrentAmount + coin.Amount;
        }

        /// <summary>
        /// Public method of Reset to release all coins
        /// </summary>
        public override void Reset()
        {
            _coins = new List<Coin<USCurrency>>();
            CurrentVolume = new FluidOunces();
            CurrentAmount = new USCurrency();
        }
        /// <summary>
        /// public method of Get total amount
        /// </summary>
        /// <param name="coin">getting total amount of coins </param>
        public override decimal GetTotalAmount()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Class of Coin OverFlow Exception that inherits from Exception
    /// </summary>
    public class CoinOverFlowException : Exception
    {
        // Set the appropriate Error Message during construction
        public CoinOverFlowException()
            : base("Coins overflowed the jar")
        {
        }
    }

}