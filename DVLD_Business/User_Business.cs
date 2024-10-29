using DVLD_Data;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Web;

namespace DVLD_Business
{
    public class clsUser
    { 
        private enum enMode { AddNew, Update}
        private enMode _Mode;
        private int _UserID;

        public int PersonID { get; set; }
        public string UserName { get; set;}
        public string Password { get; set;}
        public bool isActive { get;  set; }

        public int UserID
        {
            get { return _UserID; }
        }

        public clsUser()
        {
           _Mode = enMode.AddNew;
            _UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            isActive = false;
        }

        public clsUser(int UserID, int PersonID,  string UserName, string Password, bool isActive)
        {
            _Mode = enMode.Update;
            this._UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;            
        }

        private bool _AddNew()
        {
            if (!clsPerson.isPersonExists(this.PersonID)) return false;
            if(string.IsNullOrEmpty(this.UserName)) return false;
            if(string.IsNullOrEmpty(this.Password)) return false;
            
            this._UserID = clsUser_DAL.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);
            if(_UserID != -1)
            {
                _Mode = enMode.Update;
                return true;
            }
            return false;
        }

        private bool _Update()
        {
            if (!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password) && clsPerson.isPersonExists(this.PersonID))
                return clsUser_DAL.UpdateUser(this._UserID, this.PersonID, this.UserName, this.Password, this.isActive);
            else
                return false;
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    return _AddNew();

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static DataTable GetAllUsersTable()
        {
            return clsUser_DAL.GetAllUsers();
        }

        public static bool isUserNameExists(string userName)
        {
            return clsUser_DAL.isUserNameExists(userName);
        }

        public static bool isUserExists(int UserID)
        {
            return clsUser_DAL.isUserExists(UserID);
        }

        public static bool isUserActive(int UserID)
        {
            return clsUser_DAL.isUserActive(UserID);
        }

        public static bool isUserExists(string UserName, string Password)
        {
            return clsUser_DAL.isUserExists(UserName, Password);
        }

        public static clsUser Find(int UserID)
        {
            string UserName = "", Password ="";
            int PersonID = -1;
            bool isActive = false;

            if (clsUser_DAL.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password, ref isActive))
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            else
                return null;

        }

        public static bool DeleteUser(int UserID)
        {
            return clsUser_DAL.DeleteUser(UserID);
        }

        public static bool UpdatePassword(int UserID, string CurrentPassword, string NewPassword)
        {
            clsUser UserInfo = Find(UserID);
            if (UserInfo == null)
                return false;

            if (UserInfo.Password != CurrentPassword)
                return false;

            clsUser_DAL.ChangePassword(UserID, NewPassword);
            return true;
        }

        public static bool isUserActive(string UserName)
        {
            return clsUser_DAL.isUserActive(UserName);
        }

        public static int GetUserID(string UserName)
        {
            return clsUser_DAL.GetUserIDByUserName(UserName);
        }

        public static string GetUserName(int UserID)
        {
            return clsUser_DAL.GetUserName(UserID);
        }
    }

}
