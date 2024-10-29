using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmDriversList : Form
    {
        DataTable DriversTable;
        public frmDriversList()
        {
            InitializeComponent();
        }
        private void frmDriversList_Load(object sender, EventArgs e)
        {
            _RefreshTable();
        }
        private void _RefreshTable()
        {
            DriversTable = clsDriver.GetDriversList();
            dgvDriversList.DataSource = DriversTable;
            dgvDriversList.Columns[0].Width = 100;
            dgvDriversList.Columns[1].Width = 100;
            dgvDriversList.Columns[2].Width = 120;
            dgvDriversList.Columns[3].Width = 300;
            dgvDriversList.ColumnHeadersHeight = 25;
        }
        private void _FilterTable(string Filter)
        {
            DriversTable.DefaultView.RowFilter = Filter;
        }
        private void _txbFilterValue_KeyPressOnlyDigits(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void _txbFilterValue_TextChangeCaseDriverID(object sender, EventArgs e)
        {
            string Filter;
            if (string.IsNullOrWhiteSpace(txbFilterValue.Text))
                Filter = "";
            else
                Filter = $"DriverID = {txbFilterValue.Text}";

            _FilterTable (Filter);
        }

        private void _txbFilterValue_TextChangeCasePersonID(object sender, EventArgs e)
        {
            string Filter;
            if (string.IsNullOrWhiteSpace(txbFilterValue.Text))
                Filter = "";
            else
                Filter = $"PersonID = {txbFilterValue.Text}";

            _FilterTable(Filter);
        }

        private void _txbFilterValue_TextChangeCaseFullName(object sender, EventArgs e)
        {
            string Filter;
            if (string.IsNullOrWhiteSpace(txbFilterValue.Text))
                Filter = "";
            else
                Filter = $"FullName LIKE '{txbFilterValue.Text}%'";

            _FilterTable(Filter);
        }

        private void _txbFilterValue_TextChangeCaseNationalNumber(object sender, EventArgs e)
        {
            string Filter;
            if (string.IsNullOrWhiteSpace(txbFilterValue.Text))
                Filter = "";
            else
                Filter = $"NationalNumber LIKE '{txbFilterValue.Text}%'";

            _FilterTable(Filter);
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterType.SelectedIndex == 0) 
            {
                _FilterTable("");
                txbFilterValue.Visible = false;
                return;
            }

            txbFilterValue.Visible = true;
            txbFilterValue.Text = "";
            txbFilterValue.TextChanged -= _txbFilterValue_TextChangeCaseDriverID;
            txbFilterValue.KeyPress -= _txbFilterValue_KeyPressOnlyDigits;
            txbFilterValue.TextChanged -= _txbFilterValue_TextChangeCasePersonID;
            txbFilterValue.TextChanged -= _txbFilterValue_TextChangeCaseFullName;
            txbFilterValue.TextChanged -= _txbFilterValue_TextChangeCaseNationalNumber;

            if (cmbFilterType.SelectedIndex == 1)
            {
                txbFilterValue.TextChanged += _txbFilterValue_TextChangeCaseDriverID;
                txbFilterValue.KeyPress += _txbFilterValue_KeyPressOnlyDigits;
            }
            else if(cmbFilterType.SelectedIndex == 2)
            {
                txbFilterValue.TextChanged += _txbFilterValue_TextChangeCasePersonID;
                txbFilterValue.KeyPress += _txbFilterValue_KeyPressOnlyDigits;
            }
            else if(cmbFilterType.SelectedIndex == 3)
                txbFilterValue.TextChanged += _txbFilterValue_TextChangeCaseFullName;
            else if(cmbFilterType.SelectedIndex == 4)
                txbFilterValue.TextChanged += _txbFilterValue_TextChangeCaseNationalNumber;
        }

    }
}
