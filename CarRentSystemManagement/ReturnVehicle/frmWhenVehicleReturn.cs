using CarRentalBusinessLayer;
using CarRentSystemManagement.Global_Class;
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

namespace CarRentSystemManagement.ReturnVehicle
{
    public partial class frmWhenVehicleReturn : Form
    {
        clsVehicleReturn _VehicleReturn;
        int _VehicleReturnId;
        int _TransactionID=-1;
        public frmWhenVehicleReturn()
        {
            InitializeComponent();
        }
        public frmWhenVehicleReturn(int TransactionID)
        {
            InitializeComponent();
            _TransactionID = TransactionID;
        }
        private void _FillReturnVehicleInfoToGroupBox()
        {
            //...
            //in this function we have two mode the first one when vehicle already return.
            _VehicleReturn = clsVehicleReturn.FindVehicleReturnByTransactionId(_TransactionID);
            if (_VehicleReturn!=null)
            {
                btnReturn.Enabled=false;
                gbReturnVehicle.Enabled=false;
                lblMessage.Visible = true;
                lblReturnID.Text = _VehicleReturn.ReturnId.ToString();
                lblActualRentalDays.Text=_VehicleReturn.ActualRentDays.ToString();
                lblConsumedMileage.Text=_VehicleReturn.consumedMileage.ToString();
                lblActualReturnDate.Text = _VehicleReturn.ActualReturnDate.ToShortDateString();
                lblTotalDueAmount.Text = _VehicleReturn.ActualDueAmount.ToString()+ "$";
                lblTotalRemaining.Text = _VehicleReturn.TransactionInfo.ActualTotalRemaining.ToString() + "$";
                txtAdditionalCharges.Text= _VehicleReturn.AdditionalCharges.ToString();
                txtCurrentMileage.Text = _VehicleReturn.TransactionInfo.BookingInfo.vehicleInfo.Mileage.ToString();
                txtFinalCheckNotes.Text=_VehicleReturn.FinalCheckNotes.ToString();
                return;
            }

            //...
            //the second mode when transaction found and vehilce did not return yet. 
            gbReturnVehicle.Enabled = true;
            btnReturn.Enabled = true;
            lblMessage.Visible = false;
            lblActualReturnDate.Text = DateTime.Now.ToShortDateString();
            var CurrentDate = DateTime.Now;
            var BookingStartDate = ctrRentalTransactionWithFilter1.RentalTransaction.BookingInfo.BookingStartDate;
            TimeSpan diffDate = CurrentDate - BookingStartDate;
            double TotalDays = diffDate.TotalDays;
            lblActualRentalDays.Text = (Math.Ceiling(TotalDays)).ToString();
            lblTotalDueAmount.Text = (Convert.ToInt32(lblActualRentalDays.Text) * ctrRentalTransactionWithFilter1.RentalTransaction.BookingInfo.vehicleInfo.RentalPricePerDay).ToString();
            lblTotalRemaining.Text = (ctrRentalTransactionWithFilter1.RentalTransaction.BookingInfo.intialDueAmount- Convert.ToSingle(lblTotalDueAmount.Text)).ToString()+ "$";
            txtAdditionalCharges.Text = "";
            txtCurrentMileage.Text = "";
            txtFinalCheckNotes.Text = "";
        }
        private void _ResetDefaultSettings()
        {
            btnReturn.Enabled = false;
            lblMessage.Visible = false;
            lblActualReturnDate.Text = "[mm/dd/yyyy]";
            lblActualRentalDays.Text = "[????]";
            lblConsumedMileage.Text = "[????]";
            lblReturnID.Text = "[????]";
            lblTotalDueAmount.Text = "[$$$$]";
            lblTotalRemaining.Text = "[$$$$]";
            txtAdditionalCharges.Text = "";
            txtCurrentMileage.Text = "";
            txtFinalCheckNotes.Text = "";
            gbReturnVehicle.Enabled = false;
        }
        private void ctrRentalTransactionWithFilter1_TransactionFound(int TransactionId)
        {
            _TransactionID = TransactionId;
            //In Case Transaction id doesn't exist, reset default settings and return
            if (TransactionId == -1)
            {
                _ResetDefaultSettings();
                return;
            }
            _FillReturnVehicleInfoToGroupBox();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren()) 
                return;

            if (MessageBox.Show("Are you sure you want to return the reserved car?","Return Vehicle",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                _VehicleReturn =new clsVehicleReturn();
                _VehicleReturn.TransactionID = ctrRentalTransactionWithFilter1.TransactionID;

                if (txtAdditionalCharges.Text == "")                
                    _VehicleReturn.AdditionalCharges = 0; 
                else
                    _VehicleReturn.AdditionalCharges = Convert.ToSingle(txtAdditionalCharges.Text);

                _VehicleReturn.CurrentMileage=Convert.ToDecimal(txtCurrentMileage.Text);
                _VehicleReturn.FinalCheckNotes=txtFinalCheckNotes.Text;
                _VehicleReturn.ActualReturnDate = DateTime.Now;
                decimal prevMileage = clsRentalTransaction.FindTransaction(_TransactionID).BookingInfo.vehicleInfo.Mileage;

                if (_VehicleReturn.ReturnVehicle())
                {
                    lblConsumedMileage.Text = (_VehicleReturn.CurrentMileage - prevMileage).ToString();
                    lblReturnID.Text = _VehicleReturn.ReturnId.ToString();
                    MessageBox.Show("Vehilce returned successfully.", "Vehilce Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void txtCurrentMileage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentMileage.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentMileage, "This field is required. Please insert the current vehilce mileage");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtCurrentMileage, null);
            }
        }
        private void txtCurrentMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar);
        }
        private void frmWhenVehicleReturn_Load(object sender, EventArgs e)
        {
            if (_TransactionID == -1)
                return;
            ctrRentalTransactionWithFilter1.EnableFilter = false;
            ctrRentalTransactionWithFilter1.LoadTransactionInfo(_TransactionID);
            _FillReturnVehicleInfoToGroupBox();
        }
        private void frmWhenVehicleReturn_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void ctrRentalTransactionWithFilter1_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
