using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiningManagementSystem.com.infy.persistence.Gateway;

namespace DiningManagementSystem.com.infy.manager.BLL
{
   public class LoginBLL
    {
       LoginGateway aLoginGateway = new LoginGateway();
       public string login(persistence.DAO.Login aLogin)
        {
            if (aLogin.userName == string.Empty || aLogin.password == string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                return aLoginGateway.login(aLogin);
            }
        }


       public string updatePassword(persistence.DAO.Login aLogin, string newPassword, string confirmPassword)
       {
           string msg = login(aLogin);
           if (msg.Equals("Yes"))
           {
               if (newPassword.Equals(confirmPassword))
               {
                  return aLoginGateway.updatePassword(aLogin,newPassword);
               }
               else
               {
                   throw new Exception(@"New Password doesn't match");
               }
           }
           else
           {
               throw new Exception(@"This user does not exists");
           }
       }
    }
}
