using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsFuelTypeData
    {
        public static bool FindFuelTypeByID(int FuelTypeID,ref string FuelTypeName)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("stp_GetFuleTypeByID",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", FuelTypeID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader= cmd.ExecuteReader();
                        if(reader.Read())
                        {
                            isFound = true;
                            FuelTypeName = (string)reader["TypeName"];
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }
            return isFound;
        }

        public static bool FindFuelTypeByName(ref int FuelTypeID, string FuelTypeName)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stp_GetFuleTypeByName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeName", FuelTypeName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            FuelTypeID = (int)reader["FuelTypeID"];
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

        public static DataTable GetAllFuelTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stp_GetAllFuelTypes", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        if(read.HasRows)
                        {
                            dt.Load(read);
                        }
                    }
                    catch(Exception ex)
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
