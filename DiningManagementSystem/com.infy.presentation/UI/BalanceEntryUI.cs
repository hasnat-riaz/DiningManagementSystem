using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class BalanceEntryUI : Form
    {
        //code starts
        public static string myId;

        public string emp
        {
            get { return myId; }
            set { myId = value; }

        }
        //code ends
        public BalanceEntryUI()
        {
            InitializeComponent();
            loadDataInComboBox();

            balanceTextBox.ForeColor = Color.LightGray;
            balanceTextBox.Text = @"Please Enter Balance";
            this.balanceTextBox.Leave += new System.EventHandler(this.balanceTextBox_Leave);
            this.balanceTextBox.Enter += new System.EventHandler(this.balanceTextBox_Enter);


            //This code is for the delete and edit options in datagridview
            //code starts from here


            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            balanceEntryDataGridView.Columns.Add(Deletelink);
            //code end
        }

        private void BalanceEntryUI_Load(object sender, EventArgs e)
        {
            showDataInDataGridView();
            loadDataInComboBox();
        }

        private void balanceTextBox_Leave(object sender, EventArgs e)
        {
            if (balanceTextBox.Text == "")
            {
                balanceTextBox.Text = @"Please Enter Balance";
                balanceTextBox.ForeColor = Color.Gray;
            }
        }

        private void balanceTextBox_Enter(object sender, EventArgs e)
        {
            if (balanceTextBox.Text == @"Please Enter Balance")
            {
                balanceTextBox.Text = "";
                balanceTextBox.ForeColor = Color.Black;
            }
        }

        BalanceEntryBLL aBalanceEntryBll = new BalanceEntryBLL();
        private List<BalanceEntry> aBalanceEntryList;

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(balanceTextBox.Text, "^[0-9]"))
                {
                    throw new Exception("Digit Only!");
                }
                BalanceEntry aBalanceEntry = new BalanceEntry(Convert.ToInt32(memberIdComboBox.Text), Convert.ToInt32(balanceTextBox.Text), dateTimePicker1.Value);
                string msg = aBalanceEntryBll.save(aBalanceEntry);
                MessageBox.Show(msg);
                showDataInDataGridView();
                clearTextBoxes();
            }
            catch (FormatException exception)
            {
                MessageBox.Show(@"Please enter balance in correct format.",exception.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void clearTextBoxes()
        {
            memberIdComboBox.SelectedValue = -1;
            balanceTextBox.Text = string.Empty;

        }
        private void showDataInDataGridView()
        {
            aBalanceEntryList = aBalanceEntryBll.getAllBalanceEntryInfo();
            balanceEntryDataGridView.AutoGenerateColumns = false;
            balanceEntryDataGridView.DataSource = aBalanceEntryList;

            balanceEntryDataGridView.Columns[1].DataPropertyName = "memberId";
            balanceEntryDataGridView.Columns[2].DataPropertyName = "balance";
            balanceEntryDataGridView.Columns[3].DataPropertyName = "balanceEntryDate";


            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in balanceEntryDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here
        }

        private void loadDataInComboBox()
        {
            List<MemberEntry> allMembers = new List<MemberEntry>();
            allMembers = new MemberCodeEntryBLL().getMemberCodeInfo();
            memberIdComboBox.DataSource = allMembers;
            memberIdComboBox.DisplayMember = "memberId";
            memberIdComboBox.ValueMember = "memberId";
            memberIdComboBox.Text = (@"Select your member Id");
        }

        private void BalanceEntryUI_FormClosing(object sender, FormClosingEventArgs e)
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

        private void balanceEntryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                myId = Convert.ToString(balanceEntryDataGridView.Rows[e.RowIndex].Cells["memberId"].Value);
                DialogResult result1 = MessageBox.Show(@"Are you sure you want to delete??", @"Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string msg = aBalanceEntryBll.deleteAll(myId);
                    MessageBox.Show(msg);
                }

                showDataInDataGridView();
                balanceEntryDataGridView.Refresh();
            }
        }
    }
}
