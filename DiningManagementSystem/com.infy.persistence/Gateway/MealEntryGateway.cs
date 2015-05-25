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
    public class MealEntryGateway:DBGateway
    {
        private List<MealEntry> aMealEntryList;
        public string save(DAO.MealEntry aMealEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPInsertIntoMeal", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@memberId",aMealEntry.memberId);
                command.Parameters.AddWithValue("@noOfMeals",aMealEntry.noOfMeals);
                command.Parameters.AddWithValue("@mealEntryDate", aMealEntry.mealEntryDate);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return @"Data saved successfully.";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (aSqlConnection != null && aSqlConnection.State == ConnectionState.Open)
                {
                    aSqlConnection.Close();
                }
            }
            return @"Error while saving data.";
        }

        public List<DAO.MealEntry> getAllMealEntryInfo()
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPMealEntries", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader aReader = command.ExecuteReader();
                aMealEntryList = new List<MealEntry>();
                if (aReader.HasRows)
                {
                    while (aReader.Read())
                    {
                        MealEntry aMealEntry=new MealEntry();
                        aMealEntry.memberId = (int)aReader[0];
                        aMealEntry.noOfMeals = Convert.ToInt32(aReader[1].ToString());
                        aMealEntry.mealEntryDate = (DateTime)aReader[2];
                        aMealEntryList.Add(aMealEntry);
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
            return aMealEntryList; 
        }

        public string deleteAll(string myId)
        {
            try
            {
                {
                    aSqlConnection.Open();
                    SqlCommand command = new SqlCommand("USPDeletionFromMeal", aSqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@memberId",myId);
                    int effectedRows = command.ExecuteNonQuery();
                    if (effectedRows > 0)
                    {
                        return @"Data deleted successfully.";
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
            return @"Error while deleting data.";
        }
    }
}
