using DVLD_Data;
using System;

namespace DVLD_Business
{
    public class clsLicense
    {
        enum enMode { AddNew , Update}
        private enMode _Mode;
        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public double PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicense()
        {
            this._Mode = enMode.AddNew;
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.CreatedByUserID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = 99;
        }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, double paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            _Mode = enMode.Update;
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClassID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;
        }

        private bool  _AddNew()
        {
            int result = clsLicense_DAL.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            if(result != -1)
            {
                this.LicenseID = result;
                return true;
            }
            return false;
        }

        private bool _Update()
        {
            return clsLicense_DAL.UpdateLicenseInfo(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
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
                    if (_Update())
                        return true;
                    break;
            }
            return false;
        }

        public static int GetActiveLicenseIDBy(int PersonID, int LicenseClassID)
        {
            return clsLicense_DAL.GetLicenseIDBy(PersonID, LicenseClassID, 1);
        }

        public static clsLicense Find(int licenseID)
        {
            int appliationID = -1, driverID = -1, licenseClassID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            double paidFees = 0;
            bool isActive = false;
            byte issueReason = 99;

            bool isFound = clsLicense_DAL.GetLicenseInfo(licenseID, ref appliationID, ref driverID, ref licenseClassID, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID);
            if (isFound)
                return new clsLicense(licenseID, appliationID, driverID, licenseClassID, issueDate, expirationDate, notes, paidFees, isActive, issueReason, createdByUserID);
            else
                return null;
        }

        private static int _GetLicenseIDBy(int ApplicationID)
        {
            return clsLicense_DAL.GetLicenseIDBy(ApplicationID);
        }

        public static int GetLicenseIDBy(int LocalDrivingLicenseApplications)
        {
            clsLocalDrivingLicenseApplication Info = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplications);
            if (Info != null)
                return _GetLicenseIDBy(Info.ApplicationInfo.ApplicationID);
            else
                return -1;
        }
        
        public bool isExpired()
        {
            return clsLicense_DAL.isLicenseExpired(this.LicenseID);
        }
        public static bool isLicenseExists(int LicenseID)
        {
            return clsLicense_DAL.isLicenseExists(LicenseID);
        }
        public static bool isLicenseExpired(int licensID)
        {
            return clsLicense_DAL.isLicenseExpired(licensID);
        }
    }
}
