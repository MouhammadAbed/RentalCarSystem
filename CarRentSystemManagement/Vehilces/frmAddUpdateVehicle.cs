using CarRentalBusinessLayer;
using CarRentSystemManagement.Global_Class;
using CarRentSystemManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.Vehilces
{
    public partial class frmAddUpdateVehicle : Form
    {
        enum enMode { enUpdate =1,enAdd = 2}
        enMode _Mode = enMode.enUpdate;
        int _VehicleID = 0;
        clsVehicle _vehicle;
        public frmAddUpdateVehicle(int vehicle=0)
        {
            InitializeComponent();
            _VehicleID = vehicle;
            if(vehicle == 0)
            {
                _ResetDefaultSettings();
                _Mode = enMode.enAdd;
                _vehicle = new clsVehicle();
            }
            else
            {
                _Mode = enMode.enUpdate;
                _vehicle= clsVehicle.FindVehicle(_VehicleID);
            }
        }
        private void _ResetDefaultSettings()
        {
            lblVehicleID.Text = "[????]";
            cmbMake.Text = "Mercedes";
            txtModel.Text = "";
            nudYear.Value = Convert.ToDateTime(DateTime.Now).Year;
            cmbCategory.Text = "Sedan";
            txtRentalPricePerDay.Text = string.Empty;
            chbIsAvailable.Checked = true;
            txtPlateNumber.Text = string.Empty;
            txtMileage.Text = string.Empty;
            pbImage.Image = Resources.icons8_car_94;
        }
        private void _LoadAllMakes()
        {
            DataTable dtMake = clsVehicleMake.GetAllMakes();
            if (dtMake.Rows.Count > 0)
            {

                foreach (DataRow row in dtMake.Rows)
                {
                    cmbMake.Items.Add(row["MakeName"]);
                }
            }
        }
        private void _loadAllCategories()
        {
            DataTable dtCategories = clsCategory.getAllVehicleCategories();
            if (dtCategories.Rows.Count > 0)
            {
                foreach(DataRow row in dtCategories.Rows)
                {
                    cmbCategory.Items.Add(row["CategoryName"]);
                }
            }
        }
        private void _loadAllFuelTypes()
        {
            DataTable dtFuelTypes = clsFuelTypes.GetAllFuelTypes();
            if (dtFuelTypes.Rows.Count > 0)
            {
                foreach(DataRow row in dtFuelTypes.Rows)
                {
                    cmbFuelType.Items.Add(row["TypeName"]);
                }
            }
        }
        private void _LoadVehicleInfo()
        {
            if(_vehicle==null)
            {
                _ResetDefaultSettings();
                return;
            }
            lblVehicleID.Text = _vehicle.vehicleID.ToString();
            cmbMake.Text=_vehicle.MakeInfo.MakeName;
            cmbFuelType.Text = _vehicle.FuelTypeInfo.FuelName;
            cmbCategory.Text = _vehicle.CategoryInfo.CategoryName;
            txtMileage.Text = _vehicle.Mileage.ToString();
            txtModel.Text = _vehicle.Model;
            txtPlateNumber.Text = _vehicle.PlateNumber;
            txtRentalPricePerDay.Text = _vehicle.RentalPricePerDay.ToString();
            nudYear.Value = _vehicle.Year;
            if (_vehicle.ImagePath == "")
            {
                pbImage.Image = Resources.icons8_car_94;
            }
            else
            {
                pbImage.ImageLocation = _vehicle.ImagePath;
            }
        }
        private void frmAddUpdateVehicle_Load(object sender, EventArgs e)
        {
            _loadAllCategories();
            _loadAllFuelTypes();
            _LoadAllMakes();
            if (_Mode == enMode.enAdd)
            {
                lblTitle.Text = "Add New Vehicle";
                return;
            }
            _LoadVehicleInfo();
        }
        private void _LoadData()
        {
            if (!_HandleVehilceImage())
            {
                return;
            }
            _vehicle.MakeID = clsVehicleMake.FindMakeBy(cmbMake.Text).MakeID;
            _vehicle.Model = txtModel.Text;
            _vehicle.Year = Convert.ToInt32(nudYear.Value);
            _vehicle.Mileage=Convert.ToDecimal(txtMileage.Text);
            _vehicle.RentalPricePerDay = Convert.ToSingle(txtRentalPricePerDay.Text);
            _vehicle.PlateNumber = txtPlateNumber.Text;
            _vehicle.vechicleCategory = clsCategory.FindCategory(cmbCategory.Text).CategoryID;
            _vehicle.FuelTypeID = clsFuelTypes.FindFuelType(cmbFuelType.Text).FuelTypeID;
            _vehicle.isAvailable = chbIsAvailable.Checked ? true : false;
            if (pbImage.ImageLocation != null)
                _vehicle.ImagePath = pbImage.ImageLocation;
            linkLabelRemove.Enabled=(pbImage.ImageLocation != null);
        }
        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtRentalPricePerDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void TextBoxValidating(object sender, CancelEventArgs e)
        {
            TextBox temp = (sender as TextBox);
            if (string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, null);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool _HandleVehilceImage()
        {
            if (pbImage.ImageLocation != _vehicle.ImagePath)
            {
                if (_vehicle.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_vehicle.ImagePath);
                    }
                    catch
                    {

                    }
                }
                if (pbImage.ImageLocation != null)
                {
                    string SourceImageFile = pbImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            pbImage.Image = Resources.icons8_car_94;
            linkLabelRemove.Enabled = false;

        }
        private void linklableAddNewPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbImage.Load(selectedFilePath);
                linkLabelRemove.Visible = true;
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to save vehicle info.", "Save vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _LoadData();
                if (_vehicle.Save())
                {
                    MessageBox.Show("Vehicle saved successfully.", "Save Vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    lblVehicleID.Text = _vehicle.vehicleID.ToString();
                    _Mode = enMode.enUpdate;
                }
            }            
        }
    }
}
