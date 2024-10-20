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

namespace CarRentSystemManagement.Clients
{
    public partial class ctrCustomerCard : UserControl
    {
       
        int _CustomerID=-1;
        string _DriverLicenseID = string.Empty;
        clsCustomer _Customer;
        public int CustomerID
        {
            get { return _CustomerID; }
        }
        public ctrCustomerCard()
        {
            InitializeComponent();
        }
        private void _RestDefaultSettings()
        {
            lblCustomerID.Text = "[????]";
            lblFirstName.Text= "[????]";
            lblSecondName.Text= "[????]";
            lblLastName.Text= "[????]";
            lblDriverLIcenseID.Text = "[????]";
            lblPhoneNumber.Text = "[????]";
            _CustomerID=-1;
        }
        private void FindNow()
        {
            if (_CustomerID != -1)
            {
                _Customer = clsCustomer.FindCustomer(_CustomerID);                
            }
            else
            {
                _Customer = clsCustomer.FindCustomer(_DriverLicenseID);
            }
            if (_Customer!=null)
            {
                _CustomerID=_Customer.CustomerID;
                lblCustomerID.Text = _Customer.CustomerID.ToString();
                lblFirstName.Text = _Customer.FirstName;
                lblSecondName.Text = _Customer.SecondName;
                lblLastName.Text = _Customer.LastName;
                lblDriverLIcenseID.Text = _Customer.DriverLicenseID;
                lblPhoneNumber.Text = _Customer.Phone;
            }
            else
            {
                _RestDefaultSettings();
                return;
            }          
        }
        public void LoadCustomerInfo(int CustomerID)
        {
            _CustomerID = CustomerID;
            _DriverLicenseID = string.Empty;
            FindNow();
        }
        public void LoadCustomerInfo(string DriverLicense)
        {
            _CustomerID = -1;
            _DriverLicenseID = DriverLicense;
            FindNow();
        }
    }
}
