using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class EditMemberCodeEntryUI : Form
    {
        public EditMemberCodeEntryUI(MemberEntry aEditMemberEntry):this()
        {
            this.memberIdTextBox.Text = aEditMemberEntry.memberId.ToString();
            memberIdTextBox.Enabled = false;
            this.memberNameTextBox.Text = aEditMemberEntry.name;
            this.roomNoTextBox.Text = aEditMemberEntry.roomNo;
            this.addressTextBox.Text = aEditMemberEntry.address;
            dateTimePicker1.Value = aEditMemberEntry.dateOfEntry;
        }

        public EditMemberCodeEntryUI()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Today.ToLongDateString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                MemberCodeEntryBLL aMemberCodeEntryBll = new MemberCodeEntryBLL();
                MemberEntry aMemberEntry = new MemberEntry(Convert.ToInt32(memberIdTextBox.Text), memberNameTextBox.Text,
                    roomNoTextBox.Text, addressTextBox.Text, dateTimePicker1.Value);
                string msg = aMemberCodeEntryBll.update(aMemberEntry);
                MessageBox.Show(msg, @"Message");
                Hide();
                new MemberCodeEntryUI().Show();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message,@"Message");
            }
        }
    }
}
