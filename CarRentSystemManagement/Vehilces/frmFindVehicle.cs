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
    public partial class frmFindVehicle : Form
    {
        public frmFindVehicle()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ctrFindVehicle1_VehicleFound(int obj)
        {
            if (obj != -1)
            {
                MessageBox.Show("VehilceID: " + obj.ToString());
            }
            else
                MessageBox.Show("VehicleID doesn't not found");
        }
    }
}
