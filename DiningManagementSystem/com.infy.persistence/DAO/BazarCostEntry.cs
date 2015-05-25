using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
   public class BazarCostEntry
    {
       public int id { get; set; }
       public int amount { get; set; }
       public DateTime date { get; set; }

       public BazarCostEntry(int amount, DateTime date):this()
       {
           this.amount = amount;
           this.date = date;
       }

       public BazarCostEntry()
       {
       }
    }
}
