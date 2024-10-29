using System;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshAppTypesTable()
        {
            dgvAppTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            dgvAppTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmManageApplicationTypes_Load(object sender, System.EventArgs e)
        {
            _RefreshAppTypesTable();
            lblTotalRows.Text = dgvAppTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int AppTypeID = Convert.ToInt32( dgvAppTypes.SelectedRows[0].Cells[0].Value);

            Form UpdateAppTypeForm = new frmUpdateApplicationType(AppTypeID);
            UpdateAppTypeForm.ShowDialog();
            _RefreshAppTypesTable();
        }
    }
}
