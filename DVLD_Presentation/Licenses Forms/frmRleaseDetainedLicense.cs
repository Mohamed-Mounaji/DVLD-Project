using DVLD_Business;
using DVLD_Presentation.Applications_Forms;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses_Forms
{
    public partial class frmReleaseDetainedLicense : Form
    {
        clsDetainedLicense DetainInfo = null;
        int ApplicationID = -1;
        private int driverID = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int licenseID)
        {
            InitializeComponent();
            ucFilterLicense1.Find(licenseID);
            ucFilterLicense1.txbLicenseID.Text = licenseID.ToString();
            ucFilterLicense1.gbFilter.Enabled = false;
        }

        private void _SetDetainFieldsValues()
        {
            if (DetainInfo == null) return;

            double ApplicationFees = clsApplicationType.GetTypeFees((byte)enApplicationTypes.ReleaseDetainedLicense);

            lblDetainID.Text = DetainInfo.DetainID.ToString();
            lblDetainDate.Text = DetainInfo.DetainDate.ToShortDateString();
            lblLicenseID.Text = DetainInfo.LicenseID.ToString();
            lblCreatedBy.Text = clsUser.GetUserName(DetainInfo.CreatedByUserID);
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblFineFees.Text = DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (DetainInfo.FineFees + ApplicationFees).ToString();
        }

        private void ucFilterLicense1_OnLicenseFound(clsLicense LicenseInfo)
        {
            DetainInfo = clsDetainedLicense.FindNoneReleasedDetainByLicenseID(LicenseInfo.LicenseID);
            driverID = LicenseInfo.DriverID;
            linkShowLicenseInfo.Enabled = true;
            if (!clsDetainedLicense.isDetained(LicenseInfo.LicenseID))
            {
                clsGlobal.ErrorMessageBox("Selected license is not detained!?");
            }
            else
            {
                btnRelease.Enabled = true;
                _SetDetainFieldsValues();
            }
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DetainInfo == null) return;
            Form frm = new frmLicenseInfo(DetainInfo.LicenseID);
            frm.ShowDialog();
        }
        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DetainInfo == null) return;
            int PersonID = clsPerson.GetPersonIDByDriverID(driverID);
            Form frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _AddNewApplication()
        {
            clsApplication newApplication = new clsApplication();
            newApplication.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(driverID);
            newApplication.ApplicationDate = DateTime.Now;
            newApplication.ApplicationTypeID = (byte)enApplicationTypes.ReleaseDetainedLicense;
            newApplication.ApplicationStatus = (byte)enApplicationStatus.Completed;
            newApplication.LastStatusDate = DateTime.Now;
            newApplication.PaidFees = clsApplicationType.GetTypeFees(newApplication.ApplicationTypeID);
            newApplication.CreatedByUserID = clsGlobal.CurrUserID;
            if (newApplication.Save())
            {
                ApplicationID = newApplication.ApplicationID;
                return true;
            }
            else
                return false;
        }

        private bool _ReleaseTheDetain()
        {
            DetainInfo.IsReleased = true;
            DetainInfo.ReleaseDate = DateTime.Now;
            DetainInfo.ReleasedByUserID = clsGlobal.CurrUserID;
            DetainInfo.ReleaseApplicationID = ApplicationID;
            return DetainInfo.Release();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to release this license?", "Insuring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (!clsDetainedLicense.isDetained(DetainInfo.LicenseID))
            {
                clsGlobal.ErrorMessageBox("This license is already released.");
            }
            else
            {
                if (!_AddNewApplication())
                    clsGlobal.ErrorMessageBox("Operation Failed.\nCan not add new application.");
                else
                {
                    if (_ReleaseTheDetain())
                    {
                        lblApplicationID.Text = ApplicationID.ToString();
                        MessageBox.Show("The License is released successfully.", "Operation Succeeded");
                    }
                    else
                        clsGlobal.ErrorMessageBox("Operation Failed while releasing the license.");
                }

            }
        }
    }
}
