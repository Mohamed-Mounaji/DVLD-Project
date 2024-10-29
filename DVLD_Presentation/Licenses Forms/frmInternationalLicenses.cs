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
    public partial class frmInternationalLicenses : Form
    {
        DataTable LicensesTable;
        public frmInternationalLicenses()
        {
            InitializeComponent();
            _RefreshTable();
        }
        private void _RefreshTable()
        {
            LicensesTable = clsInternationalLicense.GetAllLicensesTable();
            dgvInternationalLicenses.DataSource = LicensesTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void btnAddNewApp_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewInternationalLicense();
            frm.ShowDialog();
            _RefreshTable();
        }

        private void dgvInternationalLicenses_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalRows.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void dgvInternationalLicenses_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalRows.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;

            int ApplicationID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["Application ID"].Value);
            int personID = clsPerson.GetPersonIDByApplicationID(ApplicationID);

            Form frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int ApplicationID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["Application ID"].Value);
            int personID = clsPerson.GetPersonIDByApplicationID(ApplicationID );

            Form frm = new frmPersonDetails(personID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int LicenseID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells[0].Value);
            Form frm = new frmShowInternationalLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbFilterValue.Visible = false;
            cmbStatusFilter.Visible = false;

            string SelectedItem = cmbFilterType.SelectedItem.ToString();
            if (SelectedItem == "(none)") return;

            if(SelectedItem == "is Active")
            {
                txbFilterValue.Visible = false;
                cmbStatusFilter.Visible = true;
                return;
            }

            cmbStatusFilter.Visible = false;
            txbFilterValue.Visible=true;
            txbFilterValue.Text = "";
        }

        private void txbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string Filter = "";
            if (!string.IsNullOrEmpty(txbFilterValue.Text))
                Filter = $"[{cmbFilterType.SelectedItem}] = {txbFilterValue.Text}";

           LicensesTable.DefaultView.RowFilter = Filter;
        }

        private void txbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusFilter.SelectedIndex == 0)
                LicensesTable.DefaultView.RowFilter = "";
            else if (cmbStatusFilter.SelectedIndex == 1)
                LicensesTable.DefaultView.RowFilter = "[is Active] = 1";
            else if( cmbStatusFilter.SelectedIndex == 2)
                LicensesTable.DefaultView.RowFilter = "[is Active] = 0";
        }
    }
}
