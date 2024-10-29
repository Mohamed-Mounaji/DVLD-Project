using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class frmManageUsers : Form
    {
        DataTable UsersTable = new DataTable();
        public frmManageUsers()
        {
            InitializeComponent();
        }

        //None Implemented Method
        private void _FilterUsersTable(string Filter)
        {
            UsersTable.DefaultView.RowFilter = Filter;
        }

        private void txbFilterValue_TextChangedFilterForUserID(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text))
            {
                _FilterUsersTable("");
                return;
            }
            _FilterUsersTable($"[User ID] = {Convert.ToString(txbFilterValue.Text)}");
        }

        private void txbFilterValue_TextChangedFilterForPersonID(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text))
            {
                _FilterUsersTable("");
                return;
            }
            _FilterUsersTable($"[Person ID] = {Convert.ToString(txbFilterValue.Text)}");
        }

        private void txbFilterValue_TextChangedFilterForFullName(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text))
            {
                _FilterUsersTable("");
                return;
            }
            _FilterUsersTable($"[Full Name] LIKE '{Convert.ToString(txbFilterValue.Text)}%'");
        }

        private void txbFilterValue_TextChangedFilterForUserName(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFilterValue.Text))
            {
                _FilterUsersTable("");
                return;
            }
            _FilterUsersTable($"[UserName] LIKE '{Convert.ToString(txbFilterValue.Text)}%'");
        }
        private void cmbxAccountStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = Convert.ToString(cmbxAccountStatus.SelectedItem);
            if (SelectedItem == "Active")
                _FilterUsersTable("isActive = 1");

            else if (SelectedItem == "Inactive")
                _FilterUsersTable("isActive = 0");

            else
                _FilterUsersTable("");
        }

        private void _RefreshUsersTable()
        {
            UsersTable = clsUser.GetAllUsersTable();
            dgvUsersTable.DataSource = UsersTable;
        }

        private void KeyPress_HandleNoneDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void _NotImplenmentedMessage()
        {
            MessageBox.Show("This Feature Is not implemented yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersTable();
        }

        private void dgvUsersTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalPeopleInTable.Text = dgvUsersTable.Rows.Count.ToString();
        }

        private void dgvUsersTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalPeopleInTable.Text = dgvUsersTable.Rows.Count.ToString();
        }

        // Not Implemented Method that open the form of adding new Person
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form AddNewUserForm = new frmAddEditUser(-1);
            AddNewUserForm.ShowDialog();
            _RefreshUsersTable();
        }

        //When Changing the Filter type From the DropMenu this method handles the event and set an approperiate field by which to search
        private void cmbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedFilterType = Convert.ToString(cmbxFilterType.SelectedItem);

            //Unsubscribe all the method handlers that might have been subscribed to events before
            txbFilterValue.KeyPress -= KeyPress_HandleNoneDigits;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedFilterForUserID;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedFilterForPersonID;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedFilterForFullName;
            txbFilterValue.TextChanged -= txbFilterValue_TextChangedFilterForUserName;
            cmbxAccountStatus.SelectedIndexChanged -= cmbxAccountStatus_SelectedIndexChanged;
            cmbxAccountStatus.Visible = false;
            txbFilterValue.Visible = false;


            if (SelectedFilterType == "None")
            {
                _FilterUsersTable("");
                return;
            }

            if(SelectedFilterType == "Status")
            {
                cmbxAccountStatus.Visible = true;
                cmbxAccountStatus.SelectedIndexChanged += cmbxAccountStatus_SelectedIndexChanged;
                return;
            }


            txbFilterValue.Visible = true;
            txbFilterValue.Text = "";
            if (SelectedFilterType == "Person ID" || SelectedFilterType == "User ID")
            {
                txbFilterValue.KeyPress += KeyPress_HandleNoneDigits;
                if (SelectedFilterType == "User ID")
                    txbFilterValue.TextChanged += txbFilterValue_TextChangedFilterForUserID;
                else
                    txbFilterValue.TextChanged += txbFilterValue_TextChangedFilterForPersonID;
                return;
            }

            if(SelectedFilterType == "Full Name")
            {
                txbFilterValue.TextChanged += txbFilterValue_TextChangedFilterForFullName;
                return;
            }

            if(SelectedFilterType == "UserName")
            {
                txbFilterValue.TextChanged += txbFilterValue_TextChangedFilterForUserName;
                return;
            }

        }

        //Not Implemented Method That shows User Details
        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dgvUsersTable.SelectedRows.Count == 0)
                return;
            int.TryParse(dgvUsersTable.SelectedRows[0].Cells[0].Value.ToString(), out int UserID);

            Form UserDetailsForm = new frmUserInfo(UserID);
            UserDetailsForm.ShowDialog();
            _RefreshUsersTable();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.SelectedRows.Count == 0)
                return;

            Form EditUserForm = new frmAddEditUser(int.Parse(dgvUsersTable.SelectedRows[0].Cells[0].Value.ToString()));
            EditUserForm.ShowDialog();
            _RefreshUsersTable();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _RefreshUsersTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.SelectedRows.Count == 0) return;
            var Result = MessageBox.Show("Are You Sure You Want To Delete This User", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                clsUser.DeleteUser(int.Parse(dgvUsersTable.SelectedRows[0].Cells[0].Value.ToString()));
                _RefreshUsersTable();
            }
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersTable.SelectedRows.Count == 0) return;
            int.TryParse(dgvUsersTable.SelectedRows[0].Cells[0].Value.ToString(), out int UserID);
            Form ChangePasswordForm = new frmChangeUserPassword(UserID);
            ChangePasswordForm.Show();
        }

        //Not Implemented Method That shows User Details
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotImplenmentedMessage();
        }
        //Not Implemented Method That shows User Details
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NotImplenmentedMessage();
        }

    }
}
