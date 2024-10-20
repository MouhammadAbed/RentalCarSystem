using CarRentalBusinessLayer;
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
    public partial class frmAddUpdateUser : Form
    {
        int _userID;
        clsUser _user;
        enum enMode { enUpdate = 1, enAdd = 2 }
        enMode _Mode = enMode.enUpdate;
        public frmAddUpdateUser(int UserID = 0)
        {
            InitializeComponent();
            if (UserID == 0)
            {
                _Mode = enMode.enAdd;
            }
            else
            {
                _userID = UserID;
                _Mode = enMode.enUpdate;
            }
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAdd)
            {
                lblTitle.Text = "Add New User";
                _user = new clsUser();
                return;
            }
            _user = clsUser.FindUser(_userID);
            if (_user != null)
            {
                lblTitle.Text = "Update User Info";
                lblUserId.Text = _userID.ToString();
                txtUserName.Text = _user.userName;
                lblPersonId.Text = _user.PersonID.ToString();
                txtFirstName.Text = _user.FirstName;
                txtSecondName.Text = _user.SecondName;
                txtLastName.Text = _user.LastName;
                txtPassword.Text = _user.Password;
                txtPhoneNumber.Text = _user.Phone;
            }
        }
        private void _FillUserInfo()
        {
            _user.userName= txtUserName.Text;
            _user.FirstName = txtFirstName.Text;
            _user.SecondName = txtSecondName.Text;
            _user.LastName = txtLastName.Text;
            _user.Password = txtPassword.Text;
            _user.Phone = txtPhoneNumber.Text;
        }        
        private void textboxValidating(object sender, CancelEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (string.IsNullOrEmpty(t.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(t, "This field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to save user info", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _FillUserInfo();
                if (_user.Save())
                {
                    MessageBox.Show("User info save successfully.", "Save User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.enUpdate;
                    lblTitle.Text = "Update User Info";
                    lblUserId.Text = _user.UserID.ToString();
                    lblPersonId.Text=_user.PersonID.ToString(); 
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text != _user.userName)
            {
                if (clsUser.isUserNameExist(txtUserName.Text) || string.IsNullOrEmpty(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "You can't insert duplicate user name. Please choose another user name");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, null);
                }
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
