using Microsoft.VisualStudio.Services.Licensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.ValidationRuleEngines
{
    public interface IValidationRule<in T>
    {
        OperationResult Validate(T entity);
    }
}