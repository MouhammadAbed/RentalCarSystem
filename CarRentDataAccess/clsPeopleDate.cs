using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarRentDataAccess
{
    public  class clsPeopleDate
    {
        public static bool FindPersonByID(int PersonID,ref string FirstName,ref string SecondName,ref string LastName,ref string Phone)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("prPeople_Find",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            LastName = (string)reader["LastName"];
                            Phone = (string)reader["PhoneNumber"];
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
        public static int AddNewPerson(string FirstName,string SecondName,string LastName,string Phone)
        {
            int newID = -1;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prPeople_Add", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", @FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", SecondName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.Add("@NewPersonID", SqlDbType.Int);
                    cmd.Parameters["@NewPersonID"].Direction = ParameterDirection.Output;

                    try
                    {
                        connection .Open();
                        newID=cmd.ExecuteNonQuery();
                        newID = Convert.ToInt32(cmd.Parameters["@NewPersonID"].Value);
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        newID = -1;
                    }
                }
            }
            return newID;
        }
        public static bool isPersonExist(int PersonID)
        {
            bool isExist = false;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("prPeople_IsExist",connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    SqlParameter ReturnValue = new SqlParameter();
                    ReturnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValue);
                    try
                    {
                        connection .Open();
                        cmd.ExecuteNonQuery();
                        isExist = Convert.ToBoolean(ReturnValue.Value);
                    }
                    catch (Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        isExist = false;
                    }
                }
            }
            return isExist;
        }
        public static bool updatePersonInfo(int PersonID ,string FirstName ,string SecondName,string LastName,string Phone)
        {
            int RowAffected = 0;
            using(SqlConnection connection = new SqlConnection (clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prPeople_UpdateInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", PersonID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@secondName", SecondName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    SqlParameter ReturnValue =new SqlParameter();
                    ReturnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValue );
                    try
                    {
                        connection .Open();
                        cmd.ExecuteNonQuery();
                        RowAffected = (int)ReturnValue.Value;
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
        public static DataTable getAllPeople()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("prPeople_GetAll", connection))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
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
        public static bool DeletePerson(int ID)
        {
            int RowAffectedf = 0;
            using(SqlConnection connection = new SqlConnection(clsConnection.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand ("prPeople_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", ID);
                    SqlParameter ReturnValue = new SqlParameter();
                    ReturnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ReturnValue);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        RowAffectedf = (int)ReturnValue.Value;
                    }
                    catch(Exception ex)
                    {
                        clsEventloagData.SaveEventToEventLogEntry(ex.Message, clsEventloagData.enEventLogEntry.enError);
                        RowAffectedf = 0;
                    }
                }
            }return RowAffectedf != 0;
        }
    }
}
