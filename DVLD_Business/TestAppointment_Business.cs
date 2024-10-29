using System;
using DVLD_Data;
using System.Data;
using System.Net.Http.Headers;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew, Update}
        private enMode _Mode;

        public int TestAppointmentID { get; private set; }
        public byte TestTypeID { get; set;}
        public int LocalDrivingLicenseApplicationID { get; set;}
        public DateTime AppointmentDate { get; set;}
        public double PaidFees { get; set;}
        public int CreatedByUserID { get; set;}
        public bool IsLocked { get; set;}

        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            this.TestAppointmentID = -1;
            this.TestTypeID = 99;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = true;
        }

        public clsTestAppointment(int testAppointmentID, byte testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, double paidFees, int createdByUserID, bool isLocked)
        {
            _Mode = enMode.Update;
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
        }

        private bool _Update()
        {
            return clsTestAppointment_DAL.UpdateTestAppointmentInfo(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }

        private bool _AddNew()
        {
            int result = clsTestAppointment_DAL.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
            if (result != -1)
            {
                this.TestAppointmentID = result;
                return true;
            }
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
                default:
                    return false;
            }
        }

        public static clsTestAppointment Find(int testAppointmentID)
        {
            int localDrivingLicenseApplicationID = -1, createdByUserID = -1;
            byte testTypeID = 99;
            DateTime appointmentDate = DateTime.Now;
            double paidFees = 0;
            bool isLocked = false;
            if (clsTestAppointment_DAL.GetTestAppointmentInfo(testAppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
            {
                return new clsTestAppointment(testAppointmentID, testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked);
            }
            else
                return null;
        }

        public static DataTable GetAppointmentsTableBasedOn(byte testTypeID, int localDrivingLicenseApplicationID)
        { 
            return clsTestAppointment_DAL.GetAppointmentsTableBasedOn(testTypeID, localDrivingLicenseApplicationID);
        }

        public static bool HasActiveAppointment(byte TestTypeID,  int localDrivingLicenseApplicationID)
        {
            return clsTestAppointment_DAL.HasActiveAppointment(TestTypeID, localDrivingLicenseApplicationID);

        }

        public bool Delete()
        {
            clsTest.DeleteTestsBy(this.TestAppointmentID);

            if( clsTestAppointment_DAL.DeleteAppointment(this.TestAppointmentID))
            {
                _Mode = enMode.AddNew;
                this.TestAppointmentID = -1;
                this.TestTypeID = 99;
                this.LocalDrivingLicenseApplicationID = -1;
                this.AppointmentDate = DateTime.Now;
                this.PaidFees = -1;
                this.CreatedByUserID = -1;
                this.IsLocked = true;
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool DeleteAppointmentBy(int testAppointmentID)
        {
            clsTestAppointment appointmentInfo = Find(testAppointmentID);

            return appointmentInfo.Delete();
        }

        public static void DeleteAppointmetsRelatedTo(int LocalDrivingLicenseApplicationID)
        {
            List<int> AppointmentsIDs  = clsTestAppointment_DAL.GetAppointmentsIDsBy(LocalDrivingLicenseApplicationID);
            foreach (var ID in AppointmentsIDs)
            {
                DeleteAppointmentBy(ID);
            }
        }
    }
}
