using KineticCoinJar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Models
{
    /// <summary>
    /// Abstract class of Currency
    /// </summary>
    public abstract class Currency
    {
        // Private Variables of class
        private float _value = 0.0f;
        private CurrencyCode.Type _currencyType;
        private char _currentSign;

        // Public Properties
        public float Value { get { return _value; } }
        public CurrencyCode.Type CurrencyType { get; private set; }
        public char CurrencySign { get; private set; }

        // first constructor when value is not specified
        public Currency(CurrencyCode.Type currencyType, char currencySign)
        {
            _currencyType = currencyType;
            _currentSign = currencySign;
        }

        // second constructor when value is specified
        public Currency(CurrencyCode.Type currencyType, char currencySign, float value)
        {
            _currencyType = currencyType;
            _currentSign = currencySign;
            _value = value;
        }
    }

    /// <summary>
    /// Class of US Currency to 
    /// </summary>
    public class USCurrency : Currency
    {
        // first constructor of class without price
        public USCurrency() : base(CurrencyCode.Type.USD, '$') { }
        // second constructor of class with price
        public USCurrency(float price) : base(CurrencyCode.Type.USD, '$', price) { }
        // define a new operator to add currency amounts
        public static USCurrency operator +(USCurrency currency1, USCurrency currency2)
        {
            return new USCurrency(currency1.Value + currency2.Value);
        }
    }

    /// <summary>
    /// Class of Volume
    /// </summary>
    public class Volume
    {
        // Public property of Unit 
        public double Unit { get; protected set; }
        // Define add operator to add values of two Volume
        public static Volume operator +(Volume volume1, Volume volume2)
        {
            return new Volume() { Unit = volume1.Unit + volume2.Unit };
        }
    }

    /// <summary>
    /// Class of FluidOunces which is messured as liquid
    /// </summary>
    public class FluidOunces : Volume
    {
        public FluidOunces()
        {
            Unit = 0.0f;
        }

        public FluidOunces(double unit)
        {
            Unit = unit;
        }
    }

    /// <summary>
    /// Abstract class of Coin
    /// </summary>
    /// <typeparam name="T">Currency type like USD or CAD</typeparam>
    public abstract class Coin<T> where T : Currency
    {
        // private variables
        private string _coinName = string.Empty;
        private FluidOunces _volume = new FluidOunces();
        private T _amount;

        // public properties
        public string CoinName { get { return _coinName; } }
        public FluidOunces Volume { get { return _volume; } }
        public T Amount { get { return _amount; } }

        // first constructor , not initialize coinName as parameter
        public Coin(FluidOunces volume, T amount)
        {
            _volume = volume;
            _amount = amount;
        }

        // second constructor , initialize coinName as parameter
        public Coin(string coinName, FluidOunces volume, T amount)
        {
            _coinName = coinName;
            _volume = volume;
            _amount = amount;
        }
    }

    /// <summary>
    /// Class of USCoin that inherts from Coin
    /// </summary>
    public class USCoin : Coin<USCurrency>
    {
        public USCoin(string coinName, float volume, float amount) : base(coinName, new FluidOunces(volume), new USCurrency(amount)) { }
    }

    /// <summary>
    /// Class of Cent
    /// </summary>
    public class Cent : USCoin
    {
        public Cent() : base("Cent", 0.0122f, 0.01f) { }
    }

    /// <summary>
    /// Class of Nickel
    /// </summary>
    public class Nickel : USCoin
    {
        public Nickel() : base("Nickel", 0.0243f, 0.05f) { }
    }

    /// <summary>
    /// Class of Dime
    /// </summary>
    public class Dime : USCoin
    {
        public Dime() : base("Dime", 0.0115f, 0.1f) { }
    }

    /// <summary>
    /// Class of Quarter
    /// </summary>
    public class Quarter : USCoin
    {
        public Quarter() : base("Quarter", 0.0270f, 0.25f) { }
    }

    /// <summary>
    /// Class of HalfDollar
    /// </summary>
    public class HalfDollar : USCoin
    {
        public HalfDollar() : base("HalfDollar", 0.0534f, 0.5f) { }
    }

    /// <summary>
    /// Class of Dollar Coin
    /// </summary>
    public class Dollar : USCoin
    {
        /// <summary>
        /// Each US Dollar weight is 8.1 gram = 0.285719 ounce. 
        /// </summary>
        public Dollar() : base("Dollar", 0.285719f, 1.0f) { }
    }
}