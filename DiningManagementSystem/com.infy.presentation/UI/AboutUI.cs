using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class AboutUI : Form
    {
        public AboutUI()
        {
            InitializeComponent();
        }
        private void AboutUI_FormClosing(object sender, FormClosingEventArgs e)
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

        private void mealEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MealEntryUI main=new MealEntryUI();
            main.ShowDialog();
        }

        private void memberMealCodeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberCodeEntryUI main=new MemberCodeEntryUI();
            main.ShowDialog();
        }

        private void balanceEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BalanceEntryUI main=new BalanceEntryUI();
            main.ShowDialog();

        }

        private void borderMealInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorderMealInfoUI main=new BorderMealInfoUI();
            main.ShowDialog();
        }

        private void bazarCostInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BazarCostEntryUI main=new BazarCostEntryUI();
            main.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
