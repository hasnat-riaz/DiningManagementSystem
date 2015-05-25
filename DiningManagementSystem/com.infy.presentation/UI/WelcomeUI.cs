using System;
using System.Windows.Forms;

namespace DiningManagementSystem.com.infy.presentation.UI
{
    public partial class WelcomeUI : Form
    {
        public WelcomeUI()
        {
            InitializeComponent();
        }

        private void balanceEntryToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            BalanceEntryUI main = new BalanceEntryUI();
            main.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            AboutUI main = new AboutUI();
            main.Show();
        }

        private void mealEntryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MealEntryUI main = new MealEntryUI();
            main.Show();
        }

        private void borderMealInfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            BorderMealInfoUI main = new BorderMealInfoUI();
            main.Show();
        }

        private void bazarCostInfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            BazarCostEntryUI main = new BazarCostEntryUI();
            main.Show();
        }

        private void memberMealCodeEntryToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MemberCodeEntryUI main = new MemberCodeEntryUI();
            main.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Today.ToLongDateString();
        }

        private void WelcomeUI_FormClosing(object sender, FormClosingEventArgs e)
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
                    Application.Exit();
                    break;

            }
        }

        

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginUI main = new LoginUI();
            main.Show();
        }

        private void editPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLoginUI main = new EditLoginUI();
            main.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showInGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PicturalRepresentationUI main=new PicturalRepresentationUI();
            main.Show();
        }
    }
}
