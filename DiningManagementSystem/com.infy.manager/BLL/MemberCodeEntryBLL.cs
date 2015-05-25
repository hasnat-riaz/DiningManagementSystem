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
   public class MemberCodeEntryBLL
    {
      MemberCodeEntryGateway aMemberCodeEntryGateway=new MemberCodeEntryGateway();
       public string save(MemberEntry aMemberEntry)
        {
            if ((aMemberEntry.name == string.Empty)||(aMemberEntry.roomNo==string.Empty)||(aMemberEntry.address==string.Empty))
            {
                return "please fill up all field";
            }
            else
            {
                MemberEntryValidator validator = new MemberEntryValidator();
                validator.validateNameAndRoomNumber(aMemberEntry.name,aMemberEntry.roomNo);
                return aMemberCodeEntryGateway.save(aMemberEntry);
            }
        }


       public List<MemberEntry> getMemberCodeInfo()
       {
           return aMemberCodeEntryGateway.getMemberCodeInfo();
       }

       public string deleteAll(string myId)
       {
           return aMemberCodeEntryGateway.deleteAll(myId);
       }

       public string update(MemberEntry aMemberEntry)
       {
           new EditMemberCodeEntryValidator().isRoomNumberAndMemberNameValid(aMemberEntry.roomNo, aMemberEntry.name);
           return aMemberCodeEntryGateway.update(aMemberEntry);
       }
    }
}
