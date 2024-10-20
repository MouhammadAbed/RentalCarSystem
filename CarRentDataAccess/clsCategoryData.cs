using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsCategoryData
    {
        public static DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("stp_GetAllVehicleCategories", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        dt = null;
                    }
                }
            }return dt;
        }
        public static bool FindCategoryByID(int ID,ref string CategoryName)
        {
            bool found = false;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("stp_GetVehicleCategoryByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            found=true;
                            CategoryName = (string)reader["CategoryName"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        found = false;
                    }
                }
            }return found;
        }
        public static bool FindCategoryByName(ref int ID, string CategoryName)
        {
            bool found = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stp_GetVehicleCategoryByName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            found = true;
                            ID = (int)reader["CategoryID"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        found = false;
                    }
                }
            }
            return found;
        }
    }
}
