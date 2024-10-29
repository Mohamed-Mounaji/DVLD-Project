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

namespace DVLD_Presentation
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType _TestTypeInfo;
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeInfo = clsTestType.Find(TestTypeID);
            _FillFieldsFromTheObject();
        }

        private void _FillFieldsFromTheObject()
        {
            if (_TestTypeInfo == null) return;
            lblTestTypeID.Text = _TestTypeInfo.TestTypeID.ToString();
            txbTitle.Text = _TestTypeInfo.TestTypeTitle;
            txbDescription.Text = _TestTypeInfo.TestTypeDescription;
            txbFees.Text = _TestTypeInfo.TestTypeFees.ToString();
        }

        private void _LoadFieldsToObject()
        {
            if (_TestTypeInfo == null) return;

            _TestTypeInfo.TestTypeTitle = txbTitle.Text;
            _TestTypeInfo.TestTypeDescription = txbDescription.Text;
            _TestTypeInfo.TestTypeFees = Convert.ToDouble(txbFees.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_ValidatingEmptyOrWhiteSpace(object sender, EventArgs e)
        {
            TextBox Field = (TextBox)sender;
            if(string.IsNullOrWhiteSpace(Field.Text))
            {
                errorProvider1.SetError(Field, "Field can not be blank!");
                Field.Focus();
            }
        }

        private void txbFees_Validating(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbTitle.Text) || string.IsNullOrWhiteSpace(txbDescription.Text) || string.IsNullOrWhiteSpace(txbFees.Text))
                return;

            _LoadFieldsToObject();
            if (_TestTypeInfo.Save())
                MessageBox.Show("Test Type Info was saved successfully !!");
            else
                MessageBox.Show("Test Type Info was not saved !!");
        }
    }
}
