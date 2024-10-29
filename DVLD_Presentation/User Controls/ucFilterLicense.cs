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
    public partial class ucFilterLicense : UserControl
    {
        
        public ucFilterLicense()
        {
            InitializeComponent();
        }
        public delegate void LicenseFound(clsLicense LicenseInfo);
        public event LicenseFound OnLicenseFound;
        private void txbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(string.IsNullOrEmpty(txbLicenseID.Text))
            {
                errorProvider1.SetError(txbLicenseID, "Invalid Entry!!");
                txbLicenseID.Focus();
                return;
            }

            int LicenseID = Convert.ToInt32(txbLicenseID.Text);
            if (!clsLicense.isLicenseExists(LicenseID))
            {
                clsGlobal.ErrorMessageBox($"No license with ID '{LicenseID}' was found\nPlease, try again.");
                return;
            }
            ucLicenseInfo1.LoadLicenseInfo(LicenseID);

            OnLicenseFound?.Invoke(clsLicense.Find(LicenseID));
        }

        public void Find(int licenseID)
        {
            if (!clsLicense.isLicenseExists(licenseID))
            {
                clsGlobal.ErrorMessageBox($"No license with ID '{licenseID}' was found\nPlease, try again.");
                return;
            }
            ucLicenseInfo1.LoadLicenseInfo(licenseID);
            OnLicenseFound?.Invoke(clsLicense.Find(licenseID));
        }
    }
}
