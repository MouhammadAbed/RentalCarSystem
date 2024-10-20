using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsBookingData
    {
        public static bool FindRetnalCarInfo(int BookingID,ref DateTime StartDate,ref DateTime EndDate,ref int VehicleID,
            ref short IntialRentalDays,ref float RentalPricePerDay,ref float intialDueAmount,ref string pickUpLocation,
            ref string DropOfLocation,ref string InitialCheckNotes, ref int CustomerID,ref int UserID)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("pr_BookingFindInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingID", BookingID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            StartDate = (DateTime)reader["BookingStartDate"];
                            EndDate = (DateTime)reader["BookingEndDate"];
                            VehicleID = (int)reader["Vehicle_ID"];
                            if (reader["PickUpLocaltion"] == DBNull.Value)
                            {
                                pickUpLocation = "";
                            }
                            else
                            {
                                pickUpLocation = (string)reader["PickUpLocaltion"];
                            }
                            if (reader["DropOfLocation"] == DBNull.Value)
                            {
                                DropOfLocation = "";
                            }
                            else
                            {
                                DropOfLocation = (string)reader["DropOfLocation"];
                            }
                            if (reader["InitialChekNotes"] == DBNull.Value)
                            {
                                InitialCheckNotes = "";
                            }
                            else
                            {
                                DropOfLocation = (string)reader["InitialChekNotes"];
                            }
                            intialDueAmount = Convert.ToSingle(reader["intialDueAmount"]);
                            IntialRentalDays = Convert.ToInt16(reader["intialRentalDays"]);
                            RentalPricePerDay = Convert.ToSingle(reader["RentalPricePerDay"]);
                            CustomerID = (int)reader["CustomerID"];
                            UserID = (int)reader["UserID"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        isFound = false;
                    }
                }
            }return isFound;
        }

        public static int BookingNewVehicle(DateTime StartDate, DateTime EndDate,  int VehicleID,string pickUpLocation,
            string DropOfLocation, string InitialCheckNotes, int CustomerID, int UserID)
        {
            int NewId = -1;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("pr_BookingNewVehicle", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingStartDate", StartDate);
                    cmd.Parameters.AddWithValue("@BookingEndDate", EndDate);
                    cmd.Parameters.AddWithValue("@VehicleID", VehicleID);
                    if (pickUpLocation == "")
                        cmd.Parameters.AddWithValue("@PickUpLocation", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PickUpLocation", pickUpLocation);

                    if (DropOfLocation == "")
                        cmd.Parameters.AddWithValue("@DropOfLocation", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DropOfLocation", DropOfLocation);

                    if (InitialCheckNotes == "")
                        cmd.Parameters.AddWithValue("@InitialCheckNote", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@InitialCheckNote", InitialCheckNotes);
                    cmd.Parameters.AddWithValue("@Customer_ID", CustomerID);
                    cmd.Parameters.AddWithValue("@User_ID", UserID);
                    cmd.Parameters.Add("@NewBookingID", SqlDbType.Int);
                    cmd.Parameters["@NewBookingID"].Direction= ParameterDirection.Output;
                    
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        NewId = (int)cmd.Parameters["@NewBookingID"].Value;
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        NewId = -1;
                    }
                }return NewId;
            }
        }
        public static DataTable GetAllBookingVehicles()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prBooking_GetAllCurrentBookingVehicles", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
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
