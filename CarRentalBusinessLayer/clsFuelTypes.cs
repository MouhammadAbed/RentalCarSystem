using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsFuelTypes
    {
        public int FuelTypeID { get; set; }
        public string FuelName { get; set; }

        private clsFuelTypes(int FuelTypeID, string FuelName)
        {
            this.FuelTypeID = FuelTypeID;
            this.FuelName = FuelName;
        }
        public static clsFuelTypes FindFuelType(int FuelTypeID)
        {
            string FuelTypeName = "";
            if (clsFuelTypeData.FindFuelTypeByID(FuelTypeID, ref FuelTypeName))
            {
                return new clsFuelTypes(FuelTypeID, FuelTypeName);
            }
            return null;
        }
        public static clsFuelTypes FindFuelType(string FuelTypeName)
        {
            int FuelTypeID = 0;
            if (clsFuelTypeData.FindFuelTypeByName(ref FuelTypeID, FuelTypeName))
            {
                return new clsFuelTypes(FuelTypeID, FuelTypeName);
            }
            return null;
        }
        public static DataTable GetAllFuelTypes()
        {
            return clsFuelTypeData.GetAllFuelTypes();
        }
    }
}
