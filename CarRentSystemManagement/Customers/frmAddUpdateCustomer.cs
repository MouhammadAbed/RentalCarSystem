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

namespace CarRentSystemManagement.Customers
{
    public partial class frmAddUpdateCustomer : Form
    {
        enum enMode { enUpdate = 1, enAdd = 2 }
        enMode _Mode = enMode.enUpdate;
        int _CustomerID = 0;
        clsCustomer _Customer;
        public frmAddUpdateCustomer(int customerID =0)
        {
            InitializeComponent();
            _CustomerID= customerID;
            if(_CustomerID == 0)
            {
                _Mode = enMode.enAdd;
            }
            else
            {
                _Mode = enMode.enUpdate;
            }
            _LoadCustomerInfo();
        }

        private void _CollectCustomerData()
        {
            _Customer.FirstName = txtFirstName.Text;
            _Customer.LastName = txtLastName.Text;
            _Customer.SecondName = txtSecondName.Text;
            _Customer.DriverLicenseID= txtDriverLicenseID.Text;
            _Customer.Phone = txtPhone.Text;
        }
        private void _LoadCustomerInfo()
        {
            if (_Mode == enMode.enAdd)
            {
                lblTitle.Text = "Add New Customer";
                _Customer = new clsCustomer();
                return;
            }
            lblTitle.Text = "Update Customer Info";
            _Customer = clsCustomer.FindCustomer(_CustomerID);
            if(_Customer!=null)
            {
                lblCustomerID.Text = _Customer.CustomerID.ToString();
                txtFirstName.Text = _Customer.FirstName;
                txtSecondName.Text=_Customer.SecondName;
                txtLastName.Text = _Customer.LastName;
                txtDriverLicenseID.Text = _Customer.DriverLicenseID;
                txtPhone.Text = _Customer.Phone;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtFirstNameValidating(object sender, CancelEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if(string.IsNullOrEmpty(t.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(t, "This Field requird.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(t, null);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save customer info","Save Customer",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                _CollectCustomerData();
                if (_Customer.Save())
                {
                    MessageBox.Show("Customer save successfully.", "Customer save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.enUpdate;
                    lblCustomerID.Text = "Update Customer Info";
                    lblCustomerID.Text = _Customer.CustomerID.ToString();
                }
            }
        }
    }
}
