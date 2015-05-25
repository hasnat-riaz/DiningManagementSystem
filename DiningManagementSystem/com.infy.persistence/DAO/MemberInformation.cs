using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningManagementSystem.com.infy.persistence.DAO
{
    public class MemberInformation
    {
        public int memberId { get; set; }
        public string borderName { get; set; }
        public string roomNo { get; set; }
        public int noOfMeals { get; set; }
        public int balance { get; set; }
        public double individualMealCost { get; set; }
        public double amountToBeGiven { get; set; }
        public double amountToBePaid { get; set; }
    }
}
