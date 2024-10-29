
using System.Data;
using DVLD_Data;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        private int _ApplicationTypeID;
        public string ApplicationTypeTitle { get; set; }
        public double ApplicationFees { get; set; }
        public double ApplicationTypeID 
        {
            get { return _ApplicationTypeID; }
        }

        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, double ApplicationTypeFees)
        {
            this._ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationType_DAL.GetAllApplicationTypes();
        }

        public bool Save()
        {
            if (string.IsNullOrWhiteSpace(ApplicationTypeTitle)) return false;
            else
                return clsApplicationType_DAL.UpdateApplicationTypeInfo(this._ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            double ApplicationFees = 0;
            if (!clsApplicationType_DAL.GetApplicationInfo(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return null;
            else
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);

        }

        public static string GetTypeTitleBy(int TypeID)
        {
            return clsApplicationType_DAL.GetTypeTitleBy(TypeID);
        }

        public static double GetTypeFees(int applicationTypeID)
        {
            return clsApplicationType_DAL.GetTypeFees(applicationTypeID);
        }
    }


}
