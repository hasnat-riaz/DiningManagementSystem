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
    public partial class EditLoginUI : Form
    {
        public EditLoginUI()
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
                Login aLogin = new Login(userNameTextBox.Text, passwordTextBox.Text);
                string msg=new LoginBLL().updatePassword(aLogin, newPasswordTextBox.Text, confirmPasswordTextBox.Text);
                MessageBox.Show(msg);
                clearTextBoxes();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
          
        }

        private void clearTextBoxes()
        {
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
            newPasswordTextBox.Text = "";
            confirmPasswordTextBox.Text = "";
        }
    }
}
