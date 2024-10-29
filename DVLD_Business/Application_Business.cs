using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {
        enum enMode { AddNew, Update}

        public int ApplicationID { get; private set; }
        public int ApplicantPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public byte ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public double PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        private enMode _Mode;

        public clsApplication(int applicationID,int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, double paidFees, int createdByUserID) 
        {
            _Mode = enMode.Update;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
        }
        public clsApplication()
        {
            _Mode = enMode.AddNew;
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 99;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
        }

        private bool _Update()
        {
            return clsApplication_DAL.UpdateApplicationInfo(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        private bool _AddNew()
        {
            this.ApplicationID = clsApplication_DAL.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            if (ApplicationID != -1)
                return true;
            else
                return false;

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

        public static clsApplication Find(int applicationID)
        {
            int applicantPersonID = 0, applicationTypeID = 0, createdByUserID = 0;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            byte applicationStatus = 0;
            double paidFees = 0f;

            if (clsApplication_DAL.GetApplicationInfoByID(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplication(applicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);
            else
                return null;
        }

        public bool Delete()
        {
            if (clsApplication_DAL.DeleteApplication(this.ApplicationID))
            {
                _Mode = enMode.AddNew;
                this.ApplicationID = -1;
                this.ApplicantPersonID = -1;
                this.ApplicationDate = DateTime.Now;
                this.ApplicationTypeID = -1;
                this.ApplicationStatus = 99;
                this.LastStatusDate = DateTime.Now;
                this.PaidFees = -1;
                this.CreatedByUserID = -1;
                return true;
            }
            else
                return false;
        }

        public static bool DeleteBy(int ApplicationID)
        {
            return clsApplication_DAL.DeleteApplication(ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplication_DAL.CancelApplication(this.ApplicationID);
        }

        public static bool Cancel(int ApplicationID)
        {
            return clsApplication_DAL.CancelApplication(ApplicationID);
        }
    }
}
