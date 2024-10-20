using CarRentalBusinessLayer;
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

namespace CarRentSystemManagement.RentalBooking
{
    public partial class frmNewRentalBooking : Form
    {
        enum enMode { enUpdate =1 ,enAdd = 2}
        enMode _Mode = enMode.enUpdate;

        int _BookingID;
        clsBooking _Booking;
        public frmNewRentalBooking(int BookingID = 0)
        {
            InitializeComponent();
            _BookingID = BookingID;
            if(BookingID == 0)
            {
                _Mode = enMode.enAdd;
            }
            else
            {
                _Mode = enMode.enUpdate;
                _BookingID = BookingID;
            }
        }
        private void _LoadCustomerNamesToComboBox()
        {
            DataTable dtCustomers = clsCustomer.GetAllCustomerNames();

            int cout= dtCustomers.Rows.Count;
            foreach(DataRow row in  dtCustomers.Rows)
            {
                cmbCustomerName.Items.Add(row["FullName"]);
            }
            cmbCustomerName.SelectedIndex = 0;
        }
        private void _LoadVehicleMakesToComboBox()
        {
            DataTable dtMakes = clsVehicleMake.GetVehiclesDescription();
            foreach(DataRow row in dtMakes.Rows)
            {
                cmbVehicleMakes.Items.Add(row["VehicleInfo"]);
            }
            cmbVehicleMakes.SelectedIndex = 0;
        }
        private void _LoadBookingInfo()
        {
            _LoadCustomerNamesToComboBox();
            _LoadVehicleMakesToComboBox();
            if(_Mode==enMode.enAdd)
            {
                lblTitle.Text = "Booking New Vehicle";
                lblUserName.Text = clsGlobalUser.CurrentUser.userName;
                _Booking = new clsBooking();
                dtpStartDate.MinDate = DateTime.Now;
                dtpEndDate.MinDate = DateTime.Now.AddDays(1);
                
                return;
            }
            _Booking = clsBooking.FindBookingInfo(_BookingID);
            if(_Booking == null )
            {
                MessageBox.Show("Booking info was deleted.","Delete booking info",MessageBoxButtons.OK,MessageBoxIcon.Information); return;
            }
            dtpStartDate.MinDate = _Booking.BookingStartDate;
            dtpEndDate.MinDate = _Booking.BookingEndDate;
            lblBookingId.Text=_Booking.BookingID.ToString();
            cmbCustomerName.Text = _Booking.CustomerInfo.FullName();
            dtpStartDate.Value = _Booking.BookingStartDate;
            dtpEndDate.Value = _Booking.BookingEndDate;
            lblRentalPricePerDay.Text=_Booking.RentalPricePerDay.ToString();
            lblInitialRentalDays.Text = _Booking.intialRentalDays.ToString();
            lblInitialDueAmount.Text = _Booking.intialDueAmount.ToString();
            txtPickUpLocation.Text = _Booking.PickUpLocation;
            txtDropOfLocation.Text = _Booking.PickDownLocation;
            cmbVehicleMakes.Text = _Booking.vehicleInfo.MakeInfo.MakeName;
            lblUserName.Text = _Booking.userInfo.userName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmNewRentalBooking_Load(object sender, EventArgs e)
        {
            _LoadBookingInfo();
        }
        private void cmbCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(cmbCustomerName.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(cmbCustomerName, "This field is required");
            }
            else
            {
                e.Cancel =false;
                errorProvider1.SetError(cmbCustomerName, null);
            }
        }
        private void cmbVehicleMakes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbVehicleMakes.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbVehicleMakes, "This field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cmbVehicleMakes, null);
            }
        }
        private void _FillRentalBookingInfo()
        {
            _Booking.CustomerID=clsCustomer.GetCustomerIDByFullName(cmbCustomerName.Text);
            _Booking.BookingStartDate = dtpStartDate.Value;
            _Booking.BookingEndDate = dtpEndDate.Value;
            _Booking.PickUpLocation=txtPickUpLocation.Text;
            _Booking.PickDownLocation=txtDropOfLocation.Text;
            _Booking.UserID = clsGlobalUser.CurrentUser.UserID;
            _Booking.initialCheckNotes = txtInitalCheckNotes.Text;
            _Booking.VehicleID=clsVehicleMake.GetVehicleIdByMakeInfo(cmbVehicleMakes.Text);
            
            
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            
            if(MessageBox.Show("Are you sure you want to save booking.","Save Booking", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
                _FillRentalBookingInfo();
                if (_Booking.BookingVehicle())
                {
                    _Booking=clsBooking.FindBookingInfo(_Booking.BookingID);
                    lblBookingId.Text=_Booking.BookingID.ToString();
                    lblRentalPricePerDay.Text = _Booking.RentalPricePerDay.ToString();
                    lblInitialRentalDays.Text=_Booking.intialRentalDays.ToString();
                    lblInitialDueAmount.Text = _Booking.intialDueAmount.ToString();
                    MessageBox.Show($"booking save successfully. Toal rental Amount is: {_Booking.intialDueAmount} Toalt rental days is: {_Booking.intialRentalDays}","Save Booking",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vehicle is not available for rent.", "Vehicle Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

    }
}
