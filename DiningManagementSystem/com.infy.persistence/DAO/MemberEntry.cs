using System;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
   public class MemberEntry
    {
       public int  memberId { get; set; }

       public string name { get; set; }

       public string  roomNo { get; set; }

       public string address { get; set; }

       public DateTime dateOfEntry { get; set; }

       public MemberEntry(string name, string roomNo, string address, DateTime dateOfEntry):this()
       {
           this.name = name;
           this.roomNo = roomNo;
           this.address = address;
           this.dateOfEntry = dateOfEntry;
       }

       public MemberEntry(int memberId, string name, string roomNo, string address, DateTime dateOfEntry):this()
       {
           this.memberId = memberId;
           this.name = name;
           this.roomNo = roomNo;
           this.address = address;
           this.dateOfEntry = dateOfEntry;
       }

       public MemberEntry()
       {
       }
    }
}
