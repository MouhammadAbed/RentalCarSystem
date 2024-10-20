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

namespace CarRentSystemManagement.RentalBooking
{
    public partial class ctrrRentalBookingCard : UserControl
    {
        int _BookingId;
        clsBooking _Booking;
        public ctrrRentalBookingCard()
        {
            InitializeComponent();
        }
        public int bookingId
        {
            get{ return _BookingId; } 
        }
        public clsBooking Booking
        {
            get { return _Booking; }
        }
        private void _ResetDefaultSettings()
        {
            lblBookingId.Text ="[????]";
            lblCustomerName.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblRentalPricePerDay.Text = "[$$$$]";
            lblInitialRentalDays.Text = "[????]";
            lblInitialDueAmount.Text = "[$$$$]";
            lblPickUpLocation.Text = "[????]";
            lblDropOfLocation.Text = "[????]";
            lblMake.Text = "[????]";
            lblUserName.Text = "[????]";
        }
        private void _FillBookingInfo()
        {
            lblBookingId.Text = _Booking.BookingID.ToString();
            lblCustomerName.Text = _Booking.CustomerInfo.FullName();
            lblStartDate.Text = _Booking.BookingStartDate.ToShortDateString();
            lblEndDate.Text = _Booking.BookingEndDate.ToShortDateString();
            lblRentalPricePerDay.Text = _Booking.RentalPricePerDay.ToString();
            lblInitialRentalDays.Text = _Booking.intialRentalDays.ToString();
            lblInitialDueAmount.Text = _Booking.intialDueAmount.ToString();
            lblPickUpLocation.Text = _Booking.PickDownLocation;
            lblDropOfLocation.Text = _Booking.PickDownLocation;
            lblMake.Text = _Booking.vehicleInfo.MakeInfo.MakeName;
            lblUserName.Text = _Booking.userInfo.userName;
        }
        private void _FindNow()
        {
            _Booking = clsBooking.FindBookingInfo(_BookingId);
            if (_Booking == null)
            {
                _ResetDefaultSettings();
                return;
            }
            _FillBookingInfo();
        }
        public void _LoadBookingInfo(int bookingID)
        {
            _BookingId = bookingID;
            _FindNow();
        }
    }
}
