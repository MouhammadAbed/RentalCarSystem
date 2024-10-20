using CarRentalBusinessLayer;
using CarRentSystemManagement.ReturnVehicle;
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
    public partial class RentalTransactionList : Form
    {
        public RentalTransactionList()
        {
            InitializeComponent();
        }
        private void RentalTransactionList_Load(object sender, EventArgs e)
        {
            dgvTransactionList.DataSource = clsRentalTransaction.GetRentalTransactionList();
            if(dgvTransactionList.Rows.Count> 0 )
            {
                dgvTransactionList.Columns[0].HeaderText = "Transaction Id";
                dgvTransactionList.Columns[0].Width = 100;

                dgvTransactionList.Columns[1].HeaderText = "Initial Due Amount";
                dgvTransactionList.Columns[1].Width = 130;

                dgvTransactionList.Columns[2].HeaderText = "Payement Details";
                dgvTransactionList.Columns[2].Width = 100;

                dgvTransactionList.Columns[3].HeaderText = "Actual Due Amount";
                dgvTransactionList.Columns[3].Width = 150;

                dgvTransactionList.Columns[4].HeaderText = "Total Remaining";
                dgvTransactionList.Columns[4].Width = 100;

                dgvTransactionList.Columns[5].HeaderText = "Transaction Date";
                dgvTransactionList.Columns[5].Width = 200;

                dgvTransactionList.Columns[6].HeaderText = "Booking Id";
                dgvTransactionList.Columns[6].Width = 95;
            }
            lblRecord.Text=dgvTransactionList.Rows.Count.ToString();

        }
        private void showTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowRentalTransactionInfo frm = new frmShowRentalTransactionInfo((int)dgvTransactionList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();   
        }
        private void returnVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsRentalTransaction.isVehicleReturned((int)dgvTransactionList.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Vehicle already returned.","Vehicle Returned",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            frmWhenVehicleReturn frm = new frmWhenVehicleReturn((int)dgvTransactionList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
