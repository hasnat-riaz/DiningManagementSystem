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
   public class BazarCostEntryBLL
    {
       
       BazarCostEntryGateway aBazarCostEntryGateway=new BazarCostEntryGateway();
       public string save(BazarCostEntry aBazarCostEntry)
       {
           try
           {
               new BazarCostEntryValidator().isValidCost(aBazarCostEntry.amount);
               if ((aBazarCostEntry.amount == 0))
               {
                   return "please fill all the field";
               }
               else
               {
                   return aBazarCostEntryGateway.save(aBazarCostEntry);
               }
           }
           catch (Exception e)
           {
               
               throw new Exception(e.Message,e);
           }
       }
       public List<persistence.DAO.BazarCostEntry> getAllBazarCost()
       {
           return aBazarCostEntryGateway.getAllBazarCost();
       }

       public string deleteAll(string myId)
       {
           return aBazarCostEntryGateway.deleteAll(myId);
       }
    }
}
