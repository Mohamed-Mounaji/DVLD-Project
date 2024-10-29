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
    public partial class ucInternationalLicenseInfo : UserControl
    {
        public ucInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (InternationalLicense == null) return;

            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = InternationalLicense.IssuedUsingLocalDrivingLicenseID.ToString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblDriverID.Text = InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();

            clsPerson PersonInfo = clsPerson.FindByDriverID(InternationalLicense.DriverID);
            if (PersonInfo == null) return;
            lblName.Text = PersonInfo.FullName();
            lblNationalNumber.Text = PersonInfo.NationalNumber;
            lblGender.Text = PersonInfo.Gender ? "Female" : "Male";
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
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
    }
}
