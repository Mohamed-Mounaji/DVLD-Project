using DVLD_Business;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms;
using Microsoft.Win32;

namespace DVLD_Presentation
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void _SaveLoginInfo()
        {

            string LoginInfo = chbRememberME.Checked ? txbUserName.Text + "#//#" + txbPassword.Text: "";

            string KeyPath = "HKEY_CURRENT_USER\\SOFTWARE\\KeyForTest";
            try
            {
                Registry.SetValue(KeyPath, "LoginInfo", LoginInfo, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurs while saving the data: '{ex.Message}'.");
            }
        }

        private void _LoadSavedLoginInfo()
        {

            string KeyPath = "HKEY_CURRENT_USER\\SOFTWARE\\KeyForTest";
            string result;

            try
            {
                result = Registry.GetValue(KeyPath, "LoginInfo", null) as string;
                if (string.IsNullOrWhiteSpace(result))
                {
                    txbUserName.Text = "";
                    txbPassword.Text = "";
                    return;
                }
                string[] Delemeter = new string[] { "#//#" };
                string[] LoginInfo = result.Split(Delemeter, StringSplitOptions.None);

                txbUserName.Text = LoginInfo[0];
                txbPassword.Text = LoginInfo[1];

            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Error occured while loading the login info: '{ex.Message}.");
            }
        }

        private void frmLoginScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                _LoadSavedLoginInfo();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.isUserExists(txbUserName.Text, txbPassword.Text))
            {
                if (clsUser.isUserActive(txbUserName.Text))
                {
                    _SaveLoginInfo();
                    clsGlobal.CurrUserID = clsUser.GetUserID(txbUserName.Text);
                    this.Hide();
                    Form MainScreenForm = new frmMainScreen(this);
                    MainScreenForm.Show();
                }
                else
                    MessageBox.Show("Your Acount is blocked. Please contact the admin!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("UserName/Password is wrong. Please try again!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TextBox_ValidatingNulAndWhiteSpace(object sender, CancelEventArgs e)
        {
            Guna2TextBox Field = (Guna2TextBox)sender;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(Field.Text))
            {
                errorProvider1.SetError(Field, "Field can not be blank");
                e.Cancel = true;
            }
        }

      
        private void btnShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (btnShowPassword.Checked)
                txbPassword.PasswordChar = '\0';
            else
                txbPassword.PasswordChar = '*';
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            btnShowPassword.Checked ^= true;
        }
    }
}
