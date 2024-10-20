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

namespace CarRentSystemManagement.Users.Controls
{
    public partial class ctrUserCard : UserControl
    {
        clsUser _user;
        int _UserID;
        public ctrUserCard()
        {
            InitializeComponent();
        }
        private void _ResetDefaultSettings()
        {
            lblUserId.Text = "[????]";
            lblFirstName.Text= "[????]";
            lblSecondName.Text= "[????]";
            lblLastName.Text= "[????]";
            lblPersonId.Text= "[????]";
            lblPhoneNumber.Text= "[????]";
        }
        private void _FillUserInfo()
        {
            lblUserId.Text = _user.UserID.ToString();
            lblFirstName.Text= _user.FirstName;
            lblSecondName.Text= _user.SecondName;
            lblLastName.Text= _user.LastName;
            lblPersonId.Text = _user.PersonID.ToString();
            lblPhoneNumber.Text = _user.Phone;

        }
        public void LoadUserbyUserID(int UserID)
        {
            _user = clsUser.FindUser(UserID);
            if(_user != null )
            {
                _FillUserInfo();
            }
            else
            {
                _ResetDefaultSettings();
            }
        }
        public void LoadUserByPersonID(int PersonID)
        {
            _user = clsUser.FindUserByPersonID(PersonID);
            if (_user != null)
            {
                _FillUserInfo();
            }
            else
            {
                _ResetDefaultSettings();
            }
        }
    }
}
