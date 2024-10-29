using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {         
        private clsPerson _applicantInfo = null;
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _FillLicenseClassesOnComboBox()
        {
            cmbLicenseClass.DataSource = clsLicenseClass.GetAllClassesNames();
            cmbLicenseClass.DisplayMember = "ClassName";
            
        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesOnComboBox();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsUser.GetUserName(clsGlobal.CurrUserID);
            lblApplicationFees.Text = "15";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_applicantInfo == null)
            {
                clsGlobal.ErrorMessageBox("Choose an Applicant please!");
                return;
            }
            AddNewApplicationTabControl.SelectedIndex = 1;
        }

        private void ucFilterPerson1_PersonFound(clsPerson PersonInfo)
        {
            _applicantInfo = PersonInfo;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_applicantInfo == null)
            {
                AddNewApplicationTabControl.SelectedIndex = 0;
                clsGlobal.ErrorMessageBox("Please, choose an applicant");
                return;
            }

            // check if the applicant already has a none-completed application of the Selected  License Class 

            int result = clsLocalDrivingLicenseApplication.IsApplicationsExists(_applicantInfo.PersonID, cmbLicenseClass.SelectedIndex + 1);
            if(result != -1)
            {
                clsGlobal.ErrorMessageBox($"Can't create the application. The Applicant Already has an active applicatin of the same license class with ID {result} ");
                return;
            }

            //Check if the applicant already has a license of the selected License Class
            result = clsLicense.GetActiveLicenseIDBy(_applicantInfo.PersonID, cmbLicenseClass.SelectedIndex + 1);

            if(result != -1)
            {
                clsGlobal.ErrorMessageBox($"Can't create the application for this license class. The applicant already has a license of this class with the ID '{result}'");
                return;
            }

            
            clsLocalDrivingLicenseApplication LDLApplication = new clsLocalDrivingLicenseApplication();
            LDLApplication.ApplicationInfo = new clsApplication();
            LDLApplication.ApplicationInfo.ApplicantPersonID = _applicantInfo.PersonID;
            LDLApplication.ApplicationInfo.ApplicationDate = DateTime.Now;
            LDLApplication.ApplicationInfo.ApplicationTypeID = 1;
            LDLApplication.ApplicationInfo.ApplicationStatus = Convert.ToByte(enApplicationStatus.New);
            LDLApplication.ApplicationInfo.LastStatusDate = DateTime.Now;
            LDLApplication.ApplicationInfo.PaidFees = float.Parse(lblApplicationFees.Text);
            LDLApplication.ApplicationInfo.CreatedByUserID = clsGlobal.CurrUserID;

            //save the application info first then if it succeeded save the Local driving license application
            if(!LDLApplication.ApplicationInfo.Save())
            {
                clsGlobal.ErrorMessageBox("Saving the application info failed");
                return;
            }

            LDLApplication.LicenseClassID = cmbLicenseClass.SelectedIndex + 1;


            // CHECK IF THE SAVING SUCCEEDED IF YES PUT THE ID IN THE LABEL IF NOT SHOW AN ERROR MESSAGE BOX
            if (!LDLApplication.Save())
            {
                clsGlobal.ErrorMessageBox("The application was save, but the LDLApplication was not saved. contact the admin please!");
                return;
            }

            lblApplicationID.Text = LDLApplication.LDLApplicationID.ToString();
            MessageBox.Show("Your aplication was saved successfully :)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
