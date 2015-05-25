using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.manager.Validator
{
   public class BalanceEntryValidator
    {
        public bool isValidBalance(int balance)
        {
            try
            {
                if (!Regex.IsMatch(balance.ToString(), "^[0-9]"))
                {
                    throw new Exception(@"Digit Only!");
                }

                if ((balance < 100))
                {
                    throw new Exception(@"Balance should not be less than 100");
                }
                if (balance > 5000)
                {
                    throw new Exception(@"Balance should not be greater than 5000");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message,exception);
            }
            return true;
        }
    }
}
