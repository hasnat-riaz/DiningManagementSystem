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
    public class BalanceEntryGateway : DBGateway
    {
        private List<BalanceEntry> aBalanceEntryList;

        public string save(DAO.BalanceEntry aBalanceEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPInsertIntoBalance", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@memberId", aBalanceEntry.memberId);
                command.Parameters.AddWithValue("@balance",aBalanceEntry.balance);
                command.Parameters.AddWithValue("@balanceEntryDate", aBalanceEntry.balanceEntryDate);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return @"Balance saved successfully.";
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

        public List<DAO.BalanceEntry> getAllBalanceEntryInfo()
        {

            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPBalances", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader aReader = command.ExecuteReader();
                aBalanceEntryList = new List<BalanceEntry>();
                if (aReader.HasRows)
                {
                    while (aReader.Read())
                    {
                        BalanceEntry aBalanceEntry = new BalanceEntry();
                        aBalanceEntry.memberId = (int)aReader[0];
                        aBalanceEntry.balance = Convert.ToInt32(aReader[1].ToString());
                        aBalanceEntry.balanceEntryDate = (DateTime)aReader[2];
                        aBalanceEntryList.Add(aBalanceEntry);
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
            return aBalanceEntryList;
        }

        public string deleteAll(string myId)
        {
            try
            {
                {
                    aSqlConnection.Open();
                    SqlCommand command = new SqlCommand("USPDeletionFromBalance", aSqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@memberId", myId);
                    int effectedRows = command.ExecuteNonQuery();
                    if (effectedRows > 0)
                    {
                        return @"Balance deleted successfully.";
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

        public string updateBalance(BalanceEntry aBalanceEntry)
        {
            try
            {
                aSqlConnection.Open();
                SqlCommand command = new SqlCommand("USPBalanceUpdation", aSqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@memberId", aBalanceEntry.memberId);
                command.Parameters.AddWithValue("@balance", aBalanceEntry.balance);
                command.Parameters.AddWithValue("@balanceEntryDate", aBalanceEntry.balanceEntryDate);
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    return @"Balance is updated";
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
            return @"Error while updating data.";
        }
    }
}
