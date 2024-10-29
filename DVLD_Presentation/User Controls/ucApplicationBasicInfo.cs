using System;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Presentation.User_Controls
{
    public partial class ucApplicationBasicInfo : UserControl
    {
        clsApplication ApplicationInfo;

        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void _FillFieldsFromObject()
        {
            lblApplicationID.Text = ApplicationInfo.ApplicationID.ToString();
            lblStatus.Text = ApplicationInfo.ApplicationStatus == 1 ? "New" : ApplicationInfo.ApplicationStatus == 2 ? "Cancelled" : "Completed";
            lblFees.Text = ApplicationInfo.PaidFees.ToString();
            lblType.Text = clsApplicationType.GetTypeTitleBy(ApplicationInfo.ApplicationTypeID);
            lblApplicant.Text = clsPerson.GetFullNameBy(ApplicationInfo.ApplicantPersonID);
            lblAppDate.Text = ApplicationInfo.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = ApplicationInfo.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsUser.GetUserName(ApplicationInfo.CreatedByUserID);
        }
       
        public bool LoadApplicationInfo(int  ApplicationID)
        {
            ApplicationInfo = clsApplication.Find(ApplicationID);

            if (ApplicationInfo == null)
                return false;

            _FillFieldsFromObject();
            return true;

        }

        private void ViewPersonInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ApplicationInfo == null)
                return;
            Form frm = new frmPersonDetails(ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
