using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace CarRentDataAccess
{
    public class clsVehicleData
    {
        public static bool FindVehicleByID (int ID, ref int makeID,ref string model,ref int year,ref decimal mileage,  ref float rentalPricePerDay,
            ref string plateNumber,ref int vehicleCategory,ref int fuelTypeID,ref bool isAvailable,ref string Imagepath)
        {
            bool Found = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prVehicle_Find", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleID", ID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Found = true;
                            makeID = (int)reader["MakeID"];
                            model = (string)reader["Model"];
                            year = (int)reader["Year"];
                            mileage = (decimal)reader["Milleage"];
                            rentalPricePerDay = Convert.ToSingle(reader["RentalRatePerDay"]);
                            plateNumber = (string)reader["PlateNumber"];
                            vehicleCategory = (int)reader["VehicleCategory"];
                            fuelTypeID = (int)reader["FueltypeID"];
                            isAvailable = Convert.ToBoolean(reader["IsAvailable"]);
                            if (reader["ImagePath"] == System.DBNull.Value)
                                Imagepath = "";
                            else
                                Imagepath = (string)reader["ImagePath"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        Found =false;
                    }
                }
            }
            return Found;
        }

        public static bool FindVehicleByPlateNumber(ref int VehiclleID, ref int makeID, ref string model, ref int year, ref decimal mileage,
         ref float rentalPricePerDay, string plateNumber, ref int vehicleCategory, ref int fuelTypeID, ref bool isAvailable, ref string Imagepath)
        {
            bool Found = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prVehicle_FindByPlateNumber", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Found = true;
                            makeID = (int)reader["MakeID"];
                            model = (string)reader["Model"];
                            year = (int)reader["Year"];
                            mileage = (decimal)reader["Milleage"];
                            rentalPricePerDay = Convert.ToSingle(reader["RentalRatePerDay"]);
                            VehiclleID = (int)reader["VehicleID"];
                             vehicleCategory = (int)reader["VehicleCategory"];
                            fuelTypeID = (int)reader["FueltypeID"];
                            if (reader["ImagePath"] == System.DBNull.Value)
                                Imagepath = "";
                            else
                                Imagepath = (string)reader["ImagePath"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        Found = false;
                    }
                }
            }
            return Found;
        }
        public static int AddNewVehicle( int makeID, string model,int year, decimal mileage, float rentalPricePerDay,
        string plateNumber, int vehicleCategory, int fuelTypeID, bool isAvailable, string Imagepath)
        {
            int NewVehicleID = -1;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prVehicle_AddNew", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MakeID", makeID);
                    cmd.Parameters.AddWithValue("@Model", model);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Milleage", mileage);
                    cmd.Parameters.AddWithValue("@RentalPricePerDay", rentalPricePerDay);
                    cmd.Parameters.AddWithValue("@PlateNumber", plateNumber);
                    cmd.Parameters.AddWithValue("@VehicleCategoryID", vehicleCategory);
                    cmd.Parameters.AddWithValue("@FuelTypeID", fuelTypeID);
                    if ( Imagepath == "")
                        cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ImagePath", Imagepath);

                    cmd.Parameters.Add("@NewVehicleID", SqlDbType.Int);
                    cmd.Parameters["@NewVehicleID"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        NewVehicleID =(int)cmd.Parameters["@NewVehicleID"].Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        NewVehicleID = -1;
                    }

                }
                return NewVehicleID;
            }
        }
        public static bool DeleteVehicle(int ID)
        {
            int ReturnValue = 0;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prVehilce_Delete",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vehicleID", ID);
                    SqlParameter IsDeleteParam = new SqlParameter();
                    IsDeleteParam.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(IsDeleteParam);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        ReturnValue= (int)IsDeleteParam.Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        ReturnValue = 0;
                    }
                }
            }
            return ReturnValue != 0;
        }
        public static DataTable GetAllVehiles()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prVehilce_GetAll",connection))
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
        public static DataTable getAllAvailableVehicle()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prVehilce_GetAllAvailableCars", connection))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        dt.Load(null);
                    }
                }
            }return dt;
        }
        public static bool UpdateVehicleInfo( int VehicleID, int makeID, string model, int year, decimal mileage, float rentalPricePerDay,
        string plateNumber, int vehicleCategory, int fuelTypeID, bool isAvailable, string Imagepath)
        {
            int RowAffected = 0;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prVehicle_Updated", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VehicleID", VehicleID);
                    cmd.Parameters.AddWithValue("@MakeID", makeID);
                    cmd.Parameters.AddWithValue("@Model", model);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Milleage", mileage);
                    cmd.Parameters.AddWithValue("@RentalRatePerDay", rentalPricePerDay);
                    cmd.Parameters.AddWithValue("PlateNumber", plateNumber);
                    cmd.Parameters.AddWithValue("@VehicleCategoryID", vehicleCategory);
                    cmd.Parameters.AddWithValue("@FuelTypeID", fuelTypeID);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);
                    if (Imagepath =="")
                        cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ImagePath", Imagepath);
                    SqlParameter outerParameter = new SqlParameter();
                    outerParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(outerParameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        RowAffected = (int)outerParameter.Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        RowAffected = 0;
                    }
                }
            }
            return RowAffected != 0;
        }
    }
}
