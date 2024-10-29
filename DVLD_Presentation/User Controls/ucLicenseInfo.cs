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

namespace DVLD_Presentation.User_Controls
{
    public partial class ucLicenseInfo : UserControl
    {
        public ucLicenseInfo()
        {
            InitializeComponent();
        }

        private void _FillFields(clsLicense licenseInfo)
        {
            int personID = clsDriver.Find(licenseInfo.DriverID).PersonID;
            clsPerson PersonInfo = clsPerson.Find(personID);

            lblClass.Text = clsLicenseClass.GetClassNameBy(licenseInfo.LicenseClassID);
            lblName.Text = PersonInfo.FullName();
            lblLicenseID.Text = licenseInfo.LicenseID.ToString();
            lblNationalNumber.Text = PersonInfo.NationalNumber;
            lblGender.Text = PersonInfo.Gender ? "Female" : "Male";
            lblIssueDate.Text = licenseInfo.IssueDate.ToShortDateString();
            lblIssueReason.Text = ((enIssueReason)licenseInfo.IssueReason).ToString();
            lblNotes.Text = string.IsNullOrEmpty( licenseInfo.Notes) ? "No Notes." : licenseInfo.Notes;
            lblIsActive.Text = licenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = licenseInfo.DriverID.ToString();
            lblExpirationDate.Text = licenseInfo.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = licenseInfo.IsActive ? "No" : "Yes";

            if(string.IsNullOrEmpty(PersonInfo.ImagePath))
            {
                if (PersonInfo.Gender)
                    ProfilePicture.Image = Properties.Resources.DefaultFemaleProfile;
                else
                    ProfilePicture.Image = Properties.Resources.DefaultMaleProfile;
            }
            else
                ProfilePicture.ImageLocation = PersonInfo.ImagePath;
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            clsLicense LicenseInfo = clsLicense.Find(LicenseID);
            if (LicenseInfo == null) return;

            _FillFields(LicenseInfo);
        }

    }
}
