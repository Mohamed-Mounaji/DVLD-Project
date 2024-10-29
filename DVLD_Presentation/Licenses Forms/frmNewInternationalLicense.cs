using System;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmNewInternationalLicense : Form
    {
        int PersonID = -1;
        int FoundLocalLicenseID = -1;
        int FoundLocalLicenseClassID = -1;
        bool isFoundLocalLicenseActive= false;
        int DriverID = -1;
        double PaidFees = -1;
        DateTime ApplicationDate;
        clsInternationalLicense InternationalLicenseInfo = null;
        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ucFilterLicense1_OnPersonFound_1(clsLicense LicenseInfo)
        {
            btnIssue.Enabled = true;
            FoundLocalLicenseID = LicenseInfo.LicenseID;
            FoundLocalLicenseClassID = LicenseInfo.LicenseClassID;
            isFoundLocalLicenseActive = LicenseInfo.IsActive;
            DriverID = LicenseInfo.DriverID;
        }


        //This method will add a new internation license Application using the the personID of the driver that is applying and returnS the applicationID if save otherwise returns -1
        private int _AddNewInternationLicenseApplication()
        {
            
            clsApplication NewApplication = new clsApplication();
            NewApplication.ApplicantPersonID = PersonID = clsPerson.GetPersonIDByDriverID(DriverID);
            NewApplication.ApplicationDate = ApplicationDate= DateTime.Now;
            NewApplication.ApplicationTypeID = 6;
            NewApplication.ApplicationStatus = 3;
            NewApplication.LastStatusDate = DateTime.Now;
            NewApplication.PaidFees = PaidFees = clsApplicationType.GetTypeFees(6);
            NewApplication.CreatedByUserID = clsGlobal.CurrUserID;
            if (NewApplication.Save())
                return NewApplication.ApplicationID;
            else
                return -1;
        }

        private bool _AddNewInternationalLicense() 
        {
            int ApplicationID = _AddNewInternationLicenseApplication();

            if(ApplicationID == -1)
            {
                clsGlobal.ErrorMessageBox("Operation Failed!\nCan't save the application info");
                return false;
            }

            InternationalLicenseInfo = new clsInternationalLicense();
            InternationalLicenseInfo.ApplicationID = ApplicationID;
            InternationalLicenseInfo.DriverID = DriverID;
            InternationalLicenseInfo.IssuedUsingLocalDrivingLicenseID = FoundLocalLicenseID;
            InternationalLicenseInfo.IssueDate = DateTime.Now;
            InternationalLicenseInfo.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetClassValidityLength(6));
            InternationalLicenseInfo.IsActive = true;
            InternationalLicenseInfo.CreatedByUserID = clsGlobal.CurrUserID;

            if (InternationalLicenseInfo.Save())
            {
                MessageBox.Show($"License is issued successfuly with ID '{InternationalLicenseInfo.InternationalLicenseID}'");
                linkShowLicenseInfo.Enabled = true;
                return true;
            }
            else
            {
                clsGlobal.ErrorMessageBox("Failed to save the license!!");
                return false;
            }

        }

        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = InternationalLicenseInfo.ApplicationID.ToString();
            lblApplicationDate.Text = ApplicationDate.ToShortDateString();
            lblIssueDate.Text = InternationalLicenseInfo.IssueDate.ToShortDateString();
            lblFees.Text = PaidFees.ToString();
            lblInternationalLicenseID.Text = InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = FoundLocalLicenseID.ToString();
            lblExpirationDate.Text = InternationalLicenseInfo.ExpirationDate.ToShortDateString();
            lblCreatedByUser.Text = clsUser.GetUserName(clsGlobal.CurrUserID);
        }

        private void btnIssue_Click(object sender, System.EventArgs e)
        {
            if(FoundLocalLicenseID == -1)
            {
                clsGlobal.ErrorMessageBox("Please select a local driving license !!");
                return;
            }

            if(FoundLocalLicenseClassID != 3)
            {
                clsGlobal.ErrorMessageBox("Operation Failed!\nPlease, Use a local license of class 3.");
                return;
            }

            if(!isFoundLocalLicenseActive)
            {
                clsGlobal.ErrorMessageBox("Operation Failed!!\nYou can't use a none-active license");
                return;
            }
              
            int result = clsInternationalLicense.GetActiveLicenseIDByDriverID(DriverID);
            if (result != -1) 
            {
                clsGlobal.ErrorMessageBox("Operation Failed!!\nThis driver already has an active international license");
                return;
            }


            if (_AddNewInternationalLicense())
                _FillApplicationInfo();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (InternationalLicenseInfo == null) return;
            Form frm = new frmShowInternationalLicenseInfo(InternationalLicenseInfo.InternationalLicenseID);
            frm.ShowDialog();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PersonID == -1) return;
            Form frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
