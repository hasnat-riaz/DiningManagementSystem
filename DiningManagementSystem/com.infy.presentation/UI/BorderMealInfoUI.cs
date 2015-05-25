using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class BorderMealInfoUI : Form
    {
        public BorderMealInfoUI()
        {
            InitializeComponent();

        }

        private void BorderMealInfoUI_Load(object sender, System.EventArgs e)
        {
            aMemberInformationBll = new MemberInformationBLL();
            showDataInDataGridView();
            totalBazarCostLabel.Text = aMemberInformationBll.totalBazarCost().ToString();
            totalNoOfMealsLabel.Text = aMemberInformationBll.totalNoOfMeals.ToString();
            perMealCostLabel.Text = aMemberInformationBll.perMealCost.ToString();
        }
        
        MemberInformationBLL aMemberInformationBll;
        
       private void showDataInDataGridView()
       {
           aMemberInformationBll = new MemberInformationBLL();
            memberInformationDataGridView.AutoGenerateColumns = false;
            List<MemberInformation> aList = aMemberInformationBll.getAllMemberInformation();
            memberInformationDataGridView.DataSource = aList;

            memberInformationDataGridView.Columns[1].DataPropertyName = "memberId";
            memberInformationDataGridView.Columns[2].DataPropertyName = "borderName";
            memberInformationDataGridView.Columns[3].DataPropertyName = "roomNo";
            memberInformationDataGridView.Columns[4].DataPropertyName = "noOfMeals";
            memberInformationDataGridView.Columns[5].DataPropertyName = "balance";

            memberInformationDataGridView.Columns[6].DataPropertyName = "individualMealCost";
            memberInformationDataGridView.Columns[7].DataPropertyName = "amountToBeGiven";
            memberInformationDataGridView.Columns[8].DataPropertyName = "amountToBePaid";

            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in memberInformationDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here
        }

        private void filteredDataInDataGridView(int memberId)
        {
            aMemberInformationBll = new MemberInformationBLL();
            List<MemberInformation> aList = aMemberInformationBll.getAllMemberInformation();
            List<MemberInformation> newList = new List<MemberInformation>();
            foreach (var memberInformation in aList)
            {
                if (memberInformation.memberId == memberId)
                {
                    newList.Add(memberInformation);
                }
            }
            memberInformationDataGridView.AutoGenerateColumns = false;
            memberInformationDataGridView.DataSource = newList;
            memberInformationDataGridView.Columns[1].DataPropertyName = "memberId";
            memberInformationDataGridView.Columns[2].DataPropertyName = "borderName";
            memberInformationDataGridView.Columns[3].DataPropertyName = "roomNo";
            memberInformationDataGridView.Columns[4].DataPropertyName = "noOfMeals";
            memberInformationDataGridView.Columns[5].DataPropertyName = "balance";

            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in memberInformationDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here

        }

        private void BorderMealInfoUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (MessageBox.Show(@"Are you sure you want to exit?",
                                        @"Exit?",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Today.ToLongDateString();
        }


        private void searchMemeberIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchMemeberIdTextBox.Text != "")
            {
                filteredDataInDataGridView(Convert.ToInt32(searchMemeberIdTextBox.Text));
            }
            else
            {
                showDataInDataGridView();
            }

        }
    }
}

