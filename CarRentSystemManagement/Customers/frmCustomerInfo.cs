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
    public partial class frmCustomerInfo : Form
    {
        int _CustomerID;
        public frmCustomerInfo(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
        }

        private void frmCustomerInfo_Load(object sender, EventArgs e)
        {
            ctrClientCard1.LoadCustomerInfo(_CustomerID);
        }
    }
}
