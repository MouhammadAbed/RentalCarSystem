using CarRentDataAccess;
using System.Data;

namespace CarRentalBusinessLayer
{
    public class clsVehicle
    {
        enum enMode { enUpdate = 1, enAdd = 2 }
        public int vehicleID { get; set; }
        public int MakeID { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Mileage { get; set; }
        public float RentalPricePerDay { get; set; }
        public string PlateNumber { get; set; }
        public int vechicleCategory { get; set; }
        public int FuelTypeID { get; set; }
        public bool isAvailable { get; set; }
        public string ImagePath { get; set; }
        public clsVehicleMake MakeInfo;
        public clsVehicleCategory CategoryInfo;
        public clsFuelTypes FuelTypeInfo;
        enMode _Mode = enMode.enUpdate;

        public clsVehicle()
        {
            this.vehicleID = -1;
            this.MakeID = 0;
            this.Model = string.Empty;
            this.Year = 0;
            this.RentalPricePerDay = 0;
            this.PlateNumber = string.Empty;
            this.vechicleCategory = 0;
            this.FuelTypeID = 0;
            this.isAvailable = false;
            this.ImagePath = "";
            _Mode = enMode.enAdd;
        }
        private clsVehicle(int vehicleID, int makeID, string model, int year, decimal mileage, float rentalPricePerDay, string plateNumber,
            int vechicleCategory, int fuelTypeID, bool isAvailable, string imagePath)
        {
            this.vehicleID = vehicleID;
            MakeID = makeID;
            Model = model;
            Year = year;
            this.Mileage = mileage;
            RentalPricePerDay = rentalPricePerDay;
            PlateNumber = plateNumber;
            this.vechicleCategory = vechicleCategory;
            FuelTypeID = fuelTypeID;
            this.isAvailable = isAvailable;
            this.ImagePath = imagePath;
            MakeInfo = clsVehicleMake.FindMakeBy(MakeID);
            CategoryInfo = clsVehicleCategory.FindCategory(this.vechicleCategory);
            FuelTypeInfo = clsFuelTypes.FindFuelType(this.FuelTypeID);
            _Mode = enMode.enUpdate;
        }
        public static clsVehicle FindVehicle(int vehicleID)
        {
            int makeID = 0; string model = string.Empty; int year = 0; decimal mileage = 0; float rentalPricePerDay = 0; string plateNumber = string.Empty;
            int vehicleCategory = 0; int fuelTypeID = 0; bool isAvailable = false; string imageIPath = string.Empty;
            if (clsVehicleData.FindVehicleByID(vehicleID, ref makeID, ref model, ref year, ref mileage, ref rentalPricePerDay, ref plateNumber,
                ref vehicleCategory, ref fuelTypeID, ref isAvailable, ref imageIPath))
            {
                return new clsVehicle(vehicleID, makeID, model, year, mileage, rentalPricePerDay, plateNumber, vehicleCategory, fuelTypeID,
                    isAvailable, imageIPath);
            }
            return null;
        }
        public static clsVehicle FindVehicle(string plateNumber)
        {
            int vehicleID = 0; int makeID = 0; string model = string.Empty; int year = 0; decimal mileage = 0; float rentalPricePerDay = 0; 
            int vehicleCategory = 0; int fuelTypeID = 0; bool isAvailable = false; string imageIPath = string.Empty;
            if (clsVehicleData.FindVehicleByPlateNumber(ref vehicleID, ref makeID, ref model, ref year, ref mileage, ref rentalPricePerDay,  plateNumber,
                ref vehicleCategory, ref fuelTypeID, ref isAvailable, ref imageIPath))
            {
                return new clsVehicle(vehicleID, makeID, model, year, mileage, rentalPricePerDay, plateNumber, vehicleCategory, fuelTypeID,
                    isAvailable, imageIPath);
            }
            return null;
        }
        private bool _AddNewVehicle()
        {
            this.vehicleID = clsVehicleData.AddNewVehicle(this.MakeID, this.Model, this.Year, this.Mileage, this.RentalPricePerDay,
                this.PlateNumber, this.vechicleCategory, this.FuelTypeID, this.isAvailable, this.ImagePath);

            return this.vehicleID != -1;
        }
        private bool _updateVehicleInfo()
        {
            return clsVehicleData.UpdateVehicleInfo(this.vehicleID, this.MakeID, this.Model, this.Year, this.Mileage, this.RentalPricePerDay,
                this.PlateNumber, this.vechicleCategory, this.FuelTypeID, this.isAvailable, this.ImagePath);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enUpdate:
                    if (_updateVehicleInfo())
                        return true;
                    else
                        return false;
                case enMode.enAdd:
                    if (_AddNewVehicle())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
            }
            return false;
        }
        public static bool DeleteVehicle(int ID)
        {
            return clsVehicleData.DeleteVehicle(ID);
        }
        public static DataTable GetAllVehilce()
        {
            return clsVehicleData.GetAllVehiles();
        }
        public static DataTable GetAllAvailableVehicles()
        {
            return clsVehicleData.getAllAvailableVehicle();
        }
    }
 }
