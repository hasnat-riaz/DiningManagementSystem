using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningManagementSystem.com.infy.manager.Validator
{
    public class MemberEntryValidator
    {
        private bool validateName(String name)
        {
            try
            {
                //if (!Regex.IsMatch(name,"^[a-zA-Z ]"))
                //{
                //    throw new Exception("Enter Valid name");
                //}
                if (name.Length<3)
                {
                    throw new Exception(@"Name length should be more than 2");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        private bool validateRoomNumber(String roomNo)
        {
            try
            {
                if (!Regex.IsMatch(roomNo, "^[0-9]"))
                {
                    throw new Exception(@"Enter valid Room Number");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public bool validateNameAndRoomNumber(String name, String roomNo)
        {
            try
            {
                validateName(name);
                validateRoomNumber(roomNo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
