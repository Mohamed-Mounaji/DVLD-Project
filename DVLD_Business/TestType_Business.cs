using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        private int _TestTypeID;
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public double TestTypeFees { get; set; }
        public double TestTypeID
        {
            get { return _TestTypeID; }
        }

        public clsTestType()
        {
            
        }

        public clsTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, double TestTypeFees)
        {
            this._TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle; 
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestType_DAL.GetAllTestTypes();
        }

        public bool Save()
        {
            if (clsTestType_DAL.UpdateTestTypeInfo(this._TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees))
                return true;
            else
                return false;

        }

        public static clsTestType Find(int TestTypeID)
        {
            string testTypeTitle = "", testTypeDescription = "";
            double testTypeFees = 0;
            if (clsTestType_DAL.GetTestTypeInfo(TestTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFees))
                return new clsTestType(TestTypeID, testTypeTitle, testTypeDescription, testTypeFees);
            else
                return null;
        }

        public static double GetTestTypeFeesBy(int TestTypeID)
        {
            return clsTestType_DAL.GetTestTypeFeesBy(TestTypeID);
        }
    }
}
