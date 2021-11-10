using KineticCoinJar.IRepositories;
using KineticCoinJar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.ValidationRuleEngines
{
    public class CoinJarValidationRuleEngine : AbstractValidationRuleEngine<ICoin>
    {
        public CoinJarValidationRuleEngine(ICoinJar coinJar)
        {
            ValidationRules.Add(new MaxFluidOunceValidatorRule(coinJar));
        }
    }
}