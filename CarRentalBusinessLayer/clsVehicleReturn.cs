using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsVehicleReturn
    {
        enum enMode { enUpdate =1 , enAdd=2}
        public int ReturnId { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualRentDays { get; set; }
        public decimal CurrentMileage {get;set;}
        public decimal consumedMileage { get; set; }
        public string FinalCheckNotes { get; set; }
        public float AdditionalCharges { get; set; }
        public int TransactionID { get; set; }
        public float ActualDueAmount { get; set; }
        public clsRentalTransaction TransactionInfo;
        enMode _Mode = enMode.enUpdate;
        public clsVehicleReturn()
        {
            this.ReturnId= 0;
            this.ActualReturnDate = DateTime.MinValue;
            this.ActualRentDays = 0;
            this.CurrentMileage = 0;
            this.consumedMileage = 0;
            this.FinalCheckNotes = string.Empty;
            this.AdditionalCharges = 0;
            this.TransactionID = 0;
            this.ActualDueAmount = 0;            
            _Mode = enMode.enAdd;
        }
        private clsVehicleReturn(int returnId, DateTime actualReturnDate,int ActualRentDays, decimal currentMileage, decimal consumedMileage, 
            string finalCheckNotes, float additionalCharges, int transactionID, float actualDueAmount)
        {
            ReturnId = returnId;
            ActualReturnDate = actualReturnDate;
            this.ActualRentDays = ActualRentDays;
            CurrentMileage = currentMileage;
            this.consumedMileage = consumedMileage;
            FinalCheckNotes = finalCheckNotes;
            AdditionalCharges = additionalCharges;
            TransactionID = transactionID;
            ActualDueAmount = actualDueAmount;
            TransactionInfo = clsRentalTransaction.FindTransaction(TransactionID);
            _Mode = enMode.enUpdate;
        }
        public static clsVehicleReturn FindVehicleReturn(int ReturnId)
        {
            DateTime actualReturnDate = DateTime.MinValue; int ActualRentDays = 0; decimal currentMileage = 0; decimal consumedMileage = 0;
            string finalCheckNotes = string.Empty; float additionalCharges = 0; int transactionID = 0; float actualDueAmount = 0;
            if(clsReturnVehicleData.FindVehicleReturnInfo(ReturnId,ref actualReturnDate,ref ActualRentDays,ref currentMileage,
                ref consumedMileage,ref finalCheckNotes,ref additionalCharges,ref transactionID,ref actualDueAmount))
            {
                return new clsVehicleReturn( ReturnId, actualReturnDate, ActualRentDays, currentMileage, consumedMileage,
                            finalCheckNotes, additionalCharges, transactionID, actualDueAmount);
            }return null;
        }
        public static clsVehicleReturn FindVehicleReturnByTransactionId(int transactionID)
        {
            int ReturnId = 0; DateTime actualReturnDate = DateTime.MinValue; int ActualRentDays = 0; decimal currentMileage = 0;
            decimal consumedMileage = 0; string finalCheckNotes = string.Empty; float additionalCharges = 0;  float actualDueAmount = 0;
            if (clsReturnVehicleData.FindVehicleReturnInfoByTransactionId(ref ReturnId, ref actualReturnDate, ref ActualRentDays, ref currentMileage,
                ref consumedMileage, ref finalCheckNotes, ref additionalCharges, transactionID, ref actualDueAmount))
            {
                return new clsVehicleReturn(ReturnId, actualReturnDate, ActualRentDays, currentMileage, consumedMileage,
                            finalCheckNotes, additionalCharges, transactionID, actualDueAmount);
            }
            return null;
        }
        public bool ReturnVehicle()
        {
            this.ReturnId= clsReturnVehicleData.ReturnVehicle(this.TransactionID, this.AdditionalCharges, this.FinalCheckNotes, this.CurrentMileage,
                this.ActualReturnDate);
            return this.ReturnId != -1;
        }
        public static bool isVehicleReturned(int TransactionId)
        {
            return clsReturnVehicleData.isVehicleReturned(TransactionId);
        }
    }
}
