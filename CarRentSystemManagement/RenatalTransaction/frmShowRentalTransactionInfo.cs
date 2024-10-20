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

namespace CarRentSystemManagement.RenatalTransaction
{
    public partial class frmShowRentalTransactionInfo : Form
    {
        int _TransactionId;
        public frmShowRentalTransactionInfo(int transactionId)
        {
            InitializeComponent();
            _TransactionId = transactionId;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmShowRentalTransactionInfo_Load(object sender, EventArgs e)
        {
            ctrRentalTransactionCard1.LoadRentalTransaction(_TransactionId);
        }
        private void frmShowRentalTransactionInfo_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void frmShowRentalTransactionInfo_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
