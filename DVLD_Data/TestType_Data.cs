using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data
{
    public class clsTestType_DAL
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable TestTypesTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes";

            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    TestTypesTable.Load(Reader);
                }
            }
            catch (Exception ex)
            {
                //Catch The exception here
            }
            finally
            {
                Connection.Close();
            }
            return TestTypesTable;
        }

        public static bool UpdateTestTypeInfo(int TestTypeID, string NewTestTypeTitle, string NewTestTypeDescription, double NewTestTypeFees)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Update TestTypes 
                             SET TestTypeTitle = @NewTestTypeTitle, TestTypeDescription = @NewTestTypeDescription, TestTypeFees = @NewTestTypeFees
                             WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NewTestTypeTitle", NewTestTypeTitle);
            Command.Parameters.AddWithValue("@NewTestTypeDescription", NewTestTypeDescription);
            Command.Parameters.AddWithValue("@NewTestTypeFees", NewTestTypeFees);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                //Handle the exception here
            }
            finally
            {
                Connection.Close();
            }
            return isUpdated;
        }

        public static bool GetTestTypeInfo(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref double TestTypeFees)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    isFound = true;
                    TestTypeTitle = Convert.ToString( Reader["TestTypeTitle"]);
                    TestTypeDescription = Convert.ToString(Reader["TestTypeDescription"]);
                    TestTypeFees = Convert.ToDouble(Reader["TestTypeFees"]);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception here
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static double GetTestTypeFeesBy(int TestTypeID)
        {
            double Fees = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT TestTypeFees FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    Fees = Convert.ToDouble(result);
            }
            catch
            {
                //Exceptions Handler
            }
            finally
            {
                Connection.Close();
            }
            return Fees;

        }
    }
}
