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
    public partial class frmFindCustomer : Form
    {
        int _CustomerID;
        public frmFindCustomer(int customerID)
        {
            InitializeComponent();
            _CustomerID = customerID;
            ctrClientCarWithFilter1.LoadCustomer(customerID);
            ctrClientCarWithFilter1.enableFilter = false;
        }
        public frmFindCustomer()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrClientCarWithFilter1_onCustomerSelected(int obj)
        {
            if(obj == -1)
            {
                MessageBox.Show("Customer doesn't exist. Please enter another Customer Id/ Driver Licesne Id. ","Customer not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
