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

namespace CarRentSystemManagement.Vehilces
{
    public partial class frmGetAllVehicles : Form
    {
        DataTable _dtAllVehicles = clsVehicle.GetAllVehilce();
        public frmGetAllVehicles()
        {
            InitializeComponent();
            _dtAllVehicles = clsVehicle.GetAllVehilce();
        }
        private void _LoadVehiclesList()
        {
            dgvVehiclesList.DataSource = clsVehicle.GetAllVehilce();
            cmbFilter.SelectedIndex = 0;
            if(dgvVehiclesList.Rows.Count > 0 )
            {
                dgvVehiclesList.Columns[0].Name = "Vehicle ID";
                dgvVehiclesList.Columns[0].Width= 100;

                dgvVehiclesList.Columns[1].Name = "Make Name";
                dgvVehiclesList.Columns[1].Width = 100;

                dgvVehiclesList.Columns[2].Name = "Model";
                dgvVehiclesList.Columns[2].Width = 100;

                dgvVehiclesList.Columns[3].Name = "Year";
                dgvVehiclesList.Columns[3].Width = 100;

                dgvVehiclesList.Columns[4].Name = "Mileage";
                dgvVehiclesList.Columns[4].Width = 100;

                dgvVehiclesList.Columns[5].Name = "Rental Price";
                dgvVehiclesList.Columns[5].Width = 100;
               
                dgvVehiclesList.Columns[6].Name = "Category Name";
                dgvVehiclesList.Columns[6].Width = 100;

                dgvVehiclesList.Columns[7].Name = "Fuel Type";
                dgvVehiclesList.Columns[7].Width = 100;

                dgvVehiclesList.Columns[8].Name = "Plate Number";
                dgvVehiclesList.Columns[8].Width = 100;

                dgvVehiclesList.Columns[9].Name = "Is Available";
                dgvVehiclesList.Columns[9].Width = 100;
            }
            lblRecord.Text=dgvVehiclesList.RowCount.ToString();
        }
        private void frmGetAllVehicles_Load(object sender, EventArgs e)
        {
            _LoadVehiclesList();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsAvailable";
            string Index = cmbFilter.Text;
            byte FilterValue = 0;
            switch (Index)
            {
                case "All":
                    break;
                case "Available":
                    FilterValue = 1;
                    break;
                case "Not Available":
                    FilterValue = 0;
                    break;
            }
            if (Index == "All")
                _dtAllVehicles.DefaultView.RowFilter = "";
            else
                _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            //_dtBookingList.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn,txtValue.Text);
            lblRecord.Text = _dtAllVehicles.Rows.Count.ToString();
        }
        private void showVehicleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehilceInfo frm = new frmShowVehilceInfo((int)dgvVehiclesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();   
        }
        private void updateVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle((int)dgvVehiclesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(dgvVehiclesList.CurrentRow.Cells[9].Value) == 0)
            {
                MessageBox.Show("Car Can't be delete because it's rented. Try again when vehilce return.", "Delete vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if(MessageBox.Show("Are you sure you want to delete this vehicle: ","Delete vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsVehicle.DeleteVehicle((int)dgvVehiclesList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Vehicle Deleted successfully", "Vehicle Delted", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Vehicle delte failed", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void addNewVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateVehicle frm = new frmAddUpdateVehicle();
            frm.ShowDialog();
        }

    }
}
