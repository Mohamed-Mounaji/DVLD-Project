using DVLD_Data;
using System.Data;
using System.Runtime.CompilerServices;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication
    {
        enum enMode { AddNew, Update}
        private enMode _Mode;
        
        public int LDLApplicationID { get; private set; }
        public clsApplication ApplicationInfo { get; set; } = new clsApplication();
        public int LicenseClassID {  get; set; }

        public byte PassedTests { get; private set; }

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            _Mode = enMode.Update;
            LDLApplicationID = localDrivingLicenseApplicationID;
            ApplicationInfo = clsApplication.Find(applicationID);
            LicenseClassID = licenseClassID;
            PassedTests = 0;
            if(isVisionTestPassed(localDrivingLicenseApplicationID))
                PassedTests++;
            if(isWrittenTestPassed(localDrivingLicenseApplicationID))
                PassedTests++;
            if(isStreetTestPassed(localDrivingLicenseApplicationID))
                PassedTests++;
        }

        public clsLocalDrivingLicenseApplication()
        {
            _Mode = enMode.AddNew;
            LDLApplicationID = -1;
            LicenseClassID = -1;
            ApplicationInfo = new clsApplication();
            PassedTests = 0;
        }

        private bool _Update()
        {
            return ApplicationInfo.Save();
        }

        private bool _AddNew()
        {
            if (!this.ApplicationInfo.Save())
                return false;

            int result = clsLocalDrivingLicenseApplication_DAL.AddNewLDLApplication(this.ApplicationInfo.ApplicationID, this.LicenseClassID);
            if(result != -1)
            {
                this.LDLApplicationID = result;
                return true;
            }
            else
                return false;
        }

        public bool Save()
        {
            if (_Mode == enMode.Update)
            {
                return _Update();
            }
            else
            {
                if (_AddNew())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }

           
            
        }

        public static int IsApplicationsExists(int ApplicantID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplication_DAL.IsApplicationExists(ApplicantID, LicenseClassID);
        }

        public static DataTable GetAllApplications()
        {
            return clsLocalDrivingLicenseApplication_DAL.GetApplicationsTable();
        }

        public static bool isVisionTestPassed(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplication_DAL.isTestPassed(LocalDrivingLicenseApplicationID, 1);
        }

        public static bool isWrittenTestPassed(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplication_DAL.isTestPassed(LocalDrivingLicenseApplicationID, 2);
        }

        public static bool isStreetTestPassed(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplication_DAL.isTestPassed(LocalDrivingLicenseApplicationID, 3);
        }

        public static bool isTestPassed(int localDrivingLicenseApplicationID, byte testTypeID)
        {
            return clsLocalDrivingLicenseApplication_DAL.isTestPassed(localDrivingLicenseApplicationID, testTypeID);
        }

        public static clsLocalDrivingLicenseApplication Find(int localDrivingLicenseApplicationID)
        {
            int applicationID = 0, licenseClassID = 0;
            if (clsLocalDrivingLicenseApplication_DAL.GetLDLApplicationInfo(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID, licenseClassID);
            else
                return null;

            
        }

        public bool Delete()
        {
            if (clsLocalDrivingLicenseApplication_DAL.DeleteBy(this.LDLApplicationID) && this.ApplicationInfo.Delete())
            {
                _Mode = enMode.AddNew;
                LDLApplicationID = -1;
                LicenseClassID = -1;
                ApplicationInfo = new clsApplication();
                PassedTests = 0;
                return true;
            }
            else
                return false;
        }

        public static bool DeleteBy(int localDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo = Find(localDrivingLicenseApplicationID);

            return LocalDrivingLicenseApplicationInfo.Delete();
        }

    }
}
