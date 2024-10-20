using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsRentalTransaction
    {
        enum enMode { enUpdate = 1,enAdd=2}
        public int TransactionID { get; set; }  
        public float initialTotalDueAmount { get; set; }
        public string PaymentDetails {get; set;}
        public float ActualDueAmount { get; set; }
        public float ActualTotalRemaining { get; set; }
        public DateTime TransactionDate { get; set; }
        public int bookingID { get; set; }
        public clsBooking BookingInfo;
        enMode _Mode = enMode.enUpdate;
        public clsRentalTransaction()
        {
            this.TransactionID = 0;
            this.initialTotalDueAmount = 0;
            this.PaymentDetails= string.Empty;
            this.ActualDueAmount = 0;
            this.ActualTotalRemaining= 0;
            this.TransactionDate = DateTime.MinValue;
            this.bookingID = 0;
        }
        private clsRentalTransaction(int transactionID, float initialTotalDueAmount, string paymentDetails, float actualDueAmount,
            float actualTotalRemaining, DateTime transactionDate, int bookingID)
        {
            TransactionID = transactionID;
            this.initialTotalDueAmount = initialTotalDueAmount;
            PaymentDetails = paymentDetails;
            ActualDueAmount = actualDueAmount;
            ActualTotalRemaining = actualTotalRemaining;
            TransactionDate = transactionDate;
            this.bookingID = bookingID;
            BookingInfo = clsBooking.FindBookingInfo(bookingID);
            _Mode = enMode.enUpdate;
        }
        public static clsRentalTransaction FindTransaction(int TransactionID) 
        {
            float initialTotalDueAmount = 0; string paymentDetails = string.Empty; float actualDueAmount = 0;
            float actualTotalRemaining = 0; DateTime transactionDate = DateTime.MinValue; int bookingID = 0;
            if(clsTransactionData.FindTransaction(TransactionID,ref initialTotalDueAmount,ref paymentDetails,ref actualDueAmount,
                ref actualTotalRemaining, ref transactionDate, ref bookingID))
            {
                return new clsRentalTransaction(TransactionID,initialTotalDueAmount, paymentDetails,actualDueAmount,actualTotalRemaining,
                    transactionDate,bookingID);
            }
            return null;
        }
        public static DataTable GetRentalTransactionList()
        {
            return clsTransactionData.GetAllTransaction();
        }

        public static bool isVehicleReturned(int TransactionId)
        {
            return clsReturnVehicleData.isVehicleReturned(TransactionId); 
        }
    }
}
