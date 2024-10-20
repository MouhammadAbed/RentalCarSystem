using CarRentDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBusinessLayer
{
    public class clsCategory
    {
        public int CategoryID { get; set; } 
        public string CategoryName { get; set; }    

        public clsCategory(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
        public static clsCategory FindCategory(int categoryID)
        {
            string CategoryName = string.Empty;
            if(clsCategoryData.FindCategoryByID(categoryID,ref CategoryName))
            {
                return new clsCategory(categoryID,CategoryName);
            }
            return null;
        }
        public static clsCategory FindCategory(string CategoryName)
        {
            int categoryID =0;
            if (clsCategoryData.FindCategoryByName(ref categoryID, CategoryName))
            {
                return new clsCategory(categoryID, CategoryName);
            }
            return null;
        }
        public static DataTable getAllVehicleCategories()
        {
            return clsCategoryData.GetAllCategories();
        }
    }
}
