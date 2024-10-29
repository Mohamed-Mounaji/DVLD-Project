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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Presentation
{
    public partial class frmAddEditUser : Form
    {
        private enum _enMode { AddNew, Update }
        private _enMode _Mode;
        private clsUser _UserInfo;
        private int _SelectedPersonID = -1;

        private void _ResetFieldForNewUser()
        {
            ucFilterPerson1.FilteringBox.Enabled = true;
            this.Text = lblTitle.Text = "Add New User";
            ucFilterPerson1.ucPersonInformation1.LoadPersonData(-1);            
        }

        private void _FillFieldsForUpdatingUser()
        {
            ucFilterPerson1.FilteringBox.Enabled = false;
            this.Text = lblTitle.Text = "Update User";
            ucFilterPerson1.ucPersonInformation1.LoadPersonData(_UserInfo.PersonID);
            txbUserName.Text = _UserInfo.UserName;
            txbPassword.Text = txbConfirmPassword.Text = _UserInfo.Password;
            chbIsActive.Checked = _UserInfo.isActive;
            lblUserID.Text = _UserInfo.UserID.ToString();
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            if (UserID == -1 || clsUser.Find(UserID) == null)
            {
                _Mode = _enMode.AddNew;
                _UserInfo = new clsUser();
                _ResetFieldForNewUser();
            }
            else
            {
                _UserInfo = clsUser.Find(UserID);
                _SelectedPersonID = _UserInfo.PersonID;
                _Mode = _enMode.Update;
                _FillFieldsForUpdatingUser();
            }
        }

        private void _ShowErrorMessageBox(string Text)
        {
            MessageBox.Show(Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TextBox_ValidatedForEmpty(object sender, EventArgs e)
        {
            TextBox Field = sender as TextBox;
            if (string.IsNullOrEmpty(Field.Text) || string.IsNullOrWhiteSpace(Field.Text))
            {
                errorProvider1.SetError(Field, "User Name can't be blank");
                Field.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txbConfirmPassword_Validated(object sender, EventArgs e)
        {
            if(txbConfirmPassword.Text != txbPassword.Text)
            {
                errorProvider1.SetError(txbConfirmPassword, "Passwords do not match. Please try again");
                txbConfirmPassword.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == _enMode.Update)
            {
                AddNewUserTabControl.SelectedIndex = 1;
                return;
            }
            if (_SelectedPersonID == -1)
                MessageBox.Show("Please Choose A person to link the user with!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (clsPerson.isAUser(_SelectedPersonID))
                MessageBox.Show("Selected Person is already linked with a user, choose another one!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                AddNewUserTabControl.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucFilterPerson1_PersonFound(clsPerson PersonInfo)
        {
            _SelectedPersonID = PersonInfo.PersonID;
        }


        private void _SaveAsNewUser()
        {
            if (_SelectedPersonID == -1)
            {
                _ShowErrorMessageBox("Can't Save, Choose a Person to link the user with");
                AddNewUserTabControl.SelectedIndex = 0;
                return;
            }

            if (clsPerson.isAUser(_SelectedPersonID))
            {
                _ShowErrorMessageBox("The selected person is already a user.\n Choose another one");
                AddNewUserTabControl.SelectedIndex = 0;
                return;
            }

            if (string.IsNullOrWhiteSpace(txbUserName.Text) ||
                string.IsNullOrWhiteSpace(txbPassword.Text) ||
                string.IsNullOrWhiteSpace(txbConfirmPassword.Text) ||
                txbConfirmPassword.Text != txbPassword.Text)
            {
                _ShowErrorMessageBox("Incomplete or incorrect login info. Please try again!");
                AddNewUserTabControl.SelectedIndex = 1;
                return;
            }
            
            _UserInfo.PersonID = _SelectedPersonID;
            _UserInfo.UserName = txbUserName.Text;
            _UserInfo.Password = txbPassword.Text;
            _UserInfo.isActive = chbIsActive.Checked;
            if (_UserInfo.Save())
            {
                _Mode = _enMode.Update;
                lblUserID.Text = _UserInfo.UserID.ToString();
                lblTitle.Text = "Update User";
                MessageBox.Show("User was saved successfully");
            }
            else
                MessageBox.Show("User was not saved");
        }

        private void _SaveUpdates()
        {
            if (string.IsNullOrWhiteSpace(txbUserName.Text) ||
                string.IsNullOrWhiteSpace(txbPassword.Text) ||
                string.IsNullOrWhiteSpace(txbConfirmPassword.Text) ||
                txbConfirmPassword.Text != txbPassword.Text)
            {
                _ShowErrorMessageBox("Incomplete or incorrect login info. Please try again!");
                AddNewUserTabControl.SelectedIndex = 1;
                return;
            }



            
            _UserInfo.UserName = txbUserName.Text;
            _UserInfo.Password = txbPassword.Text;
            _UserInfo.isActive = chbIsActive.Checked;
            if (_UserInfo.Save())
                MessageBox.Show("User was saved successfully");
            else
                MessageBox.Show("User was not saved");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Save ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_Mode == _enMode.AddNew)
                    _SaveAsNewUser();
                else
                    _SaveUpdates();
            }
        }
    }
}
