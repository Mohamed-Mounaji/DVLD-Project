using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsTest_DAL
    {
        public static int AddNewRow(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Tests
                             VALUES(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            using (SqlCommand Command = new SqlCommand(Query, Connection)) 
            {
                Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                Command.Parameters.AddWithValue("@TestResult", TestResult);
                Command.Parameters.AddWithValue("@Notes", Notes);
                Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                try
                {
                    Connection.Open();
                    object result = Command.ExecuteScalar();
                    if (result != null)
                        TestID = Convert.ToInt32(result);
                }
                catch
                {
                    //Handle Exceptions here
                }
                finally
                {
                    Connection.Close();
                }
            }

            return TestID;
        }

        public static bool isFailedOnTest(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            bool isFailed = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM TestAppointments TApp
                             join Tests T on TAPP.TestAppointmentID = T.TestAppointmentID
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID AND TestResult = 0";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isFailed = true;
            }
            catch
            {
                //HANDLE EXCEPTIONS
            }
            finally
            {
                Connection.Close();
            }
            return isFailed;
        }

        public static bool DeleteTestsBy(int TestAppointmentID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "DELETE Tests WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return RowsAffected > 0;
        }
    }
}
