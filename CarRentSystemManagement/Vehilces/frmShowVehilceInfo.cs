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

namespace CarRentSystemManagement.Vehilces
{
    public partial class frmShowVehilceInfo : Form
    {
        int _vehicle;
        public frmShowVehilceInfo(int vehicle)
        {
            InitializeComponent();
            _vehicle = vehicle;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmShowVehilceInfo_Load(object sender, EventArgs e)
        {
            ctrVehicleInfo1.LoadVehicleInfo(_vehicle);
        }
        private void frmShowVehilceInfo_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void frmShowVehilceInfo_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
