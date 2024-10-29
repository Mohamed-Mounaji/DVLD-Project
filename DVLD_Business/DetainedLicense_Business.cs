using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        private enum enMode { AddNew, Update}
        enMode _Mode;
        public int DetainID { get; private set; }

        public int LicenseID { get; set; }

        public DateTime DetainDate { get; set; }

        public double FineFees { get; set; }

        public int CreatedByUserID {  get; set; }

        public bool IsReleased { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int ReleasedByUserID { get; set; }

        public int ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            _Mode = enMode.AddNew;
        }

        public clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, double fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releaseByUserID, int releaseApplicationID)
        {
            _Mode = enMode.Update;
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releaseByUserID;
            this.ReleaseApplicationID = releaseApplicationID;
        }

        private bool _AddNew()
        {
            int Result = clsDetainedLicense_DAL.AddNewDetain(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
            if(Result != -1)
            {
                this.DetainID = Result;
                return true;
            }
            else
                return false;

        }

        private bool _Update()
        {
            throw new NotImplementedException();
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
                        return false;
            }
            return false;
        }

        public static bool isDetained(int licenseID)
        {
            return clsDetainedLicense_DAL.isLicenseDetained(licenseID);
        }

        public static clsDetainedLicense FindNoneReleasedDetainByLicenseID(int licenseID)
        {
            int detainID = -1, createdByUserID = -1, releasedByUserID = -1, releaseApplicationID = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            double fineFees = -1;
            bool isReleased = false;

            if (clsDetainedLicense_DAL.GetNoneReleasedDetainInfoByLicenseID(licenseID, ref detainID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new clsDetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            else
                return null;
        }

        public bool Release()
        {
            return clsDetainedLicense_DAL.ReleaseDetainedLicense(this.DetainID, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicense_DAL.GetAllDetainedLicenses();
        }
    }
}
