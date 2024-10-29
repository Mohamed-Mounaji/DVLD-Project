
using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID {  get; set; }
        public int IssuedUsingLocalDrivingLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            _Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            _Mode = enMode.Update;
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalDrivingLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
        }

        private bool _AddNew()
        {
            int ID = clsInternationalLicense_DAL.AddNewLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalDrivingLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            if (ID != -1)
            {
                this.InternationalLicenseID = ID;
                return true;
            }
            else
                return false;
        }
        
        private bool _Update()
        {
            return clsInternationalLicense_DAL.UpdateLicense(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalDrivingLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    if (_Update())
                        return true;
                    else
                        return
                            false;
            }
            return false;
        }

        public static int GetActiveLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicense_DAL.GetActiveLicenseIDByDriverID(DriverID);
        }
        
        public static DataTable GetAllLicensesTable()
        {
            return clsInternationalLicense_DAL.GetAllLicenses();
        }

        public static clsInternationalLicense Find(int internationalLicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;

            if (clsInternationalLicense_DAL.GetLicenseInfo(internationalLicenseID, ref applicationID, ref driverID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive, createdByUserID);
            else
                return null;
        }

        public static DataTable GetLicensesByPersonID(int presonID)
        {
            return clsInternationalLicense_DAL.GetLicensesTableByPersonID(presonID);
        }

    }
}
