using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiningManagementSystem.com.infy.persistence.DAO;
using DiningManagementSystem.com.infy.persistence.Gateway;

namespace DiningManagementSystem.com.infy.manager.BLL
{
    public class MemberInformationBLL
    {
        private List<MealEntry> mealEntryList = new MealEntryGateway().getAllMealEntryInfo();
        private List<BalanceEntry> balanceEntryList = new BalanceEntryGateway().getAllBalanceEntryInfo();
        private List<MemberEntry> memberEntryList = new MemberCodeEntryGateway().getMemberCodeInfo();
        private List<BazarCostEntry> bazarCostEntryList = new BazarCostEntryGateway().getAllBazarCost(); 
        private List<MemberInformation> memberInformationList;
        public int totalNoOfMeals = 0;
        public double perMealCost = 0;

        public double totalBazarCost()
        {
            double totalBazarCost = 0;
            foreach (var bazar in bazarCostEntryList)
            {
                totalBazarCost += bazar.amount;
            }
            return totalBazarCost;
        }

        
        public List<MemberInformation> getAllMemberInformation()
        {
            memberInformationList = new List<MemberInformation>();
            foreach (var aMember in memberEntryList)
            {
                memberInformationList.Add(getMemberInformation(aMember.memberId));
            }
            foreach (var aMemberInfo in memberInformationList)
            {
                perMealCost = (totalBazarCost()/totalNoOfMeals);
                aMemberInfo.individualMealCost = perMealCost*aMemberInfo.noOfMeals;
                if (aMemberInfo.individualMealCost < aMemberInfo.balance)
                {
                    aMemberInfo.amountToBeGiven = aMemberInfo.balance - aMemberInfo.individualMealCost;
                }
                else
                {
                    aMemberInfo.amountToBePaid = aMemberInfo.individualMealCost - aMemberInfo.balance;
                }
            }
            return memberInformationList;
        }

        private MemberInformation getMemberInformation(int memberId)
        {
            MemberInformation memberInfo = new MemberInformation();
            foreach (MemberEntry aMember in memberEntryList)
            {
                if (aMember.memberId == memberId)
                {
                    memberInfo.memberId = aMember.memberId;
                    memberInfo.borderName = aMember.name;
                    memberInfo.roomNo = aMember.roomNo;
                }  
            }

            int countTotalMeal = 0;
            foreach (var aMeal in mealEntryList)
            {
                if (aMeal.memberId == memberId)
                {
                    countTotalMeal += aMeal.noOfMeals;
                }
            }
            totalNoOfMeals += countTotalMeal;
            memberInfo.noOfMeals = countTotalMeal;
            int countTotalBalance = 0;
            foreach (var balanceEntry in balanceEntryList)
            {
                if (balanceEntry.memberId == memberId)
                {
                    countTotalBalance += balanceEntry.balance;
                }
            }
            memberInfo.balance = countTotalBalance;

            return memberInfo;
        }
    }
}
