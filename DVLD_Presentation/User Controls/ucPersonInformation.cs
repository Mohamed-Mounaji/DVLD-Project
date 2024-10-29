using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class ucPersonInformation : UserControl
    {
        private int _PersonID = -1;

        public ucPersonInformation()
        {
            InitializeComponent();
        }

        public void ResetFields()
        {
            lblPersonID.Text = "N/A";
            lblFullName.Text = "N/A";
            lblNationalNumber.Text = "N/A";
            lblEmail.Text = "N/A";
            lblPhone.Text = "N/A";
            lblGender.Text = "N/A";
            lblAddress.Text = "N/A";
            lblDateOfBirth.Text = "N/A";
            lblCountry.Text = "N/A";
            pbxPersonProfile.Image = null;
        }

        private void _SetDefaultImageProfile(bool Gender)
        {
            if (Gender)
                pbxPersonProfile.Image = Properties.Resources.DefaultFemaleProfile;
            else
                pbxPersonProfile.Image = Properties.Resources.DefaultMaleProfile;
        }

        private void _RefreshPersonInfo()
        {
            clsPerson PersonInfo = clsPerson.Find(_PersonID);
            lblPersonID.Text = PersonInfo.PersonID.ToString();
            lblFullName.Text = PersonInfo.FullName();
            lblNationalNumber.Text = PersonInfo.NationalNumber;
            lblGender.Text = PersonInfo.Gender ? "Female" : "Male";
            lblEmail.Text = PersonInfo.Email;
            lblAddress.Text = PersonInfo.Address;
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
            lblPhone.Text = PersonInfo.Phone;
            lblCountry.Text = clsCountry.GetCountryName(PersonInfo.NationalityCountryID);
            if (!string.IsNullOrEmpty(PersonInfo.ImagePath))
                pbxPersonProfile.ImageLocation = PersonInfo.ImagePath;
            else
                _SetDefaultImageProfile(PersonInfo.Gender);
        }

        private void LinkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID == -1)
                return;
            Form EditPersonForm = new frmAddEditPeson(_PersonID);
            EditPersonForm.ShowDialog();
            _RefreshPersonInfo();
        }

        public bool LoadPersonData(int PersonID)
        {
            if(!clsPerson.isPersonExists(PersonID))
            {
                _PersonID = -1;
                ResetFields();
                return false;
            }
            _PersonID = PersonID;
            _RefreshPersonInfo();
            return true;
        }

        public bool LoadPersonData(string NationalNumber)
        {
            clsPerson Person = clsPerson.Find(NationalNumber);
            if (Person == null)
            {
                _PersonID = -1;
                ResetFields();
                return false;
            }
            _PersonID = Person.PersonID;
            _RefreshPersonInfo();
            return true;
        }

        private void lblEmail_MouseEnter(object sender, System.EventArgs e)
        {
            lblEmail.AutoSize = true;
            lblEmail.BorderStyle = BorderStyle.FixedSingle;
        }

        private void lblEmail_MouseLeave(object sender, System.EventArgs e)
        {
            lblEmail.AutoSize = false;
            lblEmail.BorderStyle = BorderStyle.None;
        }
    }
}
