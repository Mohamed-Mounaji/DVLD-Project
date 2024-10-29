using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshTable()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            dgvTestTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTestTypes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTable();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.SelectedRows.Count == 0) return;

            int SelectedTestTypeID = Convert.ToInt32(dgvTestTypes.SelectedRows[0].Cells[0].Value);
            Form form = new frmUpdateTestType(SelectedTestTypeID);
            form.ShowDialog();
            _RefreshTable();
            
        }
    }
}
