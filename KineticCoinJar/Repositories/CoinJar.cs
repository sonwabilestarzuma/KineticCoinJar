using KineticCoinJar.DataAccess;
using KineticCoinJar.IRepositories;
using KineticCoinJar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Repositories
{
    public class CoinJar : ICoinJar

    {
        private ApplicationDbContext context;

        public CoinJar(ApplicationDbContext context)
        {
            this.context = context;
        }


        public void AddCoin(ICoin coin)
        {
            // if volume of Coin Jar is not enough to add a new coin, raise an appropriate exception
            if ((CurrentVolume.Unit + coin.Volume.Unit) > MaxVolume.Unit)
                // throw new CoinOverFlowException
                throw new CoinOverFlowException();

            _coins.Add(coin);
            CurrentVolume = CurrentVolume + (Volume)coin.Volume;
            CurrentAmount = CurrentAmount + coin.Amount;
        }

        public decimal GetTotalAmount()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
