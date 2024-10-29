using DVLD_Data;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsDriver
    {
        enum enMode { AddNew, Update}
        private enMode _Mode;
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            _Mode = enMode.AddNew;

            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }
        public clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            _Mode = enMode.Update;
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        private bool _AddNew()
        {
            int result = clsDriver_DAL.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            if (result != -1)
            {
                this.DriverID = result;
                return true;
            }
            else
                return false;

        }

        private bool _Update()
        {
            return false;
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;

                case enMode.Update:
                    if(_Update())
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public static int GetDriverIDby(int PersonID)
        {
            return clsDriver_DAL.GetDriverID(PersonID);
        }

        public static clsDriver Find(int driverID)
        {
            int personID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;
            bool isFound = clsDriver_DAL.GetDriverInfo(driverID, ref personID, ref createdByUserID, ref createdDate);
            if (isFound)
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            else
                return null;
        }

        public static DataTable GetDriversList()
        {
            return clsDriver_DAL.GetAllDriversTable();
        }
    }
}
