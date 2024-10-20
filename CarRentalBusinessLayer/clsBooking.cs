using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsBooking
    {
        enum enMode { enUpdate = 1,enAdd=2}
        public int BookingID { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public float RentalPricePerDay { get; set; }
        public short intialRentalDays { get; set; }
        public float intialDueAmount { get; set; }
        public string PickUpLocation { get; set; }
        public string PickDownLocation { get; set; }
        public string initialCheckNotes { get; set; }
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }

        public clsVehicle vehicleInfo;
        public clsUser userInfo;
        public clsCustomer CustomerInfo;
        enMode _Mode = enMode.enUpdate;
        public clsBooking()
        {
            _Mode = enMode.enAdd;
            this.BookingID= 0;
            this.BookingStartDate = DateTime.MinValue;
            this.BookingEndDate=DateTime.MinValue;
            this.RentalPricePerDay = 0;
            this.intialRentalDays = 0;
            this.intialDueAmount = 0;
            this.PickDownLocation = string.Empty;
            this.PickDownLocation= string.Empty;
            this.initialCheckNotes = string.Empty;
            this.VehicleID = 0;
            this.CustomerID = 0;
            this.UserID = 0;
        }
        private clsBooking(int bookingID, DateTime bookingStartDate, DateTime bookingEndDate, float rentalPricePerDay, 
            short intialRentalDays, float intialDueAmount, string pickUpLocation, string pickDownLocation, 
            string initialCheckNotes, int vehicleID, int customerID, int userID)
        {
            BookingID = bookingID;
            BookingStartDate = bookingStartDate;
            BookingEndDate = bookingEndDate;
            RentalPricePerDay = rentalPricePerDay;
            this.intialRentalDays = intialRentalDays;
            this.intialDueAmount = intialDueAmount;
            PickUpLocation = pickUpLocation;
            PickDownLocation = pickDownLocation;
            this.initialCheckNotes = initialCheckNotes;
            VehicleID = vehicleID;
            CustomerID = customerID;
            UserID = userID;
            vehicleInfo = clsVehicle.FindVehicle(vehicleID);
            userInfo = clsUser.FindUser(UserID);
            CustomerInfo = clsCustomer.FindCustomer(CustomerID);
            _Mode = enMode.enUpdate;
        }        
        public static clsBooking FindBookingInfo(int BookingID)
        {
            DateTime StartDate = DateTime.MinValue; DateTime EndDate = DateTime.MinValue; float RenatalPricePerDay = 0f;
            short intialRentalDays = 0;float rentalPricePerDay = 0f; float intialDueAmount = 0; string pickUpLocation = string.Empty;
            string pickDownLocation = string.Empty;string InitialCheckNotes = string.Empty;int vehicleID = 0;int CustomerID = 0;
            int userID = 0;
            if(clsBookingData.FindRetnalCarInfo(BookingID,ref StartDate,ref EndDate,ref vehicleID,ref intialRentalDays,ref rentalPricePerDay,
                ref intialDueAmount, ref pickUpLocation, ref pickDownLocation,ref InitialCheckNotes,ref CustomerID,ref userID))
            {
                return new clsBooking(BookingID, StartDate, EndDate, rentalPricePerDay, intialRentalDays, intialDueAmount, pickUpLocation,
                    pickDownLocation, InitialCheckNotes, vehicleID,CustomerID, userID);
            }
            return null;
        }
        public bool BookingVehicle()
        {
            this.BookingID= clsBookingData.BookingNewVehicle(this.BookingStartDate, this.BookingEndDate, this.VehicleID, this.PickUpLocation, this.PickDownLocation,
                this.initialCheckNotes, this.CustomerID, this.UserID);
            return this.BookingID != -1;
        }
        public static DataTable GetAllBookingVehicles()
        {
            return clsBookingData.GetAllBookingVehicles();
        }
    }    
}
