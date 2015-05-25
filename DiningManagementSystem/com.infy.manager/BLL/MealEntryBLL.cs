using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiningManagementSystem.com.infy.persistence.Gateway;

namespace DiningManagementSystem.com.infy.manager.BLL
{
  public  class MealEntryBLL
    {
      MealEntryGateway aMealEntryGateway=new MealEntryGateway();
      public string save(persistence.DAO.MealEntry aMealEntry)
      {
          if ((aMealEntry.memberId == -1)||(aMealEntry.noOfMeals==-1))
          {
              return "please fill all the fields";
          }
          else
          {
              return aMealEntryGateway.save(aMealEntry);
          }
      }

      public List<persistence.DAO.MealEntry> getAllMealEntryInfo()
      {
          return aMealEntryGateway.getAllMealEntryInfo();
      }

      public string deleteAll(string myId)
      {
          return aMealEntryGateway.deleteAll(myId);
      }
    }
}
