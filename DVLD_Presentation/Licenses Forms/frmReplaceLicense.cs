using DVLD_Business;
using DVLD_Presentation.Applications_Forms;
using System;
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
    public partial class frmReplaceLicense : Form
    {
        private clsLicense oldLicenseInfo;
        private clsLicense newLicenseInfo;
        int applicationID;

        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetInitialValues()
        {
            lblCreatedBy.Text = clsUser.GetUserName(clsGlobal.CurrUserID);
            lblApplicationFees.Text = clsApplicationType.GetTypeFees((int)enApplicationTypes.ReplacementForDamagedLicense).ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
        }

        private void ucFilterLicense_OnPersonFound(DVLD_Business.clsLicense LicenseInfo)
        {
            if(!LicenseInfo.IsActive)
            {
                clsGlobal.ErrorMessageBox("Selected License is not active. Pleaes, choose an active lincense.");
            }
            else
            {
                gbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                lblOldLicenseID.Text = LicenseInfo.LicenseID.ToString();
                oldLicenseInfo = LicenseInfo;
            }
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDamagedLicense.Checked)
                lblApplicationFees.Text = clsApplicationType.GetTypeFees((int)enApplicationTypes.ReplacementForDamagedLicense).ToString();
            else if(rbLostLicense.Checked)
                lblApplicationFees.Text = clsApplicationType.GetTypeFees((int)enApplicationTypes.ReplacementForLostLicense).ToString();
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            _SetInitialValues();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (oldLicenseInfo == null) return;
            int PersonID = clsPerson.GetPersonIDByDriverID(oldLicenseInfo.DriverID);
            Form frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private int addNewApplication()
        {
            clsApplication ApplicationInfo = new clsApplication();
            ApplicationInfo.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(oldLicenseInfo.DriverID);
            ApplicationInfo.ApplicationDate = DateTime.Now;
            ApplicationInfo.ApplicationTypeID = rbDamagedLicense.Checked ? (int)enApplicationTypes.ReplacementForDamagedLicense : (int)enApplicationTypes.ReplacementForLostLicense ;
            ApplicationInfo.ApplicationStatus = (byte)enApplicationStatus.Completed;
            ApplicationInfo.LastStatusDate = DateTime.Now;
            ApplicationInfo.PaidFees = clsApplicationType.GetTypeFees(rbDamagedLicense.Checked ? (int)enApplicationTypes.ReplacementForDamagedLicense : (int)enApplicationTypes.ReplacementForLostLicense);
            ApplicationInfo.CreatedByUserID = clsGlobal.CurrUserID;
            if (ApplicationInfo.Save())
                return ApplicationInfo.ApplicationID;
            else
                return -1;
        }

        private bool issueTheNewLicense()
        {
            newLicenseInfo = new clsLicense();
            newLicenseInfo.ApplicationID = applicationID;
            newLicenseInfo.DriverID = oldLicenseInfo.DriverID;
            newLicenseInfo.LicenseClassID = oldLicenseInfo.LicenseClassID;
            newLicenseInfo.IssueDate = DateTime.Now;
            newLicenseInfo.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.GetClassValidityLength(newLicenseInfo.LicenseClassID));
            newLicenseInfo.PaidFees = clsLicenseClass.GetClassFees(newLicenseInfo.LicenseClassID);
            newLicenseInfo.IsActive = true;
            newLicenseInfo.IssueReason = rbDamagedLicense.Checked ? (byte)enIssueReason.ReplacementForDamaged : (byte)enIssueReason.ReplacementForLost;
            newLicenseInfo.CreatedByUserID = clsGlobal.CurrUserID;

            return newLicenseInfo.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (oldLicenseInfo == null) return;

            DialogResult result = MessageBox.Show("Are you sure you want to continue to issue a new license?", "insuring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            //First: Disactive old license
            oldLicenseInfo.IsActive = false;
            oldLicenseInfo.Save();

            //Second: add new application for the new license
            applicationID = addNewApplication();
            if (applicationID == -1) return;

            //Third: issue the new license
            if (issueTheNewLicense())
            { 
                lblApplicationID.Text = applicationID.ToString();
                lblNewLicenseID.Text = newLicenseInfo.LicenseID.ToString();
                linkShowNewLicenseInfo.Enabled = true;
                MessageBox.Show("New License is issued successfully."); 
            }
            else
                MessageBox.Show("Operation Failed.\nLicense was not issued.");
        }

        private void linkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (newLicenseInfo == null) return;
            Form frm = new frmLicenseInfo(newLicenseInfo.LicenseID);
            frm.ShowDialog();
        }
    }
}
