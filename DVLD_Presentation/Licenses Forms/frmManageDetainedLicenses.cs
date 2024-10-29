using DVLD_Business;
using DVLD_Presentation.Applications_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Licenses_Forms
{
    public partial class frmManageDetainedLicenses : Form
    {
        DataTable DetainedLicensesTable;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            _RefreshTable();
        }

        private void _RefreshTable()
        {
            DetainedLicensesTable = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicensesTable.DataSource = DetainedLicensesTable;
            cmbFilterType.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshTable();
        }

        private void btnReleaseLicenses_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshTable();
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void dgvDetainedLicensesTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalRows.Text = dgvDetainedLicensesTable.Rows.Count.ToString();
        }

        private void dgvDetainedLicensesTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalRows.Text = dgvDetainedLicensesTable.Rows.Count.ToString();
        }

        private void _FilterTable(string Filter)
        {
            DetainedLicensesTable.DefaultView.RowFilter = Filter;
        }

        private void txbFilterValue_TextChangedOnDetainIDAndLicenseID(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text)) 
                _FilterTable("");
            else
            {
                string Filter = $"{cmbFilterType.SelectedItem} = {txbFilterValue.Text}";
                _FilterTable(Filter);
            }
        }

        private void txbFilterValue_TextChangedOnNationalNumberAndFullName(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text))
                _FilterTable("");
            else
            {
                string Filter = $"[{cmbFilterType.SelectedItem}] LIKE '{txbFilterValue.Text}%'";
                _FilterTable(Filter);
            }
        }

        private void txbFilterValue_KeyPressOnDetainIDAndLicenseID(object sender,  KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedFilterItem = cmbFilterType.SelectedItem.ToString();

            txbFilterValue.Visible = true;
            txbFilterValue.Text = "";
            cmbIsReleased.Visible = false;
            txbFilterValue.KeyPress -= txbFilterValue_KeyPressOnDetainIDAndLicenseID;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedOnDetainIDAndLicenseID;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedOnNationalNumberAndFullName;

            if (SelectedFilterItem == "None")
            {
                _FilterTable("");
                txbFilterValue.Visible = false;
            }
            else if(SelectedFilterItem == "DetainID" || SelectedFilterItem == "LicenseID")
            {
                txbFilterValue.KeyPress += txbFilterValue_KeyPressOnDetainIDAndLicenseID;
                txbFilterValue.TextChanged += txbFilterValue_TextChangedOnDetainIDAndLicenseID;
            }
            else if(SelectedFilterItem == "Full Name" || SelectedFilterItem == "National Number")
            {
                txbFilterValue.TextChanged += txbFilterValue_TextChangedOnNationalNumberAndFullName;
            }
            else if(SelectedFilterItem == "IsReleased")
            {
                txbFilterValue.Visible = false;
                cmbIsReleased.Visible = true;
            }
        }

        private void cmbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIsReleased.SelectedIndex == 1)
                _FilterTable("[Is Released] = 1");
            else if (cmbIsReleased.SelectedIndex == 2)
                _FilterTable("[Is Released] = 0");
            else
                _FilterTable("");
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicensesTable.SelectedRows.Count == 0) return;
            string nationalNumber = dgvDetainedLicensesTable.SelectedRows[0].Cells[6].Value.ToString();
            Form frm = new frmPersonDetails(nationalNumber);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicensesTable.SelectedRows.Count == 0) return;
            int licenseID = Convert.ToInt32(dgvDetainedLicensesTable.SelectedRows[0].Cells[1].Value);
            Form frm = new frmLicenseInfo(licenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicensesTable.SelectedRows.Count == 0) return;
            int personID = clsPerson.GetPersonIDByNationalNumber(dgvDetainedLicensesTable.SelectedRows[0].Cells[6].Value.ToString());
            Form frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void releaseTheDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicensesTable.SelectedRows.Count == 0) return;
            int licenseID = Convert.ToInt32(dgvDetainedLicensesTable.SelectedRows[0].Cells[1].Value);
            Form frm = new frmReleaseDetainedLicense(licenseID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDetainedLicensesTable.SelectedRows.Count == 0) return;
            bool isReleased = Convert.ToBoolean(dgvDetainedLicensesTable.SelectedRows[0].Cells["Is Released"].Value);
            releaseTheDetainToolStripMenuItem.Enabled = !isReleased;
        }
    }
}
