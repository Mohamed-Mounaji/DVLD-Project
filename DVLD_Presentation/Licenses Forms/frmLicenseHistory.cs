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
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            ucPersonInformation1.LoadPersonData(personID);
            _LoadLocalLicenses(personID);
            _LoadInternationalLicenses(personID);
        }
        
        private void _LoadLocalLicenses(int personID)
        {
            dgvLocalLicense.DataSource = clsPerson.GetLicensesHistory(personID);
            dgvLocalLicense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalLicense.Columns[0].Width = 100;
            dgvLocalLicense.Columns[1].Width = 100;
            dgvLocalLicense.Columns[2].Width = 300;
            dgvLocalLicense.Columns[5].Width = 100;
        }

        private void _LoadInternationalLicenses(int personID)
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetLicensesByPersonID(personID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicense.SelectedRows.Count == 0) return;
            int LicenseID = Convert.ToInt32(dgvLocalLicense.SelectedRows[0].Cells[0].Value);
            Form frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count == 0) return;
            int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells[0].Value);
            Form frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
