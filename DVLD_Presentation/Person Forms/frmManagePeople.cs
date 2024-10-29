using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class frmManagePeople : Form
    {
        DataTable PeopleTable;
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void _ShowNotImplementedMessage()
        {
            MessageBox.Show("This Feature was not implemented yet.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _OpenAddNewPersonForm()
        {
            Form AddNewPersonScreen = new frmAddEditPeson(-1);
            AddNewPersonScreen.ShowDialog();
            _RefreshPeopleTable();
        }

        private void _FilterPeopleTable(string filter)
        {
            PeopleTable.DefaultView.RowFilter = filter;
        }
        private void _RefreshPeopleTable()
        {
            PeopleTable = clsPerson.GetAllPeople();
            dgvPeopleTable.DataSource = PeopleTable;
            cmbxFilterType.SelectedIndex = 0;
        }
        private void _frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleTable();
        }
        private void _btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _OpenAddNewPersonForm();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenAddNewPersonForm();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleTable.SelectedRows.Count == 0)
                return;
            Form EditPersonForm = new frmAddEditPeson(Convert.ToInt16(dgvPeopleTable.SelectedRows[0].Cells["PersonID"].Value));
            EditPersonForm.ShowDialog();
            _RefreshPeopleTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleTable.SelectedRows.Count == 0)
                return;
            if (MessageBox.Show("Are You Sure you want to delete this Person", "Ensuring", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(Convert.ToInt32(dgvPeopleTable.SelectedRows[0].Cells["PersonID"].Value)))
                {
                    _RefreshPeopleTable();
                    MessageBox.Show("Person Was Deleted Successfully", "Message", MessageBoxButtons.OK);
                }

                else
                    MessageBox.Show("Person Was Not Deleted! \nhe/she is linked with other data in the form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Not Implemented Function
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowNotImplementedMessage();
        }

        //Not Implemented Function
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowNotImplementedMessage();
        }

        private void cmbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedFilterType = Convert.ToString(cmbxFilterType.SelectedItem);
            txbFilterValue.KeyPress -= txbFilterValue_KeyPressHandleNoneDigit;

            if (SelectedFilterType == "None")
            {
                txbFilterValue.Visible = false;
                btnApplyFilter.Visible = false;
                _FilterPeopleTable("");
                return;
            }

            txbFilterValue.Visible = true;
            btnApplyFilter.Visible = true;
            txbFilterValue.Text = "";

            if ( SelectedFilterType == "PersonID" || SelectedFilterType == "Phone")
                txbFilterValue.KeyPress += txbFilterValue_KeyPressHandleNoneDigit;
        }

        private void txbFilterValue_KeyPressHandleNoneDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string SelectedFilterType = Convert.ToString(cmbxFilterType.SelectedItem);
            string FilterFieldValue = Convert.ToString(txbFilterValue.Text);

            if (FilterFieldValue == "")
            {
                _FilterPeopleTable("");
                return;
            }
            if (SelectedFilterType == "PersonID")
            {
                _FilterPeopleTable($"PersonID = {FilterFieldValue}");
            }
            else if(SelectedFilterType == "National Number")
            {
                _FilterPeopleTable($"NationalNumber = '{FilterFieldValue}'");
            }
            else if (SelectedFilterType == "First Name")
            {
                _FilterPeopleTable($"FirstName = '{FilterFieldValue}'");
            }
            else if (SelectedFilterType == "Second Name")
            {
                _FilterPeopleTable($"SecondName = '{FilterFieldValue}'");
            }
            else if (SelectedFilterType == "Third Name")
            {
                _FilterPeopleTable($"ThirdName = '{FilterFieldValue}'");
            }
            else if (SelectedFilterType == "Last Name")
            {
                _FilterPeopleTable($"LastName = '{FilterFieldValue}'");

            }
            else if (SelectedFilterType == "Nationality")
            {
                int CountryID;
                if (int.TryParse(FilterFieldValue, out  CountryID))
                {
                    _FilterPeopleTable($"Nationality = {CountryID}");
                }
                else
                {
                CountryID = clsCountry.GetCountryID(FilterFieldValue);
                _FilterPeopleTable($"Nationality = '{CountryID}'");
                }
            }
            else if (SelectedFilterType == "Gender")
            {
                if (FilterFieldValue.ToLower() == "female" || FilterFieldValue.ToLower() == "f" || FilterFieldValue == "1")
                    _FilterPeopleTable("Gender = 1");

                else if (FilterFieldValue.ToLower() == "male" || FilterFieldValue.ToLower() == "m" || FilterFieldValue == "0")
                    _FilterPeopleTable("Gender = 0");
                else
                    _FilterPeopleTable("");
            }
            else if (SelectedFilterType == "Phone")
            {
                _FilterPeopleTable($"Phone = '{FilterFieldValue}'");
            }
            else if (SelectedFilterType == "Email")
            {
                _FilterPeopleTable($"Email = '{FilterFieldValue}'");
            }
        }

        private void dgvPeopleTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalPeopleInTable.Text = dgvPeopleTable.Rows.Count.ToString();
        }

        private void dgvPeopleTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalPeopleInTable.Text = dgvPeopleTable.Rows.Count.ToString();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeopleTable.SelectedRows.Count < 1)
                return;

            int PersonID = Convert.ToInt32(dgvPeopleTable.SelectedRows[0].Cells["PersonID"].Value);
            Form PersonDetailsForm = new frmPersonDetails(PersonID);
            PersonDetailsForm.ShowDialog();
            _RefreshPeopleTable();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _RefreshPeopleTable();
        }
    }
}
