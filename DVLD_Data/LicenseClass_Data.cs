using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsLicenseClass_DAL
    {
        public static DataTable GetAllClassesNames()
        {
            DataTable LicenseClassesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT ClassName FROM LicenseClasses";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using(SqlDataReader Reader = Command.ExecuteReader())
                {
                    LicenseClassesTable.Load(Reader);
                }
            }
            catch
            {
                //Handle the exceptions here if any occurs
            }
            finally
            {
                Connection.Close();
            }

            return LicenseClassesTable;
        }

        public static string GetClassNameBy(int LicenseClassID)
        {
            string ClassName = null;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                    ClassName = Convert.ToString(result);
            }
            catch
            {
                //Handle Any exception here
            }
            finally
            {
                Connection.Close();
            }
            return ClassName;
        }

        public static int GetValidityLength(int LicenseClassID)
        {
            int ValidityLength = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT DefaultValidityLength FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    ValidityLength = Convert.ToInt32(result);
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }
            return ValidityLength;
        }

        public static double GetClassFees(int licenseClassID)
        {
            double ClassFees = -1;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = "SELECT ClassFees FROM LicenseClasses WHERE LicenseClassID = @licenseClassID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@licenseClassID", licenseClassID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    ClassFees = Convert.ToDouble(result);
            }
            catch
            {
                //Handle any exceptions if any occurs
            }
            finally
            {
                Connection.Close();
            }
            return ClassFees;
        }
    }
}
