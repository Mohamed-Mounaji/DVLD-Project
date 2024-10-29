using DVLD_Presentation.Applications_Forms;
using DVLD_Presentation.Licenses_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmMainScreen : Form
    {
        private Form _LoginForm;
        private bool _isLoginOut = false;
        public frmMainScreen(Form LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
        }

        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ManagePeopleForm = new frmManagePeople();
            ManagePeopleForm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ManageUsers = new frmManageUsers();
            ManageUsers.ShowDialog();
        }

        private void ToolStripMenuItem_Enter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void ToolStripMenuItem_Leave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form UserInfoForm = new frmUserInfo(clsGlobal.CurrUserID);
            UserInfoForm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ChangePassForm = new frmChangeUserPassword(clsGlobal.CurrUserID);
            ChangePassForm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out ?", "Logging out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            _isLoginOut = true;
            if(_LoginForm!= null)_LoginForm.Visible = true;
            this.Close();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDriversList();
            frm.ShowDialog();
        }

        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isLoginOut)
                _LoginForm?.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmManageApplicationTypes();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmManageTestTypes();
            form.StartPosition =FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageLDLApps();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForLostDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplaceLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainALicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseADetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageLDLApps();
            frm.ShowDialog();
        }
    }
}
