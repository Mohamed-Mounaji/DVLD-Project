using DVLD_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class clsLicenseClass
    {
        public static DataTable GetAllClassesNames()
        {
            return clsLicenseClass_DAL.GetAllClassesNames();
        }

        public static string GetClassNameBy(int LicenseClassID)
        {
            return clsLicenseClass_DAL.GetClassNameBy(LicenseClassID);
        }

        public static int GetClassValidityLength(int LicenseClassID)
        {
            return clsLicenseClass_DAL.GetValidityLength(LicenseClassID);
        }

        public static double GetClassFees(int LicenseClassID)
        {
            return clsLicenseClass_DAL.GetClassFees(LicenseClassID);
        }
    }
}
