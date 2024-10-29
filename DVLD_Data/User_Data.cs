using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Net;

namespace DVLD_Data
{
    public static class clsUser_DAL
    {
        public static int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            int UserID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Users(PersonID, UserName, Password, isActive) Values(@PersonID, @UserName, @Password, @isActive);
                                SELECT SCOPE_IDENTITY() AS UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    UserID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                //Handle Exception HERE
            }
            finally
            {
                Connection.Close();
            }
            return UserID;
        }

        public static bool DeleteUser(int UserID)
        {
            bool isDeleted = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "DELETE FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                isDeleted = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                //Handle exceptions, if occur, here
            }
            finally
            {
                Connection.Close();
            }

            return isDeleted;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool isActive)
        {
            bool isUpated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Users
                                SET PersonID = @PersonID, UserName = @UserName, Password = @Password, isActive = @isActive 
                                WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                Connection.Open();
                isUpated = Command.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {
                //Handle The Exception here
            }
            finally
            {
                Connection.Close();
            }

            return isUpated;
        }

        public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
               SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    UserName = Convert.ToString(reader["UserName"]);
                    Password = Convert.ToString(reader["Password"]);
                    isActive = Convert.ToBoolean(reader["isActive"]);
                } 
                reader.Close();
            }
            catch
            (Exception ex)
            {
                //Handle Later the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable UsersTable = new DataTable();
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT UserID as 'User ID' , Users.PersonID  as 'Person ID', 
                              (People.FirstName +' '+   People.LastName) as 'Full Name', UserName, isActive
                               FROM Users INNER JOIN PEOPLE ON Users.PersonID = People.PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                UsersTable.Load(Reader);
                Reader.Close();
            }
            catch (Exception ex)
            {
                //Handle the exception here
            }
            finally
            {
                Connection.Close();
            }

            return UsersTable;
        }

        public static bool isUserExists(int UserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'isFound' FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isFound = true;
            }
            catch (Exception ex) 
            { 
                //Handle the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool isUserExists(string UserName, string Password )
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'isFound' FROM Users WHERE UserName = @UserName AND Password = @Password";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isFound = true;
            }
            catch (Exception ex)
            {
                //Handle the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool isUserActive(int UserID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'yes' FROM Users WHERE UserID = @UserID AND isActive = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null)
                    Exist = true;
                
            }
            catch(Exception ex)
            {
                //Handle  the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return Exist;
        }

        public static bool isUserActive(string UserName)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'yes' FROM Users WHERE UserName = @UserName AND isActive = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();
                if (result != null)
                    Exist = true;

            }
            catch (Exception ex)
            {
                //Handle  the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return Exist;
        }

        public static bool isUserNameExists(string UserName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT 'isFound' FROM Users WHERE UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    isFound = true;
            }
            catch (Exception ex)
            {
                //Handle the Exception here
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            bool isUpdated = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@NewPassword", NewPassword);

            try
            {
                Connection.Open();
                isUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                //Handle The Exception here
            }
            finally
            {
                Connection.Close();
            }

            return isUpdated;
        }

       public static int GetUserIDByUserName(string UserName)
        {
            int UserID = -1;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT UserID FROM Users WHERE UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    return Convert.ToInt32(result);
            }
            catch(Exception ex)
            {
                //Handle any Exception if occurs
            }
            finally
            {
                Connection.Close();
            }
            return UserID;
        }

        public static string GetUserName(int UserID)
        {
            string UserName = null;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT UserName FROM Users WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                    UserName = Convert.ToString(result);
            }
            catch (Exception ex)
            {
                //Handle the excepton hre
            }
            finally
            {
                Connection.Close();
            }

            return UserName;
        }
    }
}

