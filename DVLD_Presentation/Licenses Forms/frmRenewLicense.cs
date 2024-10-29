using DVLD_Business;
using DVLD_Presentation.Applications_Forms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses_Forms
{
    public partial class frmRenewLicense : Form
    {
        clsLicense ExpiredLicenseInfo = null;
        clsApplication NewApplication = null;
        clsLicense NewLicense = null;
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void _SetDefaultValuesOfApplicationInfoFields()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.GetTypeFees((int)enApplicationTypes.RenewLocalLicense).ToString();
            lblCreatedByUser.Text = clsUser.GetUserName(clsGlobal.CurrUserID);
        }
        private void _SetFieldsAfterExpiredLicenseIsFound()
        {
            lblLicenseFees.Text = clsLicenseClass.GetClassFees(ExpiredLicenseInfo.LicenseClassID).ToString();
            lblTotalFees.Text = (Convert.ToDouble(lblApplicationFees.Text) + Convert.ToDouble(lblLicenseFees.Text)).ToString();
            lblExpiredLicenseID.Text = ExpiredLicenseInfo.LicenseID.ToString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClass.GetClassValidityLength(ExpiredLicenseInfo.LicenseClassID)).ToShortDateString();
        }

        private void ucFilterLicense1_OnPersonFound(clsLicense LicenseInfo)
        {
            if(!LicenseInfo.isExpired())
            {
                clsGlobal.ErrorMessageBox($"Selected License is not expired.\nIts expiration date is '{LicenseInfo.ExpirationDate.ToShortDateString()}'.");
            }
            else if(!LicenseInfo.IsActive)
            {
                clsGlobal.ErrorMessageBox("Ooops!!You can't renew inactive License :(");
            }
            else
            {
                btnIssue.Enabled = true;
                gbApplicationInformation.Enabled = true;
                ExpiredLicenseInfo = LicenseInfo;
                _SetFieldsAfterExpiredLicenseIsFound();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            _SetDefaultValuesOfApplicationInfoFields();
        }

        private bool _SaveTheApplicationInfo()
        {
            NewApplication = new clsApplication();
            NewApplication.ApplicantPersonID = clsPerson.GetPersonIDByApplicationID(ExpiredLicenseInfo.ApplicationID);
            NewApplication.ApplicationDate = DateTime.Now;
            NewApplication.ApplicationStatus = (byte)enApplicationStatus.New;
            NewApplication.ApplicationTypeID = (byte)enApplicationTypes.RenewLocalLicense;
            NewApplication.LastStatusDate = DateTime.Now;
            NewApplication.PaidFees = clsApplicationType.GetTypeFees((int)enApplicationTypes.RenewLocalLicense);
            NewApplication.CreatedByUserID = clsGlobal.CurrUserID;
            if (NewApplication.Save()) return true;
            else return false;
        }

        private void _IssueTheNewLicense()
        {
            NewLicense = new clsLicense();
            NewLicense.ApplicationID = NewApplication.ApplicationID;
            NewLicense.DriverID = ExpiredLicenseInfo.DriverID;
            NewLicense.LicenseClassID = ExpiredLicenseInfo.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears( clsLicenseClass.GetClassValidityLength(NewLicense.LicenseClassID));
            NewLicense.Notes = txbNotes.Text;
            NewLicense.PaidFees = Convert.ToDouble(lblTotalFees.Text);
            NewLicense.IsActive = true;
            NewLicense.IssueReason = (byte)enIssueReason.Renew;
            NewLicense.CreatedByUserID = clsGlobal.CurrUserID;
            if(NewLicense.Save())
            {
                lblApplicationID.Text = NewLicense.ApplicationID.ToString();
                lblNewLicenseID.Text = NewLicense.LicenseID.ToString();
                linkShowNewLicenseInfo.Enabled = true;
                btnIssue.Enabled = false;
                MessageBox.Show("License is issued successfully!");
                NewApplication.ApplicationStatus = (byte)enApplicationStatus.Completed;
                NewApplication.Save();
            }
            else
            {
                clsGlobal.ErrorMessageBox("Operation Failed.\nError Occured while saving the license info");
            }

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save?", "insuring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (ExpiredLicenseInfo == null) return;
            ExpiredLicenseInfo.IsActive = false;

            if (_SaveTheApplicationInfo())
            {
                _IssueTheNewLicense();
            }
            else
                clsGlobal.ErrorMessageBox("Operation Failed.\nAn error occured while saving the application info.");
            
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ExpiredLicenseInfo == null) return;
            int PersonID = clsPerson.GetPersonIDByDriverID(ExpiredLicenseInfo.DriverID);
            Form frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void linkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewLicense == null) return;
            Form frm = new frmLicenseInfo(NewLicense.LicenseID);
            frm.ShowDialog();
        }
    }
}
