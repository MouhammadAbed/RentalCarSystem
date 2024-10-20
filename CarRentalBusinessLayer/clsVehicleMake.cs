using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsVehicleMake
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        private clsVehicleMake(int makeID, string makeName)
        {
            MakeID = makeID;
            MakeName = makeName;
        }
        public static clsVehicleMake FindMakeBy(int ID)
        {
            string MakeName = string.Empty;
            if (clsMakeData.GetCarMakeByID(ID, ref MakeName))
            {
                return new clsVehicleMake(ID, MakeName);
            }
            return null;
        }
        public static clsVehicleMake FindMakeBy(string MakeName)
        {
            int MakeID = 0;
            if (clsMakeData.FindMakeByName(ref MakeID, MakeName))
            {
                return new clsVehicleMake(MakeID, MakeName);
            }
            return null;
        }
        public static DataTable GetAllMakes()
        {
            return clsMakeData.GetAllMakes();
        }
        public static DataTable GetVehiclesDescription()
        {
            return clsMakeData.GetAllVehicleDescription();
        }
        public static int GetVehicleIdByMakeInfo(string MakeInfo)
        {
            return clsMakeData.GetVehicleIDByVehicleDescription(MakeInfo);
        }
    }
}
