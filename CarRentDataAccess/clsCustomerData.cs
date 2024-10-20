using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public class clsCustomerData
    {
        public static bool FindCustomer(int CustomerID ,ref string DriverLicenseID,ref int PersonID)
        {
            bool IsFound = false;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prCustomer_Find",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound= true;
                            DriverLicenseID = (string)reader["DriverLicenseID"];
                            PersonID = (int)reader["PersonID"];

                        }
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }
        public static bool FindCustomer(ref int CustomerID, string DriverLicenseID, ref int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prCustomer_FindByDrivingLicense", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DLId", DriverLicenseID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerID = (int)reader["CustomerID"];
                            PersonID = (int)reader["PersonID"];
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }
        public static int AddNewCustomer(string DriverLicenseID,int PersonID)
        {
            int NewID = -1;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prCustomers_Add", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.Add("@CustomerID",SqlDbType.Int);
                    cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Output;
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        NewID = Convert.ToInt32(cmd.Parameters["@CustomerID"].Value);
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        NewID = -1;
                    }
                }
            }return NewID;
        }
        public static bool UpdateCustomer(int customerid, string DriverLicenseID,int PersonID)
        {
            bool Updated = true;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prCustomer_Update", connection))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverLicenseID", DriverLicenseID);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    SqlParameter returnValueParameter = new SqlParameter();
                    returnValueParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValueParameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Updated = true;
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        Updated = false ;
                    }
                }
            }return Updated;
        }
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prCustomer_GetAll", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
            }
            return dt;
        }
        public static bool isCustomerExist(int ID)
        {
            int Found = 0;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prCustomer_isExist", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", ID);
                    SqlParameter ReturnParameter = new SqlParameter();
                    ReturnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnParameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        Found = (int)ReturnParameter.Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        Found = 0;
                    }
                }
            }return Found != 0;
        }
        public static bool DeleteCustomer(int CustomerID)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prCustomer_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    try
                    {
                        connection.Open();
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        rowAffected = 0;
                    }
                }
            }return rowAffected != 0;
        }                
        public static DataTable GetAllCustomerNames()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString)) 
            {
                using(SqlCommand cmd = new SqlCommand("prCustomer_GetAllCustomerName", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                    }
                    catch(SqlException ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        dt = null;
                    }
                }
            }return dt;
        }
        public static int GetCustomerIDByName(string FullName)
        {
            int CustomerID = 0;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prCustomer_FindCustomerIdByFullName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", FullName);
                    SqlParameter ReturnValueParameter = new SqlParameter();
                    ReturnValueParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValueParameter);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        CustomerID=(int)ReturnValueParameter.Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        CustomerID = 0;
                    }
                }
            }return CustomerID;
        }
    }
}
