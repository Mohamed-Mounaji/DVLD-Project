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

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmIssueDrivingLicense : Form
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        public frmIssueDrivingLicense(int localDrivingLicenseApplication)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.Find(localDrivingLicenseApplication);
            ucLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseAppInfoBy(localDrivingLicenseApplication);
        }

        private int _AddNewDriver(int personID)
        {
            clsDriver NewDriver = new clsDriver();
            NewDriver.PersonID = personID;
            NewDriver.CreatedByUserID = clsGlobal.CurrUserID;
            NewDriver.CreatedDate = DateTime.Now;

            if (NewDriver.Save())
                return NewDriver.DriverID;
            else
                return -1;
        }

        private bool _AddNewLicense(int DriverID)
        {
            clsLicense NewLicense = new clsLicense();
            int ValidityLength = clsLicenseClass.GetClassValidityLength(_LocalDrivingLicenseApplicationInfo.LicenseClassID);

            NewLicense.ApplicationID = _LocalDrivingLicenseApplicationInfo.ApplicationInfo.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClassID = _LocalDrivingLicenseApplicationInfo.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(ValidityLength);
            NewLicense.Notes = txbNotes.Text;
            NewLicense.PaidFees = -1;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = (byte)enIssueReason.FirstTime;
            NewLicense.CreatedByUserID = clsGlobal.CurrUserID;

            return NewLicense.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int DriverID = -1;
            if (clsPerson.isDriver(_LocalDrivingLicenseApplicationInfo.ApplicationInfo.ApplicantPersonID))
            {
                DriverID = clsDriver.GetDriverIDby(_LocalDrivingLicenseApplicationInfo.ApplicationInfo.ApplicantPersonID);
            }
            else
            {
                DriverID = _AddNewDriver(_LocalDrivingLicenseApplicationInfo.ApplicationInfo.ApplicantPersonID);
            }

            if(_AddNewLicense(DriverID))
            {
                _LocalDrivingLicenseApplicationInfo.ApplicationInfo.ApplicationStatus = (byte)enApplicationStatus.Completed;
                _LocalDrivingLicenseApplicationInfo.ApplicationInfo.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplicationInfo.Save();
                MessageBox.Show("License Issued Successfully :)");
                this.Close();
            }
            else
                MessageBox.Show("License Was not  Issued :( ");

        }
    }
}
