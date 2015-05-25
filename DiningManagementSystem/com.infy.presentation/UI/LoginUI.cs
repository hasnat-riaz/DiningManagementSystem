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
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();


            //This code is for watermask textbox
            userNameTextBox.ForeColor = Color.Black;
            userNameTextBox.Text = @"Please Enter Name";
            this.userNameTextBox.Leave += new System.EventHandler(this.userNameTextBox_Leave);
            this.userNameTextBox.Enter += new System.EventHandler(this.userNameTextBox_Enter);

           

            passwordTextBox.Text = "";
            // The password character is an asterisk.
            passwordTextBox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            passwordTextBox.MaxLength = 14;
        }
        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                userNameTextBox.Text = @"Please Enter Name";
                userNameTextBox.ForeColor = Color.Black;
            }
        }

        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == @"Please Enter Name")
            {
                userNameTextBox.Text = "";
                userNameTextBox.ForeColor = Color.Black;
            }
        }

        LoginBLL aLoginBll=new LoginBLL();
        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Login aLogin = new Login(userNameTextBox.Text, passwordTextBox.Text);
                string msg = aLoginBll.login(aLogin);
                if (msg.Equals("Yes"))
                {
                    this.Hide();
                    WelcomeUI aWindow = new WelcomeUI();
                    aWindow.Show();
                    aWindow.welcomeLabel.Text = aLogin.userName;
                    aWindow.enteredAsInfoLabel.Text = @"Manager";

                    
                }
                else
                {
                    MessageBox.Show(msg, @"Message");
                    clearTextBoxes();
                }
                
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
        }

        private void LoginUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        } 
    }
}

