using System;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;

namespace DVLD_Data
{
    public static class clsLicense_DAL
    {
        public static int GetLicenseIDBy(int PersonID, int LicenseClassID, int IsActive)
        {
            int LicenseID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT LicenseID
                             FROM Licenses l
                             JOIN Drivers d ON d.DriverID = l.DriverID
                             WHERE PersonID = @PersonID AND l.LicenseClassID = @LicenseClassID AND IsActive = @IsActive";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    LicenseID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle any exceptions if occurs
            }
            finally
            {
                Connection.Close();
            }

            return LicenseID;
        }

        public static int AddNewLicense(int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, double paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            int LicenseID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Licenses
                             VALUES(@applicationID, @driverID, @licenseClassID, @issueDate, @expirationDate, @notes, @paidFees, @isActive, @issueReason, @createdByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@applicationID", applicationID);
            Command.Parameters.AddWithValue("@driverID", driverID);
            Command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            Command.Parameters.AddWithValue("@issueDate", issueDate);
            Command.Parameters.AddWithValue("@expirationDate", expirationDate);

            if (string.IsNullOrEmpty(notes.Trim()))
                Command.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@notes", notes);

            Command.Parameters.AddWithValue("@paidFees", paidFees);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@issueReason", issueReason);
            Command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    LicenseID = Convert.ToInt32(result);
            }
            catch
            {
                //HANDLE EXCEPTIONS HERE
            }
            finally
            { 
                Connection.Close(); 
            }

            return LicenseID;
        }
        
        public static bool UpdateLicenseInfo(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, double paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Licenses
                             SET ApplicationID = @applicationID,
                                 DriverID = @driverID,
                                 LicenseClassID = @licenseClassID,
                                 IssueDate = @issueDate,
                                 ExpirationDate = @expirationDate,
                                 Notes = @notes,
                                 PaidFees = @paidFees,
                                 IsActive = @isActive,
                                 IssueReason = @issueReason,
                                 CreatedByUserID = @createdByUserID
                             WHERE LicenseID = @licenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@licenseID", licenseID);
            Command.Parameters.AddWithValue("@applicationID", applicationID);
            Command.Parameters.AddWithValue("@driverID", driverID);
            Command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            Command.Parameters.AddWithValue("@issueDate", issueDate);
            Command.Parameters.AddWithValue("@expirationDate", expirationDate);

            if(string.IsNullOrEmpty(notes.Trim()))
                Command.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@notes", notes);

            Command.Parameters.AddWithValue("@paidFees", paidFees);
            Command.Parameters.AddWithValue("@isActive", isActive);
            Command.Parameters.AddWithValue("@issueReason", issueReason);
            Command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            
            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch
            {
                //Handle exceptions
            }
            finally
            {
                Connection.Close();
            }


            return isUpdated;
        }
        public static bool GetLicenseInfo(int LicenseID, ref int applicationID, ref  int driverID, ref int licenseClassID, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref double paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();
                using (SqlDataReader reader = Command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        isFound = true;
                        applicationID = Convert.ToInt32(reader["ApplicationID"]);
                        driverID = Convert.ToInt32(reader["DriverID"]);
                        licenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                        issueDate = Convert.ToDateTime(reader["IssueDate"]);
                        expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                        notes = Convert.ToString(reader["Notes"]);
                        paidFees = Convert.ToDouble(reader["PaidFees"]);
                        isActive = Convert.ToBoolean(reader["IsActive"]);
                        issueReason = Convert.ToByte(reader["IssueReason"]);
                        createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    }
                }
            }
            catch
            {
                //Handle exceptions here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
   
        public static int GetLicenseIDBy(int ApplicationID)
        {
            int licenseID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT LicenseID FROM Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    licenseID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }
            return licenseID;
        }

        public static bool isLicenseExists(int LicenseID)
        {
            bool isExists = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'Yes' FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isExists = true;
            }
            catch
            {
                //Log or handle exceptions here
            }
            finally
            {
                Connection.Close();
            }
            return isExists;
        }

        public static bool isLicenseExpired(int licenseID)
        {
            bool isExpired = false;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM Licenses
                             WHERE LicenseID = @licenseID AND ExpirationDate < GETDATE()";

            SqlCommand Command = new SqlCommand(Query , Connection);
            Command.Parameters.AddWithValue("@licenseID", licenseID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isExpired = true;
            }
            catch
            {
                //Handle any exceptions if occurs
            }
            finally
            {
                Connection.Close();
            }
            return isExpired;
        }
    }
}
