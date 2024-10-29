using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public class clsLocalDrivingLicenseApplication_DAL
    {
        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int LDLApplicationID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications
                               VALUES(@ApplicationID, @LicenseClassID);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    LDLApplicationID = Convert.ToInt32(result);
            }
            catch
            {
                //HANDLE THE EXCEPTION HERE
            }
            finally
            {
                Connection.Close();
            }


            return LDLApplicationID;
        }

        public static int IsApplicationExists(int ApplicantID,  int LicenseClassID)
        {
            int ApplicationID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT ApplicationID FROM
                                (
                                  SELECT Applications.ApplicationID, Applications.ApplicantPersonID, LDLA.LicenseClassID, Applications.ApplicationStatus 
                                  FROM Applications 
                                  JOIN LocalDrivingLicenseApplications as LDLA on LDLA.ApplicationID = Applications.ApplicationID
                                )T1
                             WHERE ApplicantPersonID = @ApplicantID AND LicenseClassID = @LicenseClassID AND ApplicationStatus = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantID", ApplicantID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    ApplicationID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle the occured exceptions
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }

        public static DataTable GetApplicationsTable()
        {
            DataTable AppsTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                AppsTable.Load(Command.ExecuteReader());
            }
            catch
            {
                //HANDLE EXCEPTIONS
            }
            finally
            {
                Connection.Close();
            }

            return AppsTable;
        }

        public static bool isTestPassed(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            bool isPassed = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM Tests
                             INNER JOIN TestAppointments ON  TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                             where TestResult = 1 AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isPassed = true;
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }


            return isPassed;
        }

        public static bool GetLDLApplicationInfo(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                Connection.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    if(Reader.Read())
                    {
                        isFound = true;
                        ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                        LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                    }
                }
            }
            catch
            {
                //Handle Any Exceptions if occurs
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool DeleteBy(int LocalDrivingLicenseApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "DELETE LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
