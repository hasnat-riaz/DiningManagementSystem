using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiningManagementSystem.com.infy.manager.Validator;
using DiningManagementSystem.com.infy.persistence.DAO;
using DiningManagementSystem.com.infy.persistence.Gateway;

namespace DiningManagementSystem.com.infy.manager.BLL
{
   public class BalanceEntryBLL
    {
       BalanceEntryGateway aBalanceEntryGateway=new BalanceEntryGateway();
       public string save(persistence.DAO.BalanceEntry aBalanceEntry)
       {
           List<BalanceEntry> allEntryList = aBalanceEntryGateway.getAllBalanceEntryInfo();
           BalanceEntryValidator aValidator = new BalanceEntryValidator();
           aValidator.isValidBalance(aBalanceEntry.balance);
           bool isMemberFound = false;
           int previousBalance = 0;
           foreach (var balanceEntry in allEntryList)
           {
               if (balanceEntry.memberId == aBalanceEntry.memberId)
               {
                   isMemberFound = true;
                   previousBalance = balanceEntry.balance;
                   break;
               }
           }
           if (isMemberFound)
           {
               aBalanceEntry.balance += previousBalance;
               return aBalanceEntryGateway.updateBalance(aBalanceEntry);
           }
           else
           {
                return aBalanceEntryGateway.save(aBalanceEntry);
           
           }
           
       }
       public List<persistence.DAO.BalanceEntry> getAllBalanceEntryInfo()
       {
           return aBalanceEntryGateway.getAllBalanceEntryInfo();
       }


       public string deleteAll(string myId)
       {
           return aBalanceEntryGateway.deleteAll(myId);
       }
    }
}
