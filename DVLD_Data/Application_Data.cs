using DVLD_Data;
using System;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;

namespace DVLD_Business
{
    public class clsApplication_DAL
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Applications 
                             VALUES(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID) 
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    ApplicationID = Convert.ToInt32(Result);
            }
            catch(Exception ex)
            {
                //Handle any exceptions if occur
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }

        public static bool UpdateApplicationInfo(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Applications
                             SET ApplicantPersonID = @ApplicantPersonID, ApplicationDate = @ApplicationDate, ApplicationTypeID = @ApplicationTypeID, ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID
                             WHERE ApplicationID = @ApplicationID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return isUpdated;
        }

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref double PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                using(SqlDataReader Reader = Command.ExecuteReader())
                {
                    if(Reader.Read())
                    {
                        isFound = true;
                        ApplicantPersonID = Convert.ToInt32(Reader["ApplicantPersonID"]);
                        ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
                        ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);
                        ApplicationStatus = Convert.ToByte(Reader["ApplicationStatus"]);
                        LastStatusDate = Convert.ToDateTime(Reader["LastStatusDate"]);
                        PaidFees = Convert.ToDouble(Reader["PaidFees"]);
                        CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
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

        public static bool DeleteApplication(int ApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "DELETE Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                //I will handle exceptions later
            }
            finally
            {
                Connection.Close();
            }
            return RowsAffected > 0;
        }

        public static bool CancelApplication(int ApplicationID)
        {
            bool isCanceled = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Update Applications 
                               SET ApplicationStatus = 2 WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                isCanceled = Command.ExecuteNonQuery() > 0;
            }
            catch
            {
                //Handle any exceptions if occur
            }
            finally
            {
                Connection.Close();
            }
            return isCanceled;
        }
    }
}
