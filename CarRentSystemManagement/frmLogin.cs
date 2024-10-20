using CarRentalBusinessLayer;
using CarRentSystemManagement.Global_Class;
using CarRentSystemManagement.GlobalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btrnLogin_Click(object sender, EventArgs e)

        {
            if (clsUser.isUserExistByUserNameAndPassword(txtUserName.Text, clsUtil.ComputedHash(txtPassword.Text))) 
            {
                clsGlobalUser.CurrentUser = clsUser.FindUser(txtUserName.Text);
                if (chRememberMe.Checked)
                {
                    clsGlobalUser.RememberUserNameAndPasswrod(txtUserName.Text,txtPassword.Text);
                }
                else
                {
                    clsGlobalUser.RememberUserNameAndPasswrod("", "");
                }
                this.Hide();
                frmDashboardScreen frm = new frmDashboardScreen(this);
                frm.ShowDialog();   
            }
            else
            {
                clsGlobalUser.RememberUserNameAndPasswrod("", "");
                MessageBox.Show("user name/Password is invalid. Please insert the right user name/Password", "Wrong UserName/Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsEventLogEntry.SaveEventToEventLogEntry( "user name/Password is invalid. Please insert the right user name/Password", clsEventLogEntry.enEventLogEntry.enWarnning);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";
            if(clsGlobalUser.GetSortedCredentialFromWindowRegistry(ref UserName,ref Password))
            {
                txtUserName.Text= UserName;
                txtPassword.Text= Password;
                chRememberMe.Checked= true; 
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();                
        }
        private void frmLogin_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void frmLogin_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
