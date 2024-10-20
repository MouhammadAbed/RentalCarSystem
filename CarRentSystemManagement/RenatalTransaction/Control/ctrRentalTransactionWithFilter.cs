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

namespace CarRentSystemManagement.RenatalTransaction.Control
{
    public partial class ctrRentalTransactionWithFilter : UserControl
    {
        public event Action<int> TransactionFound;
        protected virtual void onTransactionFound(int TransactionId)
        {
            Action<int> handler = TransactionFound;
            if (handler != null)
            {
                handler(TransactionId);
            }
        }
        bool _FileterEnable = false;
        int _TransactionID=-1;
        public clsRentalTransaction RentalTransaction
        {
            get { return ctrRentalTransactionCard1.RentalTransaction; }
        }
        public int TransactionID
        {
            get { return _TransactionID; } 
            set { _TransactionID = value; }
        }
        public bool EnableFilter
        {
            set 
            {
                _FileterEnable = value;
               gbFilter.Enabled= _FileterEnable;
            }
        }
        public ctrRentalTransactionWithFilter()
        {
            InitializeComponent();
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtValue.Text))
            { 
                e.Cancel = true;
                errorProvider1.SetError(txtValue, "This filed is required. Please insert a transaction id.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtValue, null);
            }
        }      
        private void FindNow()
        {
            _TransactionID = Convert.ToInt32(txtValue.Text);
            ctrRentalTransactionCard1.LoadRentalTransaction(_TransactionID);
            if(!_FileterEnable)
            {
                onTransactionFound(ctrRentalTransactionCard1.TransactionID);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();   
        }
        private void ctrRentalTransactionWithFilter_Load(object sender, EventArgs e)
        {
            cmbFindBy.SelectedIndex=0;
            SetFocus();
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void SetFocus()
        {
            txtValue.Focus();
        }
        public void LoadTransactionInfo(int TransactionId)
        {
            txtValue.Text= TransactionId.ToString();
            FindNow();
        }

    }
}
