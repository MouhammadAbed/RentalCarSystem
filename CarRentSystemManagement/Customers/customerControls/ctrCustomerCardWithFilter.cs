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
    public partial class ctrCustomerCardWithFilter : UserControl
    {
        public event Action<int> onCustomerSelected;
        protected virtual void CustomerSelected(int CustomerID)
        {
            Action<int> handler = onCustomerSelected;
            if(handler!=null)
            {
                handler(CustomerID);
            }
        }
        bool Filter = true;      
        bool EnableFilter = true;
        public bool enableFilter
        {
            set 
            {
                Filter = value;
                gbfilter.Enabled = value;
            }
        }
        public ctrCustomerCardWithFilter()
        {
            InitializeComponent();
        }
        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtValue.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtValue, "Please enter a value to search for.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtValue, "");
            }
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFilterBy.SelectedIndex==1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void FindNow()
        {
            switch (cmbFilterBy.Text)
            {
                case "Customer ID":
                    ctrClientCard1.LoadCustomerInfo(Convert.ToInt32(txtValue.Text));
                    break;
                case "Driver License ID":
                    ctrClientCard1.LoadCustomerInfo(txtValue.Text);
                    break;
                default:
                    return;
            }
            if (onCustomerSelected != null)
            {
                onCustomerSelected(ctrClientCard1.CustomerID);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FindNow();
        }
        private void ctrClientCarWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilterBy.Text = "Driver License ID";
        }      
        public void LoadCustomer(int CustomerID)
        {
            cmbFilterBy.Text = "Customer ID";
            txtValue.Text = CustomerID.ToString();
            FindNow();
        }
    }
}
