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
    public partial class frmManageLDLApps : Form
    {
        DataTable ApplicationsTable;
        public frmManageLDLApps()
        {
            InitializeComponent();
        }

        private void _FilterTable(string Filter)
        {
            ApplicationsTable.DefaultView.RowFilter = Filter;
        }

        private void _RefreshTable()
        {
            ApplicationsTable = clsLocalDrivingLicenseApplication.GetAllApplications();
            dgvApplicationsTable.DataSource = ApplicationsTable;
            dgvApplicationsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplicationsTable.Columns[0].Width = 90;
            dgvApplicationsTable.Columns[1].Width = 250;
            dgvApplicationsTable.Columns[2].Width = 150;
            dgvApplicationsTable.Columns[3].Width = 280;
            dgvApplicationsTable.Columns[5].Width = 100;
        }

        private void btnAddNewApp_Click(object sender, EventArgs e)
        {
            Form form = new frmNewLocalDrivingLicenseApplication();
            form.ShowDialog();
            _RefreshTable();
        }

        private void frmManageLDLApps_Load(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void dgvApplicationsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalRows.Text = dgvApplicationsTable.Rows.Count.ToString();
        }

        private void dgvApplicationsTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalRows.Text = dgvApplicationsTable.Rows.Count.ToString();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStatusFilter.Visible = false;
            txbFilterValue.Visible = false;
            txbFilterValue.KeyPress -= txbFilterValue_KeyPressHandleNoneDigits;
            txbFilterValue.TextChanged -= txbFilterValue_TextChanged;


            if (cmbFilterType.SelectedIndex == 0)
            {
                _FilterTable("");
                return;
            }

            if(cmbFilterType.SelectedIndex == 4) 
            {
                cmbStatusFilter.Visible = true;
                return;
            }

            txbFilterValue.Visible = true;

            if(cmbFilterType.SelectedIndex == 1)
            {
                txbFilterValue.KeyPress+=txbFilterValue_KeyPressHandleNoneDigits;
                txbFilterValue.TextChanged += txbFilterValue_TextChangedForAppID;
                return;
            }

            txbFilterValue.TextChanged += txbFilterValue_TextChanged;
            
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusFilter.SelectedIndex == 1)
                _FilterTable("[Status] = 'New'");
            else if (cmbStatusFilter.SelectedIndex == 2)
                _FilterTable("[Status] = 'Cancelled'");
            else if (cmbStatusFilter.SelectedIndex == 3)
                _FilterTable("[Status] = 'Completed'");
            else
                _FilterTable("");
        }

        private void txbFilterValue_KeyPressHandleNoneDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string ColumnName = cmbFilterType.SelectedItem.ToString();
            string Filter = $"[{ColumnName}] LIKE '{txbFilterValue.Text}%'";
            _FilterTable(Filter);
        }

        private void txbFilterValue_TextChangedForAppID(object sender, EventArgs e)
        {
            if (txbFilterValue.Text =="")
            {
                _FilterTable("");
                return;
            }
            string Filter = $"[LocalDrivingLicenseApplicationID] = {txbFilterValue.Text}";
            _FilterTable(Filter);
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strTest = dgvApplicationsTable.SelectedRows[0].Cells[0].Value.ToString();
            int SelectedApplicationID = Convert.ToInt32(strTest);
            Form frm = new frmTestAppointments(SelectedApplicationID, enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedApplicationID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value.ToString());
            Form frm = new frmTestAppointments(SelectedApplicationID, enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshTable();
        }

       
        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedApplicationID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value.ToString());
            Form frm = new frmTestAppointments(SelectedApplicationID, enTestType.StreetTest);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void _SetMenuStripItemsForCancelledApp()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestToolStripMenuItem.Enabled = false;
            issueToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _SetMenuStripItemsForNewApp()
        {
            int LDLAppID = int.Parse(dgvApplicationsTable.SelectedRows[0].Cells[0].Value.ToString());
            bool isVisionTestPassed = clsLocalDrivingLicenseApplication.isVisionTestPassed(LDLAppID);
            bool isWrittenTestPassed = clsLocalDrivingLicenseApplication.isWrittenTestPassed(LDLAppID);
            bool isStreetTestPassed = clsLocalDrivingLicenseApplication.isStreetTestPassed(LDLAppID);

            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem .Enabled = true;

            if(isVisionTestPassed && isWrittenTestPassed && isStreetTestPassed)
            {
                scheduleTestToolStripMenuItem.Enabled = false;
                issueToolStripMenuItem.Enabled = true;
            }
            else
            {
                issueToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                if (!isVisionTestPassed)
                    visionTestToolStripMenuItem.Enabled = true;
                else if (!isWrittenTestPassed)
                    writtenTestToolStripMenuItem.Enabled = true;
                else if (!isStreetTestPassed)
                    streetTestToolStripMenuItem.Enabled = true;
            }
           
        }

        private void _SetMenuStripItemsForCompletedApp()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled= false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestToolStripMenuItem.Enabled = false;
            issueToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem .Enabled = true;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
             if(Enum.TryParse(dgvApplicationsTable.SelectedRows[0].Cells["Status"].Value.ToString(), out enApplicationStatus applicationStatus))
             {
                switch(applicationStatus)
                {
                    case enApplicationStatus.New:
                        _SetMenuStripItemsForNewApp();
                        break;
                    case enApplicationStatus.Cancelled:
                        _SetMenuStripItemsForCancelledApp();
                        break;
                    case enApplicationStatus.Completed:
                        _SetMenuStripItemsForCompletedApp();
                        break;
                }
             }


        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationsTable.SelectedRows.Count == 0) return;
            int AppID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value);
            Form frm = new frmLocalDrivingLicenseApplicationInfo(AppID);
            frm.ShowDialog();            
        }
        
        //NOT IMPLEMENTED FUNCTION
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.NotImplementedMessageBox();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dgvApplicationsTable.SelectedRows.Count == 0) return;

            var DeletionEnsuringResult = MessageBox.Show("Are you sure you want to delete this Application ??", "Ensuring Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DeletionEnsuringResult == DialogResult.No) return;

            int SelectedID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value);
            //This Will Delete each Apointment and its test that is refrencing The target Application
            clsTestAppointment.DeleteAppointmetsRelatedTo(SelectedID);

            //This method will delete LDLApplication and the Application that is refrenced by it
            if (clsLocalDrivingLicenseApplication.DeleteBy(SelectedID))
                MessageBox.Show("Application Was Deleted Successfully!!");

            else
                clsGlobal.ErrorMessageBox("Application was not deleted!");

            _RefreshTable();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.NotImplementedMessageBox();
            int LDLAppID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value);
            clsLocalDrivingLicenseApplication App = clsLocalDrivingLicenseApplication.Find(LDLAppID);
            int ApplicationID = App.ApplicationInfo.ApplicationID;

            if (clsApplication.Cancel(ApplicationID))
                MessageBox.Show("Application was canceled successfully", "Message");
            else
                clsGlobal.ErrorMessageBox("Application was not canceled");
            _RefreshTable();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationsTable.SelectedRows.Count == 0) return;
            int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvApplicationsTable.SelectedRows[0].Cells[0].Value);
            int LicenseID = clsLicense.GetLicenseIDBy(SelectedLocalDrivingLicenseApplicationID);

            Form frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationsTable.SelectedRows.Count <= 0) return;
            int localDrivingLicenseApplication = Convert.ToInt32( dgvApplicationsTable.SelectedRows[0].Cells[0].Value);

            Form frm = new frmIssueDrivingLicense(localDrivingLicenseApplication);
            frm.ShowDialog();
            _RefreshTable();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationsTable.SelectedRows.Count == 0) return;
            string NationalNumber = dgvApplicationsTable.SelectedRows[0].Cells[2].Value.ToString();
            clsPerson PersonInfo = clsPerson.Find(NationalNumber);
            if (PersonInfo == null) return;

            Form frm = new frmLicenseHistory(PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            _RefreshTable();
        }
    }
}
