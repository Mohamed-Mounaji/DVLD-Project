using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public static class clsCountry_DAL
    {
        public static DataTable GetAllCountries()
        {
            DataTable CountriesTable  = new DataTable();
            SqlConnection Connection = new  SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                CountriesTable.Load(Reader);

                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return CountriesTable;
        }

        public static string GetCountryNameBy(int CountryID)
        {
            string CountryName = "";
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != DBNull.Value)
                    CountryName = Convert.ToString(result);
            }
            catch
            {
                //Handle The Exception
            }
            finally
            {
                Connection.Close();
            }

            return CountryName;
        }

        public static int GetCountryIDBy(string CountryName)
        {
            int CountryID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != DBNull.Value)
                    CountryID = Convert.ToInt16(result);
            }
            catch
            {
                //Handle The Exception
            }
            finally
            {
                Connection.Close();
            }

            return CountryID;
        }

    }
}
