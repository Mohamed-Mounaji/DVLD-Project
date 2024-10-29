using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.User_Controls
{
    public partial class ucLocalDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication LDLApplicationInfo;
        public ucLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillFieldFromObject()
        {
            lblLDLApplicationID.Text = LDLApplicationInfo.LDLApplicationID.ToString();
            lblLicenseClass.Text = clsLicenseClass.GetClassNameBy(LDLApplicationInfo.LicenseClassID);
            lblPassedTests.Text = $"{LDLApplicationInfo.PassedTests}/3";
            
        }

        public bool LoadLocalDrivingLicenseAppInfoBy(int LocalDrivingLicenseApplicationID)
        {
            LDLApplicationInfo = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
            if (LDLApplicationInfo == null)
                return false;

            if (!ucApplicationBasicInfo1.LoadApplicationInfo(LDLApplicationInfo.ApplicationInfo.ApplicationID))
                return false;
            _FillFieldFromObject();
            return true;


        }

      
    }
}
