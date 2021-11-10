using KineticCoinJar.DataAccess;
using KineticCoinJar.IRepositories;
using KineticCoinJar.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KineticCoinJar.Repositories
{
    public class CoinJar : ICoinJar

    {
        private ConcurrentBag<ICoin> _coins = new ConcurrentBag<ICoin>();
        private ApplicationDbContext context;

        public CoinJar(ApplicationDbContext context)
        {
            this.context = context;
        }


        public void AddCoin(ICoin coin)
        {
            context.Coins.Add((Coin)coin);
            context.SaveChanges();
        }

        public decimal GetTotalAmount()
        {
            return context.Coins.Select(c => (decimal)c.Volume* (decimal)c.Amount).Sum() / 100m;
        }

        public void Reset()
        {
            //clear bag in a thread-safe way
            var newBag = new ConcurrentBag<ICoin>();
            Interlocked.Exchange(ref _coins, newBag);
        }
    }
}
