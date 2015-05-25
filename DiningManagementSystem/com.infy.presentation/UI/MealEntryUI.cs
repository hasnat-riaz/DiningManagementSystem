using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class MealEntryUI : Form
    {
        //code starts
        public static string myId;

        public string emp
        {
            get { return myId; }
            set { myId = value; }

        }
        //code ends
        public MealEntryUI()
        {
            InitializeComponent();
            //This code is for the delete and edit options in datagridview
            //code starts from here

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            mealEntryInfoDataGridView.Columns.Add(Deletelink);
            //code end
        }

        MealEntryBLL aMealEntryBll = new MealEntryBLL();
        private List<MealEntry> aMealEntryList;

        private void MealEntryUI_Load(object sender, System.EventArgs e)
        {
            loadDataInComboBox();
            showDataInDataGridView();
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                MealEntry aMealEntry = new MealEntry(Convert.ToInt32(memberIdComboBox.Text), Convert.ToInt32(noOfMealsComboBox.Text), dateTimePicker1.Value);
                string msg = aMealEntryBll.save(aMealEntry);
                MessageBox.Show(msg, @"Message");
                showDataInDataGridView();
                clearTextBoxes();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void clearTextBoxes()
        {
            memberIdComboBox.SelectedValue = -1;
            noOfMealsComboBox.SelectedValue = -1;
        }

        private void loadDataInComboBox()
        {
            List<MemberEntry> allMembers = new List<MemberEntry>();
            allMembers = new MemberCodeEntryBLL().getMemberCodeInfo();
            memberIdComboBox.DataSource = allMembers;
            memberIdComboBox.ValueMember = "memberId";
            memberIdComboBox.DisplayMember = "memberId";
            memberIdComboBox.Text = @"select member Id";
        }

        private void showDataInDataGridView()
        {

            aMealEntryList = aMealEntryBll.getAllMealEntryInfo();
            mealEntryInfoDataGridView.AutoGenerateColumns = false;
            mealEntryInfoDataGridView.DataSource = aMealEntryList;
            mealEntryInfoDataGridView.Columns[1].DataPropertyName = "memberId";
            mealEntryInfoDataGridView.Columns[2].DataPropertyName = "noOfMeals";
            mealEntryInfoDataGridView.Columns[3].DataPropertyName = "mealEntryDate";

            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in mealEntryInfoDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here
        }

        private void mealEntryInfoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                myId = Convert.ToString(mealEntryInfoDataGridView.Rows[e.RowIndex].Cells["memberId"].Value);
                DialogResult result1 = MessageBox.Show(@"Are you sure you want to delete??", @"Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string msg = aMealEntryBll.deleteAll(myId);
                    MessageBox.Show(msg);
                }

                showDataInDataGridView();
                mealEntryInfoDataGridView.Refresh();
            }
        }

        private void MealEntryUI_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Today.ToLongDateString();
        }
      }

}

