using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsDriver_DAL
    {
        public static DataTable GetAllDriversTable()
        {
            DataTable DriversTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Drivers_View";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    DriversTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                //Handle Exceptions
            }
            finally
            { 
                Connection.Close();
            }
            return DriversTable;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Drivers 
                             VALUES(@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    DriverID = Convert.ToInt32(result);
            }
            catch
            {
                //Log Exceptions From Here
            }
            finally
            {
                Connection.Close();
            }
            return DriverID;
        }

        public static int GetDriverID(int PersonID)
        {
            int DriverID = -1;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = "SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    DriverID = Convert.ToInt32(result);
            }
            catch
            {
                //Catch and handle exception or log them
            }
            finally
            {
                Connection.Close();
            }
            return DriverID;
        }

        public static bool GetDriverInfo(int driverID, ref int personID, ref int createdByUserID, ref DateTime createdDate)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", driverID);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        isFound = true;
                        personID = Convert.ToInt32(reader["PersonID"]);
                        createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                }
            }
            catch
            {
                //Handle Exceptions here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        
    }
}
