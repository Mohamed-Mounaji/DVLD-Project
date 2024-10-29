using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Data
{
    public static class clsPerson_DAL
    {
        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber,
                                        DateTime DateOfBirth, bool Gender, string Phone, string Email, int NationalityCountryID, string Address, string ImagePath)
        {
            int PersonID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO People (FirstName, SecondName, ThirdName, LastName, NationalNumber, DateOfBirth,
                                        Gender, Phone, Email, NationalityCountryID, Address, ImagePath) 
                                 Values(@FirstName, @SecondName, @ThirdName, @LastName, @NationalNumber, @DateOfBirth,
                                        @Gender, @Phone, @Email, @NationalityCountryID, @Address, @ImagePath);
                             SELECT SCOPE_IDENTITY() AS PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Address", Address);

            if (string.IsNullOrEmpty(SecondName))
                Command.Parameters.AddWithValue("@SecondName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);


            if (string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    PersonID = Convert.ToInt32(result);
            }
            catch
            {
                PersonID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return PersonID;
        }

        public static bool DeletePerson(int PersonID)
        {
            bool isDeleted = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "DELETE FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                isDeleted = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return isDeleted;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber,
                                        DateTime DateOfBirth, bool Gender, string Phone, string Email, int NationalityCountryID, string Address, string ImagePath)
        {
            bool isEdited = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Update People 
                                Set FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, NationalNumber = @NationalNumber, 
                                DateOfBirth = @DateOfBirth, Gender = @Gender, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID, Address = @Address,
                                ImagePath = @ImagePath 
                            WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            if (string.IsNullOrEmpty(SecondName))
                Command.Parameters.AddWithValue("@SecondName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);


            if (string.IsNullOrEmpty(Email))
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);

            if (string.IsNullOrEmpty(ImagePath))
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);


            try
            {
                Connection.Open();
                isEdited = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return isEdited;

        }


        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNumber,
                                        ref DateTime DateOfBirth, ref bool Gender, ref string Phone, ref string Email, ref int NationalityCountryID, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    FirstName = Convert.ToString(Reader["FirstName"]);
                    SecondName = Convert.ToString(Reader["SecondName"]);
                    ThirdName = Convert.ToString(Reader["ThirdName"]);
                    LastName = Convert.ToString(Reader["LastName"]);
                    NationalNumber = Convert.ToString(Reader["NationalNumber"]);
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Convert.ToBoolean(Reader["Gender"]);
                    Phone = Convert.ToString(Reader["Phone"]);
                    Email = Convert.ToString(Reader["Email"]);
                    NationalityCountryID = Convert.ToInt16(Reader["NationalityCountryID"]);
                    Address = Convert.ToString(Reader["Address"]);
                    ImagePath = Convert.ToString(Reader["ImagePath"]);

                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetPersonInfoByNationalNumber(string NationalNumber, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
                                        ref DateTime DateOfBirth, ref bool Gender, ref string Phone, ref string Email, ref int NationalityCountryID, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE  NationalNumber = @NationalNumber";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    FirstName = Convert.ToString(Reader["FirstName"]);
                    SecondName = Convert.ToString(Reader["SecondName"]);
                    ThirdName = Convert.ToString(Reader["ThirdName"]);
                    LastName = Convert.ToString(Reader["LastName"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Convert.ToBoolean(Reader["Gender"]);
                    Phone = Convert.ToString(Reader["Phone"]);
                    Email = Convert.ToString(Reader["Email"]);
                    NationalityCountryID = Convert.ToInt16(Reader["NationalityCountryID"]);
                    Address = Convert.ToString(Reader["Address"]);
                    ImagePath = Convert.ToString(Reader["ImagePath"]);

                    isFound = true;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllPeopleInfo()
        {
            DataTable PeopleTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, NationalityCountryID as Nationality, Phone, Email FROM People";

            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                PeopleTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return PeopleTable;
        }

        public static bool isNationalNumberExist(string nationalNumber)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'Found'as Name FROM People WHERE NationalNumber = @NationalNumber";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNumber", nationalNumber);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                //Handle The Exceptoin
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static bool isPersonExists(int personID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'FOUND' FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isFound = true;
            }
            catch (Exception ex)
            {
                //Handle The Exception here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool isAUser(int personID)

        {
            bool Result = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'Result' FROM Users WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    Result = true;
            }
            catch (Exception ex)
            {
                //Catch Exceptions if occur
            }
            finally
            {
                Connection.Close();
            }
            return Result;
        }

        public static bool isNationalNumberExist(string nationalNumber, int personID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'Found'as Name FROM People WHERE NationalNumber = @NationalNumber AND PersonID != @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNumber", nationalNumber);
            Command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                //Handle The Exceptoin
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }


        public static bool HasLicense(int personID, int licenseClassID)
        {
            bool HasLicense = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'Yes' FROM 
                             People p
                             INNER JOIN Drivers d ON p.PersonID = d.PersonID
                             INNER JOIN Licenses l ON l.DriverID = d.DriverID
                             WHERE l.LicenseClassID = @LicenseClassID AND p.PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            Command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    HasLicense = true;
            }
            catch
            {
                //Handle Exceptions
            }
            finally
            {
                Connection.Close();
            }


            return HasLicense;
        }

        public static string GetFullNameBy(int personID)
        {
            string FullName = null;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT 
                            	 CASE 
                            	 WHEN ISNULL(SecondName, '') = '' AND ISNULL(ThirdName, '')= '' THEN CONCAT(FirstName, ' ', LastName)
                            	 WHEN ISNULL(SecondName, '') = '' THEN CONCAT(FirstName, ' ', ThirdName, ' ', LastName)
                            	 WHEN ISNULL(ThirdName, '') = '' THEN CONCAT(FirstName, ' ', SecondName, ' ', LastName)
                            	 ELSE CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName)
                            	 END
                             FROM People WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    FullName = Convert.ToString(result);
            }
            catch
            {
                //Handle
            }
            finally
            {
                Connection.Close( );
            }
            return FullName;

        }

        public static bool isDriver(int personID)
        {
            bool IsDriver = false;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = @"SELECT 'YES' FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    IsDriver = true;
            }
            catch
            {
                //Handle Exceptions or log them later
            }
            finally
            {
                Connection.Close();
            }
            return IsDriver;
        }

        public static DataTable GetLicensesHistory(int personID)
        {
            DataTable HistoryTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT L.LicenseID AS 'License ID', App.ApplicationID AS 'App. ID', LC.ClassName AS 'Class Name', L.IssueDate As 'Issue Date', L.ExpirationDate AS 'Expiration Date', L.IsActive AS 'Is Active'
                             FROM People P
                             INNER JOIN Applications App ON P.PersonID = App.ApplicantPersonID
                             INNER JOIN Licenses L ON L.ApplicationID = App.ApplicationID
                             INNER JOIN LicenseClasses LC ON LC.LicenseClassID = L.LicenseClassID
                             WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                Connection.Open();
                using(SqlDataReader reader = Command.ExecuteReader())
                {
                    HistoryTable.Load(reader);
                }
            }
            catch
            {
                //Catch any exceptions if occur
            }
            finally
            {
                Connection.Close();
            }
            return HistoryTable;
        }

        public static int GetPersonIDByDriverID(int driverID)
        {
            int PersonID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT PersonID From Drivers WHERE DriverID = @driverID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@driverID", driverID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    PersonID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle any exceptions if occurs
            }
            finally
            {
                Connection.Close();
            }
            return PersonID;
        }


        public static bool GetPersonInfoByDriverID(int driverID, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNumber,
                                        ref DateTime DateOfBirth, ref bool Gender, ref string Phone, ref string Email, ref int NationalityCountryID, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT p.* FROM People P
                             JOIN Drivers D ON P.PersonID = D.PersonID
                             WHERE DriverID = @driverID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@driverID", driverID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    FirstName = Convert.ToString(Reader["FirstName"]);
                    SecondName = Convert.ToString(Reader["SecondName"]);
                    ThirdName = Convert.ToString(Reader["ThirdName"]);
                    LastName = Convert.ToString(Reader["LastName"]);
                    NationalNumber = Convert.ToString(Reader["NationalNumber"]);
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Convert.ToBoolean(Reader["Gender"]);
                    Phone = Convert.ToString(Reader["Phone"]);
                    Email = Convert.ToString(Reader["Email"]);
                    NationalityCountryID = Convert.ToInt16(Reader["NationalityCountryID"]);
                    Address = Convert.ToString(Reader["Address"]);
                    ImagePath = Convert.ToString(Reader["ImagePath"]);

                    isFound = true;
                }

                Reader.Close();
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

        public static int GetPersonIDByApplicationID(int applicationID)
        {
            int personID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT ApplicantPersonID FROM Applications
                             WHERE ApplicationID = @applicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@applicationID", applicationID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    personID = Convert.ToInt32(result);
            }
            catch
            {
                //Handle any exceptions
            }
            finally
            {
                Connection.Close();
            }
            return personID;
        }

        public static int GetPeresonIDByNationalNumber(string nationalNumber)
        {
            int PersonID = -1;
            SqlConnection Connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = "SELECT PersonID FROM People WHERE NationalNumber = @nationalNumber";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@nationalNumber", nationalNumber);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                    PersonID = Convert.ToInt32(result);
            }
            catch
            {
                //Log exceptions and handle them from here
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }
    }
}
