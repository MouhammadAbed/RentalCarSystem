using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsTransactionData
    {
        public static bool FindTransaction(int TransactionID,ref float initialTotalDueAmount,ref string paymentDetails,
            ref float actualDueAmount,ref float actualTotalRemaining,ref DateTime transactionDate,ref int bookingID)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prTransaction_Find",connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@Transaction", TransactionID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;
                                initialTotalDueAmount = Convert.ToSingle(reader["paidIntialTotalDueAmount"]);

                                if (reader["paymentDetails"] == DBNull.Value)
                                    paymentDetails = "";
                                else
                                    paymentDetails = (string)reader["paymentDetails"];

                                if (reader["ActualTotalDueAmount"] == DBNull.Value)
                                    actualDueAmount = 0;
                                else
                                    actualDueAmount = Convert.ToSingle(reader["ActualTotalDueAmount"]);

                                if (reader["TotalRemaining"] == DBNull.Value)
                                    actualTotalRemaining = 0;
                                else
                                    actualTotalRemaining = Convert.ToSingle(reader["TotalRemaining"]);

                                transactionDate = (DateTime)reader["TransactionDate"];
                                bookingID = (int)reader["booking_ID"];
                            }
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
        public static DataTable GetAllTransaction()
        {
            DataTable dtRentalTransaction = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prTransaction_GetAll", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            dtRentalTransaction.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        dtRentalTransaction.Load(null);
                    }
                }
            }return dtRentalTransaction;
        }
    }
}
