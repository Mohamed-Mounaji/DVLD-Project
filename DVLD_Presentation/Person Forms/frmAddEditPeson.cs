using System;
using System.Drawing;
using System.Windows.Forms;
using DVLD_Business;
using System.IO;
using System.Text.RegularExpressions;

namespace DVLD_Presentation
{
    public partial class frmAddEditPeson : Form
    {

        private enum _enMode { AddNew, Update}
        private _enMode _Mode;
        private clsPerson _PersonInfo;
        public frmAddEditPeson(int PersonID)
        {
            InitializeComponent();
            _PersonInfo = clsPerson.Find(PersonID);
            if( _PersonInfo == null )
            {
                _PersonInfo = new clsPerson();
                _Mode = _enMode.AddNew;
            }
            else
                _Mode = _enMode.Update;

            _FillComboBoxWithCountries();
            _FillFormFields();
        }

        public delegate void PersonAdded(int PersonID);
        public event PersonAdded OnPersonAdded;

        private string _CopyImageToSystemImagesFolder(string ImagePath)
        {
            string Exstension = Path.GetExtension(ImagePath);
            string DestPath = $@"C:\Course19_ProfilePictures\{Guid.NewGuid()}{Exstension}";

            File.Copy(ImagePath, DestPath);
            return DestPath;
        }

        private void _FillComboBoxWithCountries()
        {
            cbxCountry.DataSource = clsCountry.GetAllCountries();
            cbxCountry.DisplayMember = "CountryName";
            cbxCountry.ValueMember = "CountryID";
            cbxCountry.SelectedIndex = 119 - 1;
        }

        private void _FillForNewPerson()
        {
            lblTitle.Text = "Add New Person";
            lblPersonID.Text = "N/A";
            rbtnMale.Checked = true;
            pbxProfilePicture.Image = Properties.Resources.DefaultMaleProfile;
        }   

        private void _FillForExistingPerson()
        {
            lblTitle.Text = "Edit Person Info.";
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            txbFirstName.Text = _PersonInfo.FirstName;
            txbSecondName.Text = _PersonInfo.SecondName;
            txbThirdName.Text = _PersonInfo.ThirdName;
            txbLastName.Text = _PersonInfo.LastName;
            txbNationalNumber.Text = _PersonInfo.NationalNumber;
            dtpDateOfBirth.Value = _PersonInfo.DateOfBirth;
            if (_PersonInfo.Gender)
                rbtnFemale.Checked = true;
            else
                rbtnMale.Checked = true;
            txbPhone.Text = _PersonInfo.Phone;
            txbAddress.Text = _PersonInfo.Address;
            txbEmail.Text = _PersonInfo.Email;
            if (_PersonInfo.ImagePath == "")
                _SetDefaultProfileImage();
            else
                pbxProfilePicture.ImageLocation = _PersonInfo.ImagePath;
        }

        private void _FillFormFields()
        {
            if (_Mode == _enMode.AddNew)
                _FillForNewPerson();
            else
                _FillForExistingPerson();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialogForProfile.Filter = "JPEG files (*.jpg; *.jpeg)|*.jpg;*.jpeg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialogForProfile.ShowDialog() == DialogResult.OK)
            {
                pbxProfilePicture.ImageLocation = openFileDialogForProfile.FileName;
                pbxProfilePicture.Tag = "HasImage";
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetDefaultProfileImage()
        {
            if (Convert.ToString(pbxProfilePicture.Tag) != "HasImage")
            {
                if (rbtnMale.Checked)
                    pbxProfilePicture.Image = Properties.Resources.DefaultMaleProfile;
                else
                    pbxProfilePicture.Image = Properties.Resources.DefaultFemaleProfile;
            }
        }

        private void GenderRadio_CheckedChanged(object sender, EventArgs e)
        {
            _SetDefaultProfileImage();
        }

        private void _LoadPersonInfoToObject()
        {
            _PersonInfo.FirstName = txbFirstName.Text;
            _PersonInfo.SecondName = txbSecondName.Text;
            _PersonInfo.ThirdName = txbThirdName.Text;
            _PersonInfo.LastName = txbLastName.Text;
            _PersonInfo.NationalNumber = txbNationalNumber.Text;
            _PersonInfo.Gender = !rbtnMale.Checked;
            _PersonInfo.Phone = txbPhone.Text;
            _PersonInfo.Address = txbAddress.Text;
            _PersonInfo.Email = txbEmail.Text;
            _PersonInfo.DateOfBirth = dtpDateOfBirth.Value;
            _PersonInfo.NationalityCountryID = Convert.ToInt16(cbxCountry.SelectedValue) ;
            if (Convert.ToString(pbxProfilePicture.Tag) == "HasImage")
            {
                _PersonInfo.ImagePath = _CopyImageToSystemImagesFolder(pbxProfilePicture.ImageLocation);

            }
            else
                _PersonInfo.ImagePath = "";
        }

        private void SetErrorForEmptyTextBox(object sender, EventArgs e)
        {
            TextBox Field = (TextBox)sender;
            if (string.IsNullOrEmpty(Field.Text))
            {
                errorProvider1.SetError(Field, "Filed Must NOT be Empty");
                Field.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save the changes", "Validate", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                _LoadPersonInfoToObject();
                if (_PersonInfo.Save())
                {
                    MessageBox.Show("Person Info was saved Successfully");
                    OnPersonAdded ?.Invoke(_PersonInfo.PersonID);
                    _FillForExistingPerson();
                }
                else
                    MessageBox.Show("Person Info was not saved");
            }
        }

        private void llblRemovePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbxProfilePicture.Tag = "";
            _SetDefaultProfileImage();
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((!char.IsDigit(e.KeyChar) || txbPhone.Text.Length >=  20)  && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txbEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && !string.IsNullOrEmpty(txbEmail.Text))
            {
                errorProvider1.SetError(txbEmail, "Invalid Email Pattern");
                txbEmail.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void txbNationalNumber_Validated(object sender, EventArgs e)
        {
            SetErrorForEmptyTextBox(sender, e);

           if(_Mode == _enMode.AddNew)
            { 
                if (clsPerson.isNationalNumberExist(txbNationalNumber.Text))
                {
                    errorProvider1.SetError(txbNationalNumber, "National Number Already Exists");
                    txbNationalNumber.Focus();
                }
                 else if (!string.IsNullOrEmpty(txbNationalNumber.Text))
                    errorProvider1.Clear();
            }
            else
            {
                if (clsPerson.isNationalNumberExist(txbNationalNumber.Text, _PersonInfo.PersonID))
                {
                    errorProvider1.SetError(txbNationalNumber, "National Number Already Exists");
                    txbNationalNumber.Focus();
                }
                else if (!string.IsNullOrEmpty(txbNationalNumber.Text))
                    errorProvider1.Clear();
            }

            //if (!string.IsNullOrEmpty(txbNationalNumber.Text))
            //    errorProvider1.Clear();

        }
    }
}