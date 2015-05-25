using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
   public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }

        public Login(string userName, string password)
            : this()
        {
            this.userName = userName;
            this.password = password;
        }

        public Login()
        {
        }
    }
}
