using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.persistence.Gateway
{
   public class BazarCostEntryGateway:DBGateway
    {
       private List<BazarCostEntry> abazarCostEntryList;

       public string save(DAO.BazarCostEntry aBazarCostEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPInsertIntoBazar", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@amount", aBazarCostEntry.amount);
                command.Parameters.AddWithValue("@date", aBazarCostEntry.date);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return "Amount saved successfully.";
                }
            }
            catch (Exception e)
            {
                throw  new Exception(e.Message);
            }
            finally
            {
                if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
                {
                    aSqlConnection.Close();
                }
            }
            return "Error while saving amount.";
        }

       public List<DAO.BazarCostEntry> getAllBazarCost()
       {
           try
           {
               aSqlConnection.Open();
               SqlCommand command = new SqlCommand("uspBazarCost", aSqlConnection);
               command.CommandType = CommandType.StoredProcedure;
               SqlDataReader aReader = command.ExecuteReader();
               abazarCostEntryList = new List<BazarCostEntry>();
               if (aReader.HasRows)
               {
                   while (aReader.Read())
                   {
                      BazarCostEntry aBazarCostEntry=new BazarCostEntry();
                      aBazarCostEntry.id = (int) aReader[0];
                      aBazarCostEntry.amount = Convert.ToInt32(aReader[1].ToString());
                      aBazarCostEntry.date= (DateTime) aReader[2];
                      abazarCostEntryList.Add(aBazarCostEntry);
                   }
               }

           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message);
           }
           finally
           {
               if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
               {
                   aSqlConnection.Close();
               }
           }
           return abazarCostEntryList; 
       }

       public string deleteAll(string myId)
       {
            try
           {
               {
                   aSqlConnection.Open();
                   SqlCommand command = new SqlCommand("USPDeletionFromBazarCost",aSqlConnection);
                   command.CommandType = CommandType.StoredProcedure;
                   command.Parameters.AddWithValue("@id", myId);
                   int effectedRows = command.ExecuteNonQuery();
                   if (effectedRows > 0)
                   {
                       return "Amount deleted successfully.";
                   }
               }
           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message);
           }
           finally
           {
               aSqlConnection.Close();
           }
           return "Error while deleting amount.";
       }
       }
    }

