using DVLD_Business;
using DVLD_Presentation.Applications_Forms;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses_Forms
{
    public partial class frmDetainLicense : Form
    {
        private clsLicense licenseInfo;
        public frmDetainLicense()
        {
            InitializeComponent();
            _SetIntialValues();
        }

        private void _SetIntialValues()
        {
            lblCreatedBy.Text = clsUser.GetUserName(clsGlobal.CurrUserID);
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (licenseInfo == null) return;
            int personID = clsPerson.GetPersonIDByDriverID(licenseInfo.DriverID);
            Form frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void linkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (licenseInfo == null) return;
            Form frm = new frmLicenseInfo(licenseInfo.LicenseID);
            frm.ShowDialog();

        }

        private void ucFilterLicense1_OnPersonFound(clsLicense LicenseInfo)
        {
            this.licenseInfo = LicenseInfo;
            if(clsDetainedLicense.isDetained(LicenseInfo.LicenseID))
            {
                clsGlobal.ErrorMessageBox("This License is already detained");
            }
            else
            {
                lblLicenseID.Text = licenseInfo.LicenseID.ToString();
                gbDetainInfo.Enabled = true;
                btnDetain.Enabled = true;
                linkShowLicenseInfo.Enabled = true;
            }
        }

        private bool _DetainTheLicense()
        {
            if (licenseInfo == null) return false;

            clsDetainedLicense DetainInfo = new clsDetainedLicense();
            DetainInfo.LicenseID = licenseInfo.LicenseID;
            DetainInfo.DetainDate = DateTime.Now;
            DetainInfo.FineFees = Convert.ToDouble(txbFineFees.Text);
            DetainInfo.CreatedByUserID = clsGlobal.CurrUserID;
            DetainInfo.IsReleased = false;
            if (DetainInfo.Save())
            {
                lblDetainID.Text = DetainInfo.DetainID.ToString();
                return true;
            }
            else
                return false;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(licenseInfo == null) return;
            else if(clsDetainedLicense.isDetained(licenseInfo.LicenseID))
            {
                clsGlobal.ErrorMessageBox("This License is already detained");
                return;
            }    
            else if(string.IsNullOrEmpty(txbFineFees.Text))
            {
                errorProvider1.SetError(txbFineFees, "Please, enter the fees amount");
                txbFineFees.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to detain this license?", "Insuring", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;

                if (_DetainTheLicense())
                {
                    ucFilterLicense1.gbFilter.Enabled = false;
                    btnDetain.Enabled = false;
                    MessageBox.Show("License is detained successfully", "Message");
                }
                else
                    clsGlobal.ErrorMessageBox("Failed to detain the license");

            }
        }

        private void txbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == '.' && !txbFineFees.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}
