using KineticCoinJar.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Repositories
{
    public class Coin : ICoin

    {
        public decimal Amount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
