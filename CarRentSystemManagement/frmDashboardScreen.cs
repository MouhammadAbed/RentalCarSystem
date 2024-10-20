using CarRentalBusinessLayer;
using CarRentSystemManagement.Customers;
using CarRentSystemManagement.GlobalClass;
using CarRentSystemManagement.RenatalTransaction;
using CarRentSystemManagement.RentalBooking;
using CarRentSystemManagement.ReturnVehicle;
using CarRentSystemManagement.Users;
using CarRentSystemManagement.Vehilces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement
{
    public partial class frmDashboardScreen : Form
    {
        Form frm;
        public frmDashboardScreen(Form logForm)
        {
            frm = logForm;
            InitializeComponent();
        }           
        public void LoadForm(object form)
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel= false;
            f.Dock= DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag= f;
            f.Show();
        }
        private void tsmAddNew_Click(object sender, EventArgs e)
        {
            LoadForm(new frmAddUpdateVehicle());
        }
        private void tsmFindVehilce_Click(object sender, EventArgs e)
        {
            LoadForm(new frmFindVehicle());
        }
        private void tsmVehicleList_Click(object sender, EventArgs e)
        {
            LoadForm(new frmGetAllVehicles());
        }
        private void tsmAddClient_Click(object sender, EventArgs e)
        {
            LoadForm(new frmAddUpdateCustomer()); 
        }
        private void tsmFindClient_Click(object sender, EventArgs e)
        {
            LoadForm(new frmFindCustomer());
        }
        private void tsmClientList_Click(object sender, EventArgs e)
        {
            LoadForm(new frmCustomerLIst());
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new frmAddUpdateUser());
        }
        private void frmDashboardScreen_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void frmDashboardScreen_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void signOUtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            frm.Close();
        }
        private void userListToolStrip_Click(object sender, EventArgs e)
        {
            LoadForm(new frmUsersList());            
        }
        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new frmUpdatePassword());
        }
        private void bookingVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new frmNewRentalBooking(15));
        }
        private void bookingVehicleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadForm(new frmNewRentalBooking());
        }
        private void showBookingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new frmRentalBookingList());
        }
        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new RentalTransactionList());
        }
        private void returnVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new frmWhenVehicleReturn());
        }
    }
}
