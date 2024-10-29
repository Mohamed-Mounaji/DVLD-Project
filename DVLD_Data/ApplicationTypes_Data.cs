using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public static class clsApplicationType_DAL
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable AppTypesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM ApplicationTypes";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using(SqlDataReader Reader = Command.ExecuteReader())
                {
                    AppTypesTable.Load(Reader);
                }
            }
            catch(Exception ex)
            {
                //Catch The exception here
            }
            finally
            {
                Connection.Close();
            }
            return AppTypesTable;
        }

        public static bool UpdateApplicationTypeInfo(int ApplicationTypeID, string NewApplicationTypeTitle, double NewApplicationTypeFees)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Update ApplicationTypes 
                             SET ApplicationTypeTitle = @NewAppTitle, ApplicationFees = @NewAppFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NewAppTitle", NewApplicationTypeTitle);
            Command.Parameters.AddWithValue("@NewAppFees", NewApplicationTypeFees);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {
                //Handle the exception here
            }
            finally
            {
                Connection.Close();
            }
            return isUpdated;
        }

        public static bool GetApplicationInfo(int ApplicationTypeID, ref string ApplicationTypeTitle, ref double ApplicationTypeFees)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    ApplicationTypeTitle = Convert.ToString(Reader["ApplicationTypeTitle"]);
                    ApplicationTypeFees = Convert.ToDouble(Reader["ApplicationFees"]);
                }
            }
            catch(Exception ex)
            {
                //Handle the exception here
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static string GetTypeTitleBy(int ApplicationTypeID)
        {
            string TypeTitle = null;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT ApplicationTypeTitle FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    TypeTitle = Convert.ToString(result);
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return TypeTitle;
        }

        public  static double GetTypeFees(int ApplicationTypeID)
        {
            double TypeFees = -1;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = @"SELECT ApplicationFees FROM ApplicationTypes
                             WHERE ApplicationTypeID  = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    TypeFees = Convert.ToDouble(result);
            }
            catch
            {
                //For logging and handling exceptions
            }
            finally
            {
                Connection.Close();
            }
            return TypeFees;
        }
    }
}
