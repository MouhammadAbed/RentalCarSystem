using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsVehicleCategoryData
    {
        public static bool FindCategoryByID(int CategoryID,ref string categoryName)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stp_GetVehicleCategoryByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", CategoryID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            isFound = true;
                            categoryName = (string)reader["CategoryName"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        isFound = false;
                    }
                }
            }
            return isFound;
        }
        public static DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("stp_GetAllVehicleCategories", connection))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        dt = null;
                    }
                }
            }
            return dt;
        }
    }
}
