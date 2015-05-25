using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.presentation.UI;

namespace DiningManagementSystem.com.infy.persistence.Gateway
{
   public class LoginGateway:DBGateway
    {
       public string login(DAO.Login aLogin)
        {
            try
            {
                {
                    aSqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("uspLogin",aSqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userName", aLogin.userName);
                    cmd.Parameters.AddWithValue("@password", aLogin.password);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        return "Yes";
                    }
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
            return "Sorry,try again";
        }

       internal string updatePassword(DAO.Login aLogin, string newPassword)
       {
           try
           {
               aSqlConnection.Open();
               SqlCommand command = new SqlCommand("USPPasswordUpdation", aSqlConnection);
               command.CommandType = CommandType.StoredProcedure;
            
               command.Parameters.AddWithValue("@password", newPassword);
               command.Parameters.AddWithValue("@userName", aLogin.userName);
               
               int effectedRows = command.ExecuteNonQuery();
               if (effectedRows > 0)
               {
                   return "Password is updated";
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
           return "Error while updating password.";
       }
    }
}
