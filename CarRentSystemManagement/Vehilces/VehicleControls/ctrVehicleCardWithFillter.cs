using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.Vehilces.VehicleControls
{
    public partial class ctrFindVehicle : UserControl
    {      
        public event Action<int> VehicleFound;
        protected virtual void OnVehicleFound(int vehicleID)
        {
            Action<int> handle = VehicleFound;
            if (handle != null)
            {
                handle(vehicleID);
            }
        }

        bool EnableFilter = true;
        int _VehicleID = -1;
        public bool FilterEnable
        {
            get { return EnableFilter; }
            set
            {
                EnableFilter = value;
                switch(EnableFilter)
                {
                    case true:
                        cmbFind.Enabled = true;
                        txtSearchBy.Enabled= true;
                        break;
                    default:
                        cmbFind.Enabled = false;
                        txtSearchBy.Enabled= false;
                        break;

                }
            }

        }
        public void LoadVehicleInfo(int vehicleID)
        {
            _VehicleID = vehicleID;
            txtSearchBy.Text = _VehicleID.ToString();
            cmbFind.SelectedIndex = 1;
            FindNow();
            
        }
        public ctrFindVehicle()
        {
            InitializeComponent();
        }
        private void ctrFindVehicle_Load(object sender, EventArgs e)
        {
            if (FilterEnable)
                cmbFind.SelectedIndex = 0;
        }
        private void txtSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFind.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void txtSearchBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBy.Text))
            {
                if (cmbFind.SelectedIndex == 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtSearchBy, "Please eneter Plate number you want to search for");
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtSearchBy, "Please enter vehicle id you want to search for.");
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSearchBy, "");
                FindNow();
            }
        }
        private void FindNow()
        {
            switch(cmbFind.SelectedIndex)
            {
                case 0:
                    ctrVehicleInfo1.LoadVehicleInfo(txtSearchBy.Text);
                    break;
                case 1:
                    ctrVehicleInfo1.LoadVehicleInfo(Convert.ToInt32(txtSearchBy.Text));
                    break;
                default:
                    break;
            }
            if(ctrVehicleInfo1.ExposeVehicleInfo !=null)
            {
                OnVehicleFound(ctrVehicleInfo1.ExposeVehicleInfo.vehicleID);
            }
        }
    }
}
