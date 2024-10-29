using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmUpdateApplicationType : Form
    {
         private clsApplicationType _AppTypeInfo;
         public frmUpdateApplicationType(int ApplicationTypeID)
         {
            InitializeComponent();
            _AppTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            _LoadApplicationTypeInfo();
         }

        private void _LoadApplicationTypeInfo()
        {
            if (_AppTypeInfo != null)
            {
                lblAppTypeID.Text = _AppTypeInfo.ApplicationTypeID.ToString();
                txbTitle.Text = _AppTypeInfo.ApplicationTypeTitle;
                txbFees.Text = _AppTypeInfo.ApplicationFees.ToString();
            }
        }

        private void _LoadFieldToAppTypeInfoObject()
        {
            if(_AppTypeInfo != null)
            {
                _AppTypeInfo.ApplicationTypeTitle = txbTitle.Text;
                _AppTypeInfo.ApplicationFees = Convert.ToDouble(txbFees.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbTitle.Text) || string.IsNullOrWhiteSpace(txbFees.Text)) return;
            _LoadFieldToAppTypeInfoObject();

            if (_AppTypeInfo.Save())
                MessageBox.Show("Changes was saved successfully :)");
            else
                MessageBox.Show("Changes was not saved");
        }

        private void txbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox_ValidatedForBlank(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            TextBox Field = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(Field.Text))
            { 
                errorProvider1.SetError(Field, "Filed can not be blank!");
                Field.Focus();
            }
        }
    }
}
