using KineticCoinJar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.IRepositories
{
    public interface ICoinJar<T> where T : Currency

    {    // Maximum Volume that Coin Jar can hold
        public Volume MaxVolume { get; protected set; }
        // Current Amount of Coin Jar.
        public T CurrentAmount { get; protected set; }
        // Current Volume of Coin Jar
        public Volume CurrentVolume { get; protected set; }
        // List of Coins in Coin Jar
        public abstract IEnumerable<Coin<T>> Coins { get; }

        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}