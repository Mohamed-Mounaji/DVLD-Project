using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public static class clsTestAppointment_DAL
    {
        public static DataTable GetAppointmentsTableBasedOn(byte TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            DataTable AppointmentsTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"
                             SELECT
                                TestAppointmentID as 'Appointment ID',  
                                AppointmentDate as 'Appointment Date',
                                PaidFees as 'PaidFees',
                                IsLocked as 'Is Locked'
                             FROM TestAppointments
                             WHERE TestTypeID = @TestTypeID AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    AppointmentsTable.Load(reader);
                }
            }
            catch
            {
                //Handle Exception here
            }
            finally
            {
                Connection.Close();
            }
            return AppointmentsTable;

        }
        
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool isLocked)
        {
            int AppointmentID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                             VALUES(@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
                             SELECT SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", isLocked);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    AppointmentID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle Exception here
            }
            finally
            {
                Connection.Close();
            }

            return AppointmentID;
        }
        
        public static bool UpdateTestAppointmentInfo(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, double PaidFees, int CreatedByUserID, bool isLocked)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestAppointments
                                SET [TestTypeID] = @TestTypeID
                                   ,[LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
                                   ,[AppointmentDate] = @AppointmentDate
                                   ,[PaidFees] = @PaidFees
                                   ,[CreatedByUserID] = @CreatedByUserID
                                   ,[IsLocked] = @IsLocked
                             WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", isLocked);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch
            {
                //Handle
            }
            finally
            { 
                Connection.Close();
            }
            return isUpdated;

        }
    
        public static bool GetTestAppointmentInfo(int TestAppointmentID, ref byte TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref double PaidFees, ref int CreatedByUserID, ref bool isLocked)
        {
            bool Succeeded = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM TestAppointments 
                             WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                Connection.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    if(Reader.Read())
                    {
                        Succeeded = true;

                        TestTypeID = Convert.ToByte(Reader["TestTypeID"]);
                        LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                        AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                        PaidFees = Convert.ToDouble(Reader["PaidFees"]);
                        CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                        isLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    }
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
            return Succeeded;
        }
    
        public static bool HasActiveAppointment(byte TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool HasAppointment = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM TestAppointments 
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID AND IsLocked = 0";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    HasAppointment = true;
            }
            catch
            {
                //HandleExceptions
            }
            finally
            {
                Connection.Close();
            }

            return HasAppointment;
        }

        public static bool DeleteAppointment(int TestAppointmentID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = "DELETE TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                //Exceptions handler
            }
            finally
            {
                Connection.Close();
            }
            return RowsAffected >0;
        }

        public static List<int> GetAppointmentsIDsBy(int LocalDrivingLicenseApplicationID)
        {
            List<int> IDs = new List<int>();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT TestAppointmentID FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                Connection.Open();
                using(SqlDataReader Reader = Command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        int ID = Convert.ToInt32(Reader["TestAppointmentID"]);
                        IDs.Add(ID);
                    }
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
            finally
            {
                Connection.Close();
            }
            return IDs;
        }


    }
}