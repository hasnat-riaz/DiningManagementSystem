using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
   public class MealEntry
    {
       public int  memberId { get; set; }
       
       public int noOfMeals { get; set; }
       
       public DateTime mealEntryDate { get; set; }

       public MealEntry(int memberId, int noOfMeals, DateTime mealEntryDate):this()
       {
           this.memberId = memberId;
           this.noOfMeals = noOfMeals;
           this.mealEntryDate = mealEntryDate;
       }

       public MealEntry()
       {
       }

      
    }
}
