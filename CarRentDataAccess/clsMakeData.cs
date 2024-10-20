using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{

    public class clsMakeData
    {
        public static bool GetCarMakeByID(int MakeID,ref string MakeName)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("Stp_GetMakesByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", MakeID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            MakeName = (string)reader["MakeName"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        isFound =false;
                    }
                }
            }
            return isFound;
        }
        public static bool FindMakeByName(ref int MakeID,string MakeName)
        {
            bool found = false; 
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("Stp_GetMakesByName", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Make", MakeName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            found = true;
                            MakeID = (int)reader["MakeID"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        found =false;
                    }
                }
            }return found;
        }
        public static DataTable GetAllMakes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stp_GetAllMakes", connection))
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
                        dt.Load(null);
                    }
                }
            }
            return dt;
        }
        public static DataTable GetAllVehicleDescription()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Stp_GetAllVehicleDescription", connection))
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
                        dt.Load(null);
                    }
                }
            }
            return dt;
        }
        public static int GetVehicleIDByVehicleDescription(string VehicleInfo)
        {
            int VehicleID = 0;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetVehicleIDByMakeInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleDescription", VehicleInfo);
                    SqlParameter ReturnValueParameter = new SqlParameter();
                    ReturnValueParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValueParameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        VehicleID = (int)ReturnValueParameter.Value;
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        VehicleID = 0;
                    }
                }
            }return VehicleID;
        }
    }
}
