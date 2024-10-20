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
    public partial class frmCustomerLIst : Form
    {
        DataTable _dtCustomer = new DataTable();
        public frmCustomerLIst()
        {
            InitializeComponent();
        }
        private void _LoadCustomerList()
        {
            _dtCustomer = clsCustomer.getCustomerList();
            dgvCustomerList.DataSource = _dtCustomer;
            if (dgvCustomerList.SelectedRows.Count > 0 )
            {
                dgvCustomerList.Columns[0].HeaderText = "Customer ID";
                dgvCustomerList.Columns[0].Width = 150;

                dgvCustomerList.Columns[1].HeaderText = "Person ID";
                dgvCustomerList.Columns[1].Width = 150;

                dgvCustomerList.Columns[2].HeaderText = "Full Name Name";
                dgvCustomerList.Columns[2].Width = 260;

                dgvCustomerList.Columns[3].HeaderText = "Driver License ID";
                dgvCustomerList.Columns[3].Width = 220;

                dgvCustomerList.Columns[4].HeaderText = "Phone Number";
                dgvCustomerList.Columns[4].Width = 150;

            }
            lblRecord.Text= dgvCustomerList.Rows.Count.ToString();
        }
        private void frmCustomerLIst_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedText = "All";
            _LoadCustomerList();
       }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFilter.Text)
            {
                case "All":
                    txtFilterValue.Text = "";
                    _dtCustomer.DefaultView.RowFilter = "";
                    txtFilterValue.Enabled = false;
                    btnSearch.Enabled= false;   
                    break;
                default:
                    txtFilterValue.Enabled = true;
                    btnSearch.Enabled = true;
                    break;              
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilter.Text)
            {
                case "Customer Id":
                    FilterColumn = "CustomerID";
                    break;
                case "Person Id":
                    FilterColumn = "PersonID";
                    break;
                default:
                    FilterColumn = "All";
                    break;                   
            }
            if(cbFilter.SelectedText =="All"|| txtFilterValue.Text == "")
            {
                _dtCustomer.DefaultView.RowFilter = "";                
            }
            else
            {
                _dtCustomer.DefaultView.RowFilter=string.Format("[{0}] = {1}", FilterColumn,txtFilterValue.Text);    
            }
            lblRecord.Text = dgvCustomerList.Rows.Count.ToString();
        }
        private void showCustomerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo frm = new frmCustomerInfo((int)dgvCustomerList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer((int)dgvCustomerList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
        }
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this customer?","Delete Customer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsCustomer.DeleteCustomer((int)dgvCustomerList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Customer delte successfully", "Delete customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}

