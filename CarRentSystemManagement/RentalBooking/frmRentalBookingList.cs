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

namespace CarRentSystemManagement.RentalBooking
{
    public partial class frmRentalBookingList : Form
    {
        DataTable _dtBookingList;
        private void _LoadBookingInfoToTable()
        {
            _dtBookingList=clsBooking.GetAllBookingVehicles();
            dgvRentalBookingList.DataSource = _dtBookingList;
            if(dgvRentalBookingList.Rows.Count > 0 )
            {
                dgvRentalBookingList.Columns[0].HeaderText = "Booking Id";
                dgvRentalBookingList.Columns[0].Width = 100;

                dgvRentalBookingList.Columns[1].HeaderText = "Full Name";
                dgvRentalBookingList.Columns[1].Width = 144;

                dgvRentalBookingList.Columns[2].HeaderText = "Make";
                dgvRentalBookingList.Columns[2].Width = 77;

                dgvRentalBookingList.Columns[3].HeaderText = "Model";
                dgvRentalBookingList.Columns[3].Width = 70;

                dgvRentalBookingList.Columns[4].HeaderText = "Year";
                dgvRentalBookingList.Columns[4].Width = 70;

                dgvRentalBookingList.Columns[5].HeaderText = "Mileage";
                dgvRentalBookingList.Columns[5].Width = 70;

                dgvRentalBookingList.Columns[6].HeaderText = "Rental Price Per Day";
                dgvRentalBookingList.Columns[6].Width = 100;

                dgvRentalBookingList.Columns[7].HeaderText = "Booking Start Date";
                dgvRentalBookingList.Columns[7].Width = 120;

                dgvRentalBookingList.Columns[8].HeaderText = "Booking End Date";
                dgvRentalBookingList.Columns[8].Width = 120;
             
            }
            lblRecord.Text=dgvRentalBookingList.Rows.Count.ToString();  
        }
        public frmRentalBookingList()
        {
            InitializeComponent();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (cmbFilter.Text == "All")
            {
                _dtBookingList.DefaultView.RowFilter = "";
            }
            txtValue.Enabled = (cmbFilter.Text != "All");
            btnFind.Enabled = (cmbFilter.Text  != "All");
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cmbFilter.SelectedIndex)
            {
                case 1:
                    FilterColumn = "MakeName";
                    break;
                case 2:
                    FilterColumn = "BookingID";
                    break;
                default:
                    FilterColumn = "";
                    break;
            }
            if(string.IsNullOrEmpty(txtValue.Text)|| FilterColumn=="")
            {
                _dtBookingList.DefaultView.RowFilter = "";
                return;
            }
            if (FilterColumn == "MakeName")
            {
                _dtBookingList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtValue.Text);
            }
            else
            {
                _dtBookingList.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn,txtValue.Text);
            }
            lblRecord.Text = _dtBookingList.Rows.Count.ToString();

        }
        private void frmRentalBookingList_Load(object sender, EventArgs e)
        {
            _LoadBookingInfoToTable();
            cmbFilter.SelectedIndex = 0;
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFilter.Text== "Booking Id")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void showRentalBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowBookingInfo frm = new frmShowBookingInfo((int)dgvRentalBookingList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}

