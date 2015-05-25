using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DiningManagementSystem.com.infy.manager.BLL;
using DiningManagementSystem.com.infy.persistence.DAO;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class BazarCostEntryUI : Form
    {
        //code starts
        public static string myId;

        public string emp
        {
            get { return myId; }
            set { myId = value; }

        }
        //code ends
        public BazarCostEntryUI()
        {
            InitializeComponent();

            amountTextBox.ForeColor = Color.LightGray;
            amountTextBox.Text = @"Please Enter Amount";
            this.amountTextBox.Leave += new System.EventHandler(this.amountTextBox_Leave);
            this.amountTextBox.Enter += new System.EventHandler(this.amountTextBox_Enter);


            //This code is for the delete and edit options in datagridview
            //code starts from here

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            bazarCostDataGridView.Columns.Add(Deletelink);
            //code end
        }


        private void amountTextBox_Leave(object sender, EventArgs e)
        {
            if (amountTextBox.Text == "")
            {
                amountTextBox.Text = @"Please Enter Amount";
                amountTextBox.ForeColor = Color.Gray;
            }
        }

        private void amountTextBox_Enter(object sender, EventArgs e)
        {
            if (amountTextBox.Text == @"Please Enter Amount")
            {
                amountTextBox.Text = "";
                amountTextBox.ForeColor = Color.Black;
            }
        }
        private void BazarCostEntryUI_Load(object sender, EventArgs e)
        {
            showDataInDataGrid();
        }


        BazarCostEntryBLL aBazarCostEntryBll = new BazarCostEntryBLL();
        private List<BazarCostEntry> aBazarCostEntryList;

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                BazarCostEntry aBazarCostEntry = new BazarCostEntry(Convert.ToInt32(amountTextBox.Text),
                    dateTimePicker1.Value);
                string msg = aBazarCostEntryBll.save(aBazarCostEntry);
                MessageBox.Show(msg, @"Message");
                showDataInDataGrid();
                clearTextBoxes();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(@"Enter amount in correct format.",ex.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void clearTextBoxes()
        {
            amountTextBox.Text = string.Empty;
        }

        private void showDataInDataGrid()
        {
            aBazarCostEntryList = aBazarCostEntryBll.getAllBazarCost();
            bazarCostDataGridView.AutoGenerateColumns = false;
            bazarCostDataGridView.DataSource = aBazarCostEntryList;
            bazarCostDataGridView.Columns[1].DataPropertyName = "id";
            bazarCostDataGridView.Columns[2].DataPropertyName = "amount";
            bazarCostDataGridView.Columns[3].DataPropertyName = "date";


            //Autogeneration of the id column starts here
            int i = 1;
            foreach (DataGridViewRow row in bazarCostDataGridView.Rows)
            {
                row.Cells["SNO"].Value = i;
                i++;
            }
            //autogeneration code ends here

        }
        private void BazarCostEntryUI_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bazarCostDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex ==4)
            {
                myId = Convert.ToString(bazarCostDataGridView.Rows[e.RowIndex].Cells["id"].Value);
                DialogResult result1 = MessageBox.Show(@"Are you sure you want to delete??", @"Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string msg = aBazarCostEntryBll.deleteAll(myId);
                    MessageBox.Show(msg);
                }

                showDataInDataGrid();
                bazarCostDataGridView.Refresh();
            }
        }
    }
}
