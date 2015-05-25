using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.manager.Validator
{
    public class EditMemberCodeEntryValidator
    {
        private bool isThisRoomNumberValid(string roomNumber)
        {
            try
            {
                bool hasSpecialCharacter = false;
                bool isDigitPresent = false;
                bool isAlphabetPresent = false;
                foreach (var c in roomNumber)
                {
                    if ((c.ToString().Contains("@")) || (c.ToString().Contains("!")
                        || (c.ToString().Contains("#")) || (c.ToString().Contains("+"))
                        || (c.ToString().Contains("-")) || (c.ToString().Contains("="))
                        || (c.ToString().Contains("~")) || (c.ToString().Contains("_"))
                        || (c.ToString().Contains("$")) || (c.ToString().Contains("%"))
                        || (c.ToString().Contains("^") || (c.ToString().Contains("&"))
                        || (c.ToString().Contains("<") || (c.ToString().Contains(">"))
                        || (c.ToString().Contains(":") || (c.ToString().Contains("'"))
                        || (c.ToString().Contains(",") || (c.ToString().Contains(";"))
                        || (c.ToString().Contains("?"))) || (c.ToString().Contains("*")))))))
                    {
                        hasSpecialCharacter = true;
                        break;
                    }
                }
                if (hasSpecialCharacter)
                {
                    throw new Exception(@"Special Characters not allowed.");
                }
                foreach (char c in roomNumber)
                {
                    if (c >= '0' && c <= '9')
                    {
                        isDigitPresent = true;
                        break;
                    }
                }
                if (!isDigitPresent)
                {
                    throw new Exception(@"Room number must contain digit.");
                }
                foreach (char c in roomNumber)
                {
                    if (c > 'a' && c < 'z')
                    {
                        isAlphabetPresent = true;
                        break;
                    }
                    else if (c > 'A' && c < 'Z')
                    {
                        isAlphabetPresent = true;
                        break;
                    }
                }
                if (!isAlphabetPresent)
                {
                    throw new Exception(@"Room number must contain alphabet.");
                }
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        private bool isMemberNameValid(string name)
        {
            try
            {
                if (!Regex.IsMatch(name, "^[a-zA-Z ]"))
                {
                    throw new Exception(@"Please enter valid name");
                }
                if (name.Length < 3)
                {
                    throw new Exception(@"Name should be more than 2 digits");
                }
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }


        public bool isRoomNumberAndMemberNameValid(string roomNumber, string name)
        {
            if (isThisRoomNumberValid(roomNumber) && isMemberNameValid(name))
                return true;
            return false;
        }
    }
}
