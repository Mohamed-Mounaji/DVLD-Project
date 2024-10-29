using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        enum enMode { AddNew, Update}
        private enMode _Mode;
        public int TestID { get; private set; }
        public int TestAppointmentID {  get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            _Mode = enMode.AddNew;
            TestID = -1;
            TestAppointmentID = -1;
            TestID = 0;
            Notes = "";
            CreatedByUserID = -1;
        }

        public clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            _Mode = enMode.Update;
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
        }

        private bool _AddNew()
        {
            int testID = clsTest_DAL.AddNewRow(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            if (testID == -1)
                return false;
            else
                return true;
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
                default:
                    return false;
            }
        }

        public static bool isFailedOnTest(int localDrivingLicenseApplication, byte testTypeID)
        {
            return clsTest_DAL.isFailedOnTest(localDrivingLicenseApplication, testTypeID);
        }

        public static bool DeleteTestsBy(int testAppointment)
        {
            return clsTest_DAL.DeleteTestsBy(testAppointment);
        }


    }
}
