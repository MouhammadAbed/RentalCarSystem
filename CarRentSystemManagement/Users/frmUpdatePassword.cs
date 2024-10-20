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

namespace CarRentSystemManagement.Users
{
    public partial class frmUpdatePassword : Form
    {
        public frmUpdatePassword()
        {
            InitializeComponent();
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text)|| (clsUtil.ComputedHash(txtCurrentPassword.Text)!= clsGlobalUser.CurrentUser.Password))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtCurrentPassword, "Wrong Password. Please insert current password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }
        private void txtconfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtconfirmPassword.Text)|| (txtconfirmPassword.Text!=txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtconfirmPassword, "Confirmation password doesn't match with new password");
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtconfirmPassword, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            clsGlobalUser.CurrentUser.Password=clsUtil.ComputedHash(txtNewPassword.Text);
            if (MessageBox.Show("Are you sure you want to change the current user password", "Confirm change", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsGlobalUser.CurrentUser.Save())
                {
                    MessageBox.Show("current user password change successfully.", "Password change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = clsGlobalUser.CurrentUser.userName;
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "this field is required");
            }
            else
            {
                e.Cancel=false;
                errorProvider1.SetError(txtUserName, "");
            }
            if(txtUserName.Text!=clsGlobalUser.CurrentUser.userName)
            {
                if (clsUser.isUserNameExist(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "User name already exist for another user");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, "");
                }
            }
        }
    }
}
