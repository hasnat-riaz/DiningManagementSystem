using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
   public class BalanceEntry
    {
       public int  memberId { get; set; }
       public int  balance { get; set; }
       public DateTime balanceEntryDate { get; set; }

       public BalanceEntry(int memberId, int balance, DateTime balanceEntryDate)
           : this()
       {
           this.memberId = memberId;
           this.balance = balance;
           this.balanceEntryDate = balanceEntryDate;
       }

       public BalanceEntry()
       {
       }
    }
}
