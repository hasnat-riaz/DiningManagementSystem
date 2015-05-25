using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.manager.Validator
{
    public class BazarCostEntryValidator
    {
        public bool isValidCost(int amount)
        {
            try
            {
                if (!Regex.IsMatch(amount.ToString(), "^[0-9]"))
                {
                    throw new Exception(@"Digit Only!");
                }

                if ((amount < 100))
                {
                    throw new Exception(@"Amount should not be less than 100");
                }
                if (amount > 10000)
                {
                    throw new Exception(@"Amount should not be greater than 10000");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return true;
        }
    }
}
