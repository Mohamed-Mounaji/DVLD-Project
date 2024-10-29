using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmScheduleTest : Form
    {
        private clsTestAppointment _AppointmentInfo;

        public frmScheduleTest(int localDrivingLicenseApplicationID, enTestType testType, bool isRetakenTest)
        {
            InitializeComponent();
            _AppointmentInfo = new clsTestAppointment();

            _AppointmentInfo.TestTypeID = (byte)testType;
            _AppointmentInfo.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _AppointmentInfo.AppointmentDate = (DateTime.Now).AddDays(1);
            _AppointmentInfo.PaidFees = clsTestType.GetTestTypeFeesBy((byte)testType);
            _AppointmentInfo.CreatedByUserID = clsGlobal.CurrUserID;
            _AppointmentInfo.IsLocked = false;

            if(isRetakenTest)
            {
                _SetRetakeTestFields();
            }
        }

        public frmScheduleTest(int TestAppointmentID, bool isRetakenTest)
        {
            InitializeComponent();
           
            _AppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            if (isRetakenTest)
            {
                _SetRetakeTestFields();
            }
        }

        private void _SetRetakeTestFields()
        {
            gbRetakeTestInfo.Enabled = true;
            lblRetakeTestFees.Text = "5";
            lblTotalFees.Text = $"{5 + _AppointmentInfo.PaidFees}";

        }

        private  void _SetHeaderPicture()
        {
            switch((enTestType)_AppointmentInfo.TestTypeID)
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

        private void _SetFieldValues()
        {
            clsLocalDrivingLicenseApplication LDLAppInfo = clsLocalDrivingLicenseApplication.Find(_AppointmentInfo.LocalDrivingLicenseApplicationID);
            if (_AppointmentInfo.IsLocked)
            {
                dtpAppointmentDate.Enabled = false;
                btnSave.Enabled = false;
                lblAppointmentLockedMessage.Visible = true;
            }

            lblID.Text = _AppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lblApplicantName.Text = clsPerson.GetFullNameBy(LDLAppInfo.ApplicationInfo.ApplicantPersonID);
            lblClassName.Text = clsLicenseClass.GetClassNameBy(LDLAppInfo.LicenseClassID);
            dtpAppointmentDate.MinDate = _AppointmentInfo.AppointmentDate;
            lblTrial.Text = "Unknow Filed";
            lblFees.Text = _AppointmentInfo.PaidFees.ToString();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _SetHeaderPicture();
            _SetFieldValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AppointmentInfo.AppointmentDate = dtpAppointmentDate.Value;
                     
            if(_AppointmentInfo.Save())
            {
                MessageBox.Show("Appointment was save successfully :)");
                this.Close();
            }
            else
            {
                clsGlobal.ErrorMessageBox("Appointment was not saved :(");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
