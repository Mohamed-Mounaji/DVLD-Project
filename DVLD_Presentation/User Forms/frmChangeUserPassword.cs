using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmChangeUserPassword : Form
    {
        private int _UserID;
        bool ShouldClose = false;
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            if (!clsUser.isUserExists(UserID))
            {
                ShouldClose = true;
                return;
            }
            _UserID = UserID;
            ucUserInformation1.LoadUserInfo(UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangeUserPassword_Shown(object sender, EventArgs e)
        {
            if (ShouldClose)
                this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(txbNewPassword.Text != txbPasswordConfirmation.Text)
            {
                errorProvider1.SetError(txbPasswordConfirmation, "Password do not match, Please try again");
                return;
            }

            if(string.IsNullOrWhiteSpace(txbNewPassword.Text ))
            {
                errorProvider1.SetError(txbNewPassword, "Invalid Password");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPasswordConfirmation.Text))
            {
                errorProvider1.SetError(txbPasswordConfirmation, "Invalid Password");
                return;
            }


            var result = MessageBox.Show("Are You sure want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (clsUser.UpdatePassword(_UserID, txbCurrPassword.Text, txbNewPassword.Text))
                    MessageBox.Show("Password is Updated Successfully");
                else
                    MessageBox.Show("Password was not Updated");
            }
        }

        private void TextBox_ValidatedEmpyAndWhiteSpace(object sender, EventArgs e)
        {
            TextBox Field = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(Field.Text))
            {
                errorProvider1.SetError(Field, "Field Must not be blank");
                Field.Focus();
            }
            else
                errorProvider1.Clear();
        }
    }
}
