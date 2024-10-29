using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public static class clsDetainedLicense_DAL 
    {

        //Return detain id if the insertion succeeds otherwise returns -1
        public static int AddNewDetain(int licenseID, DateTime detainDate, double fineFees, int createdByUserID)
        {
            int DetainID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO DetainedLicenses 
                             VALUES(@licenseID, @detainDate, @fineFees, @createdByUserID, 0, NULL, NULL, NULL);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@licenseID", licenseID);
            Command.Parameters.AddWithValue("@detainDate", detainDate);
            Command.Parameters.AddWithValue("@fineFees", fineFees);
            Command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    DetainID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle exceptions here
            }
            finally
            {
                Connection.Close();
            }
            return DetainID;
        }

        //Update the detain and set the release info and return true if updated, if not returns false
        public static bool ReleaseDetainedLicense(int detainID, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = @"UPDATE DetainedLicenses
                             SET IsReleased = 1,
                             	ReleaseDate = @releaseDate, 
                             	ReleasedByUserID = @releasedByUserID,
                             	ReleaseApplicationID = @releaseApplicationID
                             WHERE DetainID = @detainID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@detainID", detainID);
            Command.Parameters.AddWithValue("@releaseDate", releaseDate);
            Command.Parameters.AddWithValue("@releasedByUserID", releasedByUserID);
            Command.Parameters.AddWithValue("@releaseApplicationID", releaseApplicationID);
            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch
            {
                //Handle Exceptions here
            }
            finally
            {
                Connection.Close();
            }
            return isUpdated;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable detainedLicensesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 
                                 DL.DetainID, 
                                 DL.LicenseID, 
                                 DL.DetainDate,
                                 DL.IsReleased AS 'Is Released', 
                                 DL.FineFees AS 'Fine Fees', 
                                 DL.ReleaseDate AS 'Release Date',
                                 P.NationalNumber AS 'National Number',
                                 CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS 'Full Name', 
                                 DL.ReleaseApplicationID AS 'Release App. ID'
                             FROM 
                                 DetainedLicenses DL
                             JOIN 
                                 Licenses L ON L.LicenseID = DL.LicenseID
                             JOIN 
                                 Drivers D ON D.DriverID = L.DriverID
                             JOIN 
                                 People P ON P.PersonID = D.PersonID;
                             ";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    detainedLicensesTable.Load(reader);
                }
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }
            return detainedLicensesTable;
        }

        public static bool isLicenseDetained(int licenseID)
        {
            bool isDetained = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM DetainedLicenses
                             WHERE LicenseID = @licenseID AND IsReleased = 0;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@licenseID", licenseID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isDetained = true;
            }
            catch
            {
                //Handle any exceptions
            }
            finally
            {
                Connection.Close();
            }
            return isDetained;
        }

        public static bool GetNoneReleasedDetainInfoByLicenseID(int licenseID, ref int detainID, ref DateTime detainDate, ref double fineFees, ref int createdByUserID, ref bool isReleased, ref DateTime releaseDate, ref int releasedByUserID, ref int releaseApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @licenseID AND IsReleased = 0";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@licenseID", licenseID);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        isFound = true;
                        detainID = Convert.ToInt32(reader["DetainID"]);
                        detainDate = Convert.ToDateTime(reader["DetainDate"]);
                        fineFees = Convert.ToInt32(reader["FineFees"]);
                        createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        isReleased = Convert.ToBoolean(reader["IsReleased"]);
                        releaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                        releasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                        releaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }


    }
}
