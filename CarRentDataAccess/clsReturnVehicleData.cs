using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsReturnVehicleData
    {
        public static bool FindVehicleReturnInfo(int ReturnID,ref DateTime actualReturnDate,ref int ActualRentDays,
            ref decimal currentMileage, ref decimal consumedMileage,ref string finalCheckNotes,ref float additionalCharges,
            ref int transactionID,ref float actualDueAmount)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("pr_VehicleReturnFind",connection))
                {
                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReturnID", ReturnID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            actualReturnDate =Convert.ToDateTime (reader["ActualReturnDate"]);
                            ActualRentDays = (int)reader["ActualRentDays"];
                            currentMileage = Convert.ToDecimal (reader["CurrentMilleage"]);
                            consumedMileage = Convert.ToDecimal(reader["ConsumedMilleage"]);
                            if (reader["finallChekNotes"] == DBNull.Value)
                                finalCheckNotes = "";
                            else
                                finalCheckNotes = (string)reader["finallChekNotes"];
                            transactionID = (int)reader["TransactionID"];
                            actualDueAmount = Convert.ToSingle(reader["ActualDueAmount"]);
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
        public static bool FindVehicleReturnInfoByTransactionId(ref int ReturnID, ref DateTime actualReturnDate, ref int ActualRentDays,
            ref decimal currentMileage, ref decimal consumedMileage, ref string finalCheckNotes, ref float additionalCharges,
             int transactionID, ref float actualDueAmount)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("pr_VehicleReturnFindByTransactionId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionId", transactionID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            actualReturnDate = Convert.ToDateTime(reader["ActualReturnDate"]);
                            ActualRentDays = (int)reader["ActualRentDays"];
                            currentMileage = Convert.ToDecimal(reader["CurrentMilleage"]);
                            consumedMileage = Convert.ToDecimal(reader["ConsumedMilleage"]);
                            if (reader["finallChekNotes"] == DBNull.Value)
                                finalCheckNotes = "";
                            else
                                finalCheckNotes = (string)reader["finallChekNotes"];
                            ReturnID = (int)reader["ReturnID"];
                            actualDueAmount = Convert.ToSingle(reader["ActualDueAmount"]);
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
        public static int ReturnVehicle(int TransactionID, float AdditionalCharges, string FinalCheckNotes,
             decimal CurrentMilleage, DateTime ActualReturnDate)
        {
            int ReturnID = -1;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("stp_WhenCarReturns", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                    cmd.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                    cmd.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                    if (FinalCheckNotes == "")
                        cmd.Parameters.AddWithValue("@FinalCheckNotes", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                    cmd.Parameters.AddWithValue("@CurrentMilleage", CurrentMilleage);
                    cmd.Parameters.Add("@VehicleReturnID", SqlDbType.Int);
                    cmd.Parameters["@VehicleReturnID"].Direction= ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        ReturnID = (int)cmd.Parameters["@VehicleReturnID"].Value;
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        ReturnID = -1;
                    }
                }
            }return ReturnID;
        }
        public static bool isVehicleReturned(int TransactionId)
        {
            int returnedValue = 1;
            using(SqlConnection Connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prTransaction_isVehicleReturned", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionId", TransactionId);
                    SqlParameter ReturnValueParameter = new SqlParameter();
                    ReturnValueParameter.Direction= ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValueParameter);
                    try
                    {
                        Connection.Open();
                        cmd.ExecuteNonQuery();
                        returnedValue = (int)ReturnValueParameter.Value;
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        returnedValue = 1;
                    }
                }
            }return returnedValue == 0;
        }
    }

}
