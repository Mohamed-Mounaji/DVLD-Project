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

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmTakeTest : Form
    {
        private clsTestAppointment _TestAppointmentInfo; 

        public frmTakeTest(int testAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentInfo = clsTestAppointment.Find(testAppointmentID);

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _SetHeaderPicture();
            _FillTestInfoFields();
        }

        private void _SetHeaderPicture()
        {
            enTestType TestType = (enTestType)_TestAppointmentInfo.TestTypeID;
            switch(TestType)
            {
                case enTestType.VisionTest:
                    HeaderPicture.Image = Properties.Resources.VisionTestHeader;
                    break;
                case enTestType.WrittenTest:
                    HeaderPicture.Image = Properties.Resources.WrittenTestHeader;
                    break;
                case enTestType.StreetTest:
                    HeaderPicture.Image = Properties.Resources.StreetTestHeader;
                    break;

            }
        }
        private void _FillTestInfoFields()
        {
            if (_TestAppointmentInfo == null) return;
            clsLocalDrivingLicenseApplication ApplicationInfo = clsLocalDrivingLicenseApplication.Find(_TestAppointmentInfo.LocalDrivingLicenseApplicationID);

            lblID.Text = _TestAppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = clsLicenseClass.GetClassNameBy( ApplicationInfo.LicenseClassID);
            lblApplicantName.Text = clsPerson.GetFullNameBy( ApplicationInfo.ApplicationInfo.ApplicantPersonID);
            lblTrial.Text = "Unknow";
            lblDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            lblTestID.Text = "N/A";
        }

        private void _AddNewDriverAndLicense()
        { 
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointmentInfo.IsLocked = true;
            _TestAppointmentInfo.Save();

            clsTest TestInfo = new clsTest();
            TestInfo.TestAppointmentID = _TestAppointmentInfo.TestAppointmentID;
            TestInfo.TestResult = rbPass.Checked;
            TestInfo.Notes = txbNotes.Text;
            TestInfo.CreatedByUserID = clsGlobal.CurrUserID;


            if (TestInfo.Save())
            {
                MessageBox.Show("Test Info Saved Successfully");
                lblTestID.Text = TestInfo.TestID.ToString();
                this.Close();
            }
            else
                MessageBox.Show("Test Info was not saved");
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
