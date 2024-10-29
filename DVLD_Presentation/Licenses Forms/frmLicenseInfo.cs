using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            ucLicenseInfo1.LoadLicenseInfo(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
