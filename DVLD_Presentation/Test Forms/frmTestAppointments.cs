using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Presentation.Applications_Forms
{
    public partial class frmTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private enTestType _TestTypeID;
        private DataTable _AppointmentsTable;

        public frmTestAppointments(int LocalDrivingLicenseApplicationID, enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestType;
        }

        private void _SetFormTitleAndHeaderImage()
        {
            switch(_TestTypeID)
            {
                case enTestType.VisionTest:
                    lblTitle.Text = "Vision Test Appointments";
                    pcbHeaderImage.Image = Properties.Resources.VisionTestHeader;
                    break;

                case enTestType.WrittenTest:
                    lblTitle.Text = "Written Test Appointments";
                    pcbHeaderImage.Image = Properties.Resources.WrittenTestHeader;
                    break;

                case enTestType.StreetTest:
                    lblTitle.Text = "Street Test Appointments";
                    pcbHeaderImage.Image = Properties.Resources.StreetTestHeader;
                    break;
            }
        }
        private void _RefreshAppointmentsTable()
        {
            _AppointmentsTable = clsTestAppointment.GetAppointmentsTableBasedOn((byte)_TestTypeID, _LocalDrivingLicenseApplicationID);
            dgvAppointmentsTable.DataSource = _AppointmentsTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestAppointments_Shown(object sender, EventArgs e)
        {
            if (!ucLocalDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseAppInfoBy(_LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show($"The Local D.L. Application with id '{_LocalDrivingLicenseApplicationID}' deos not exist");
                this.Close();
            }


        }

        private void TestAppointments_Load(object sender, EventArgs e)
        {
            _SetFormTitleAndHeaderImage();
            _RefreshAppointmentsTable();
        }

        private void dgvAppointmentsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalRows.Text = dgvAppointmentsTable.Rows.Count.ToString();
        }

        private void dgvAppointmentsTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalRows.Text = dgvAppointmentsTable.Rows.Count.ToString();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.HasActiveAppointment((byte)_TestTypeID, _LocalDrivingLicenseApplicationID))
            {
                clsGlobal.ErrorMessageBox("Person already has an active appointment for this test.\nYou can not add another appointment!!");
                return;
            }

            if (clsLocalDrivingLicenseApplication.isTestPassed(_LocalDrivingLicenseApplicationID, (byte)_TestTypeID))
            {
                clsGlobal.ErrorMessageBox("This Test is passed, You can't schedule an appointment");
                return;
            }

           Form frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, clsTest.isFailedOnTest(_LocalDrivingLicenseApplicationID, (byte)_TestTypeID));
            frm.ShowDialog();
            _RefreshAppointmentsTable();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentsTable.SelectedRows.Count == 0) return;

            int SelectedAppointmentID = Convert.ToInt32(dgvAppointmentsTable.SelectedRows[0].Cells[0].Value);
            Form frm = new frmScheduleTest(SelectedAppointmentID, clsTest.isFailedOnTest(_LocalDrivingLicenseApplicationID, (byte)_TestTypeID));
            frm.ShowDialog();
            _RefreshAppointmentsTable();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentsTable.SelectedRows.Count == 0) return;

            if (Convert.ToBoolean(dgvAppointmentsTable.SelectedRows[0].Cells["Is Locked"].Value)) return;

            int SelectedAppointmentID = Convert.ToInt32(dgvAppointmentsTable.SelectedRows[0].Cells[0].Value);
            Form frm = new frmTakeTest(SelectedAppointmentID);
            frm.ShowDialog();

            _RefreshAppointmentsTable();
        }
    }
}
