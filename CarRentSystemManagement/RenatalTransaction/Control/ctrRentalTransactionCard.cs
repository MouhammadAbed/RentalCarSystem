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
    public partial class ctrRentalTransactionCard : UserControl
    {
        clsRentalTransaction _Transaction;
        int _TransactionId;
        public int TransactionID
        {
            get { return _TransactionId; }
        }
        public clsRentalTransaction RentalTransaction
        {
            get { return _Transaction; }
        }

        public ctrRentalTransactionCard()
        {
            InitializeComponent();
        }

        private void _ResetDefaultSettings()
        {
            lblTransactionId.Text = "[????]";
            lblBookingId.Text= "[????]";
            lblPaidDetails.Text= "[????]";
            lblTransactionDate.Text = "[dd/mm/yyyy]";
            lblActualDueAmount.Text = "[$$$$]";
            lblInitialDueAmount.Text = "[$$$$]";
            lblTotalRemaining.Text = "[$$$$]";
        }
        private void FindNow()
        {
            _Transaction = clsRentalTransaction.FindTransaction(_TransactionId);
            if(_Transaction == null )
            {
                _TransactionId = -1;
                _ResetDefaultSettings();
                return;
            }
            lblTransactionId.Text = _Transaction.TransactionID.ToString();
            lblActualDueAmount.Text=_Transaction.ActualDueAmount.ToString() + " $"; ;
            lblBookingId.Text = _Transaction.bookingID.ToString();
            lblPaidDetails.Text = _Transaction.PaymentDetails.ToString();
            lblTotalRemaining.Text = _Transaction.ActualTotalRemaining.ToString() + " $"; ;
            lblTransactionDate.Text=_Transaction.TransactionDate.ToShortDateString();
            lblInitialDueAmount.Text = _Transaction.initialTotalDueAmount.ToString() + " $";
        }
        public void LoadRentalTransaction(int TransactionID)
        {
            _TransactionId= TransactionID;          
            FindNow();
        }
    }
}
