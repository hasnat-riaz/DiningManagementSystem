using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class MemberCodeEntryUI : Form
    {
        //code starts
        public static string myId;

        public string emp
        {
            get { return myId; }
            set { myId = value; }

        }
        //code ends


        public MemberCodeEntryUI()
        {
            InitializeComponent();
            
            //This code is for watermask textbox
            memberNameTextBox.ForeColor = Color.LightGray;
            memberNameTextBox.Text = @"Please Enter Name";
            this.memberNameTextBox.Leave += new System.EventHandler(this.memberNameTextBox_Leave);
            this.memberNameTextBox.Enter += new System.EventHandler(this.memberNameTextBox_Enter);

            roomNoTextBox.ForeColor = Color.LightGray;
            roomNoTextBox.Text = @"Please Enter Room Number";
            this.roomNoTextBox.Leave += new System.EventHandler(this.roomNoTextBox_Leave);
            this.roomNoTextBox.Enter += new System.EventHandler(this.roomNoTextBox_Enter);

            addressTextBox.ForeColor = Color.LightGray;
            addressTextBox.Text = @"Please Enter Address";
            this.addressTextBox.Leave += new System.EventHandler(this.addressTextBox_Leave);
            this.addressTextBox.Enter += new System.EventHandler(this.addressTextBox_Enter);
            //code ends here

            //This code is for the delete and edit options in datagridview
            //code starts from here
            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "Edit";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            memberCodeDataGridView.Columns.Add(Editlink);

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            memberCodeDataGridView.Columns.Add(Deletelink);
            //code end
        }


        public void MemberCodeEntryUI_Load(object sender, EventArgs e)
        {
            showDataInDataGridView();
            memberIdTextBox.Text = generateId().ToString();
            memberIdTextBox.Enabled = false;
        }

        private void memberNameTextBox_Leave(object sender, EventArgs e)
        {
            if (memberNameTextBox.Text == "")
            {
                memberNameTextBox.Text = @"Please Enter Name";
                memberNameTextBox.ForeColor = Color.Gray;
            }
        }

        private void memberNameTextBox_Enter(object sender, EventArgs e)
        {
            if (memberNameTextBox.Text == @"Please Enter Name")
            {
                memberNameTextBox.Text = "";
                memberNameTextBox.ForeColor = Color.Black;
            }
        }


        private void roomNoTextBox_Leave(object sender, EventArgs e)
        {
            if (roomNoTextBox.Text == "")
            {
                roomNoTextBox.Text = @"Please Enter Room Number";
                roomNoTextBox.ForeColor = Color.Gray;
            }
        }

        private void roomNoTextBox_Enter(object sender, EventArgs e)
        {
            if (roomNoTextBox.Text == @"Please Enter Room Number")
            {
                roomNoTextBox.Text = "";
                roomNoTextBox.ForeColor = Color.Black;
            }
        }


        private void addressTextBox_Leave(object sender, EventArgs e)
        {
            if (addressTextBox.Text == "")
            {
                addressTextBox.Text = @"Please Enter Address";
                addressTextBox.ForeColor = Color.Gray;
            }
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            if (addressTextBox.Text == @"Please Enter Address")
            {
                addressTextBox.Text = "";
                addressTextBox.ForeColor = Color.Black;
            }
        }

        MemberCodeEntryBLL aMemberCodeEntryBll=new MemberCodeEntryBLL();
        private List<MemberEntry> aMemberCodeEntryList;

       

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                MemberEntry aMemberEntry = new MemberEntry(memberNameTextBox.Text, roomNoTextBox.Text, addressTextBox.Text, dateTimePicker1.Value);
                string msg = aMemberCodeEntryBll.save(aMemberEntry);
                showDataInDataGridView();
                MessageBox.Show(msg, @"Message");
                clearTextBoxes();
                MemberCodeEntryUI_Load(0, null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void showDataInDataGridView()
        {
            aMemberCodeEntryList = aMemberCodeEntryBll.getMemberCodeInfo();
            memberCodeDataGridView.AutoGenerateColumns = false;
            memberCodeDataGridView.DataSource = aMemberCodeEntryList;

            memberCodeDataGridView.Columns[1].DataPropertyName = "memberId";
            memberCodeDataGridView.Columns[2].DataPropertyName = "name";
            memberCodeDataGridView.Columns[3].DataPropertyName = "roomNo";
            memberCodeDataGridView.Columns[4].DataPropertyName = "address";
            memberCodeDataGridView.Columns[5].DataPropertyName = "dateOfEntry";

            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in memberCodeDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here
            
        }

        private void clearTextBoxes()
        {
            memberIdTextBox.Text = string.Empty;
            memberNameTextBox.Text = string.Empty;
            roomNoTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
        }

        private int generateId()
        {
            List<MemberEntry> getAllIds = aMemberCodeEntryList;
            int generatedMemberId = 0;
            foreach (var aMemberId in getAllIds)
            {
                generatedMemberId = aMemberId.memberId;
                generatedMemberId++;
            }
            return generatedMemberId;
        }

        private void memberCodeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                this.Hide();
                MemberEntry aEditMemberEntry = aMemberCodeEntryList[e.RowIndex];
                EditMemberCodeEntryUI main = new EditMemberCodeEntryUI(aEditMemberEntry);
                main.ShowDialog();
            }

            if (e.ColumnIndex ==7 )
            {
                myId = Convert.ToString(memberCodeDataGridView.Rows[e.RowIndex].Cells["memberId"].Value);
                DialogResult result1 = MessageBox.Show(@"Are you sure you want to delete??", @"Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string msg = aMemberCodeEntryBll.deleteAll(myId);
                    MessageBox.Show(msg);
                }
                
                showDataInDataGridView();
                memberCodeDataGridView.Refresh();
            } 
        }

        private void MemberCodeEntryUI_FormClosing(object sender, FormClosingEventArgs e)
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
