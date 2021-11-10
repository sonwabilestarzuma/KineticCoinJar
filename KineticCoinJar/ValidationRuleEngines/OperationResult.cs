using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.ValidationRuleEngines
{
    public class OperationResult
    {
        private readonly IDictionary<string, string> _errorMessages;

        public OperationResult()
        {
            _errorMessages = new Dictionary<string, string>();
        }

        public void AddErrorMessage(string errorKey, string errorMessage)
        {
            _errorMessages.Add(errorKey, errorMessage);
        }

        public void AddErrorMessages(IDictionary<string, string> errorMessages)
        {
            foreach (var errorMessage in errorMessages)
            {
                _errorMessages.Add(errorMessage);
            }
        }

        public IDictionary<string, string> GetErrorMessages()
        {
            return _errorMessages;
        }

        public bool HasErrors => _errorMessages.Any();

    }
}