using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsVehicleCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        private clsVehicleCategory(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public static clsVehicleCategory FindCategory(int categoryID)
        {
            string categoryName = "";
            if (clsVehicleCategoryData.FindCategoryByID(categoryID, ref categoryName))
            {
                return new clsVehicleCategory(categoryID, categoryName);
            }
            return null;
        }

        public static DataTable GetAllVehicleCategories()
        {
            DataTable dt = clsVehicleCategoryData.GetAllCategories();
            return dt;
        }
    }
}
