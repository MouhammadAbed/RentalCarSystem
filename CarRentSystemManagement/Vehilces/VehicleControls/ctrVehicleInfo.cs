using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalBusinessLayer;
using CarRentSystemManagement.Properties;

namespace CarRentSystemManagement.Vehilces.VehicleControls
{
    public partial class ctrVehicleInfo : UserControl
    {
        clsVehicle VehicleInfo;
        int _VehicleID;
        string _PlateNumber;

        public clsVehicle ExposeVehicleInfo
        {
            get { return VehicleInfo; }
        }
        public ctrVehicleInfo()
        {
            InitializeComponent();
        }
        private void RestDefaultSettings()
        {
            lblVehicleID.Text = "[????]";
            lblMake.Text = "[????]";
            lblModel.Text= "[????]";
            lblyear.Text= "[dd/mm/yyyy]";
            lblRentalPrice.Text= "[????]";
            lblPlateNumber.Text= "[????]";
            lblMileage.Text= "[????]";
            lblFuelType.Text= "[????]";
            lblCategory.Text= "[????]";
            chbIsAvailableForRent.Checked = true;
            pbImage.Image = Resources.icons8_car_94;
        }
        public void LoadVehicleInfo(int VehicleID)
        {
            _VehicleID= VehicleID;
            VehicleInfo= clsVehicle.FindVehicle(_VehicleID);
            if(VehicleInfo==null)
            {
                RestDefaultSettings();
                MessageBox.Show($"No vehicle Available with id {VehicleID}");
                return;
            }
            FillVehilceData();
        }
        public void LoadVehicleInfo(string PlateNumber)
        {
            _PlateNumber = PlateNumber;
            VehicleInfo = clsVehicle.FindVehicle(_PlateNumber);
            if (VehicleInfo == null)
            {
                RestDefaultSettings();
                MessageBox.Show($"No vehicle Available with plate number: {_PlateNumber}");
                return;
            }
            FillVehilceData();
        }
        private void FillVehilceData()
        {
            lblVehicleID.Text = VehicleInfo.vehicleID.ToString();
            lblMake.Text = VehicleInfo.MakeInfo.MakeName;
            lblModel.Text = VehicleInfo.Model;
            lblyear.Text = VehicleInfo.Year.ToString();
            lblRentalPrice.Text = VehicleInfo.RentalPricePerDay.ToString();
            lblMileage.Text = VehicleInfo.Mileage.ToString();
            lblFuelType.Text = VehicleInfo.FuelTypeInfo.FuelName;
            lblCategory.Text = VehicleInfo.CategoryInfo.CategoryName;
            lblPlateNumber.Text = VehicleInfo.PlateNumber;
            chbIsAvailableForRent.Checked = (VehicleInfo.isAvailable);            
            _LoadVehicleImage();
        }
        private void _LoadVehicleImage()
        {
            if(VehicleInfo.ImagePath=="")
            {
                pbImage.Image= Resources.icons8_car_94;
                return;
            }
            else
            {
                pbImage.ImageLocation = VehicleInfo.ImagePath;
            }
        }
    }
}
