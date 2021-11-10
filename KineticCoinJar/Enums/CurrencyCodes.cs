using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KineticCoinJar.Enums
{
    /// <summary>
    /// Static Class of Currency Code
    /// </summary>
    public static class CurrencyCode
    {
        /// <summary>
        /// Type of currency
        /// </summary>
        public enum Type
        {
            USD,
            CAD
        }

        /// <summary>
        /// Static extension method of ToString to extend the current class so it can return the apprpriate name of currency types
        /// </summary>
        /// <param name="currentType">current currency type </param>
        /// <returns>name of currency in string</returns>
        public static string ToString(this Type currentType)
        {
            string result = string.Empty;
            switch (currentType)
            {
                case Type.USD: result = "US Dollar"; break;
                case Type.CAD: result = "Canadian Dollar"; break;
            }
            return result;
        }
    }
}
