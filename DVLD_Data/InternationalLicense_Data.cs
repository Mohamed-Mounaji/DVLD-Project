using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsInternationalLicense_DAL
    {
        // Adds New Licenses row to the database and returns its ID if the operation succeeds otherwise returns -1
        public static int AddNewLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int internationLicenseID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO InternationalLicenses
                            VALUES(@applicationID, @driverID, @issuedUsingLocalLicenseID, @issueDate, @expirationDate, @isActive, @createdByUserID);
                            SELECT SCOPE_IDENTITY();";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@applicationID", applicationID);
            Command.Parameters.AddWithValue("@driverID", driverID);
            Command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@issueDate", issueDate);
            Command.Parameters.AddWithValue("@expirationDate", expirationDate);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                    internationLicenseID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }

            return internationLicenseID;
        }

        // Returns true the License fields updated successfully otherwise returns flase
        public static bool UpdateLicense(int InternationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE InternationalLicenses
                               SET ApplicationID = @applicationID
                                  ,DriverID = @driverID
                                  ,IssuedUsingLocalLicenseID = @issuedUsingLocalLicenseID
                                  ,IssueDate = @issueDate
                                  ,ExpirationDate = @expirationDate
                                  ,IsActive = @isActive
                                  ,CreatedByUserID = @createdByUserID
                             WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand  Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            Command.Parameters.AddWithValue("@applicationID", applicationID);
            Command.Parameters.AddWithValue("@driverID", driverID);
            Command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@issueDate", issueDate);
            Command.Parameters.AddWithValue("@expirationDate", expirationDate);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }
            return isUpdated;
        }

        //Returns the licenseID if found otherwise returns -1
        public static int GetActiveLicenseIDByDriverID(int DriverID)
        {
            int licenseID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenseID FROM InternationalLicenses 
                             WHERE DriverID = @DriverID AND IsActive = 1;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                    licenseID = Convert.ToInt32(result);
                    
            }
            catch
            {
                //Handle and log exceptions
            }
            finally
            {
                Connection.Close();
            }
            return licenseID;
        }

        public static DataTable GetAllLicenses()
        {
            DataTable Licensestable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenseID 'Int. License ID', ApplicationID 'Application ID',
                                    IssuedUsingLocalLicenseID 'Local License ID', IssueDate 'Issue Date',
                                    ExpirationDate 'Expiration Date', IsActive 'is Active'
                             FROM InternationalLicenses";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    Licensestable.Load(Reader);
                }
            }
            catch
            {
                //Handle Exceptions and log them
            }
            finally
            {
                Connection.Close();
            }
            return Licensestable;
        }

        public static bool GetLicenseInfo(int internationalLicenseID, ref int applicationID, ref int driverID, ref int issuedUsingLocalLicenseID, ref DateTime issueDate, ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @internationalLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
            try
            {
                Connection.Open();
                using(SqlDataReader Reader = Command.ExecuteReader())
                {
                    if(Reader.Read())
                    {
                        applicationID = Convert.ToInt32(Reader["ApplicationID"]);
                        driverID = Convert.ToInt32(Reader["DriverID"]);
                        issuedUsingLocalLicenseID = Convert.ToInt32(Reader["IssuedUsingLocalLicenseID"]);
                        issueDate = Convert.ToDateTime(Reader["IssueDate"]);
                        expirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                        isActive = Convert.ToBoolean(Reader["IsActive"]);
                        createdByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                        isFound = true;
                    }
                }
            }
            catch
            {
                //Handle exceptions
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
    
        public static DataTable GetLicensesTableByPersonID(int personID)
        {
            DataTable LicensesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT InternationalLicenseID 'Int. License ID', ApplicationID 'Application ID', IssuedUsingLocalLicenseID 'Local License ID', IssueDate 'Issue Date', ExpirationDate 'Expiration Date', IsActive 'is Active'
                             FROM InternationalLicenses L
                             JOIN Drivers D ON D.DriverID = L.DriverID
                             JOIN People P ON P.PersonID = D.PersonID
                             WHERE P.PersonID = @personID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@personID", personID);
            try
            {
                Connection.Open();
                using( SqlDataReader Reader = Command.ExecuteReader())
                {
                    LicensesTable.Load(Reader);
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return LicensesTable;
        }
    }
}
