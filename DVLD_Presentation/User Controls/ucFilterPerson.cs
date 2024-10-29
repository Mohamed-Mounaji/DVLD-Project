using System;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Presentation.User_Controls
{
    public partial class ucFilterPerson : UserControl
    {
        public ucFilterPerson()
        {
            InitializeComponent();
        }

        public delegate void FilterPerson_PersonFoundEventHandler(clsPerson PersonInfo);

        public event FilterPerson_PersonFoundEventHandler PersonFound;

        public void onPersonFound(clsPerson Person)
        {
            if(PersonFound  != null)
            {
                PersonFound(Person);
            }
        }

        private void ucFilterPerson_Load(object sender, EventArgs e)
        {
            cmbxFilterType.SelectedIndex = 0;
        }
        private void txbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void _LoadPersonInfo(int PersonID)
        {
            if (ucPersonInformation1.LoadPersonData(PersonID))
            {
                // raise the event that I have found the person
                onPersonFound(clsPerson.Find(PersonID));
            }
            else
            {
                MessageBox.Show($"Person With ID '{PersonID}' Does not Exist in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchByPersonID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFilterValue.Text)) return;
            int PersonID = Convert.ToInt32(txbFilterValue.Text);
            _LoadPersonInfo(PersonID);
           
        }

        private void btnSearchByNationalNum_Click(object sender, EventArgs e)
        {
            string NationalNumber = txbFilterValue.Text;
            if (ucPersonInformation1.LoadPersonData(NationalNumber))
            {
                // raise the event that I have found the person
                onPersonFound(clsPerson.Find(NationalNumber));
            }
            else
            {
                MessageBox.Show($"Person With National Number '{NationalNumber}' Does not Exist in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPersonForm_OnPersonAdded(int PersonID)
        {
            _LoadPersonInfo(PersonID);
        }

        private void cmbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedItem = Convert.ToString(cmbxFilterType.SelectedItem);
            btnSearch.Click -= btnSearchByPersonID_Click;
            btnSearch.Click -= btnSearchByNationalNum_Click;
            txbFilterValue.KeyPress -= txbFilterValue_KeyPress;

            txbFilterValue.Text = "";
            if (SelectedItem == "Person ID")
            {
                txbFilterValue.KeyPress += txbFilterValue_KeyPress;
                btnSearch.Click += btnSearchByPersonID_Click;
            }
            else
                btnSearch.Click += btnSearchByNationalNum_Click;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditPeson AddPersonForm = new frmAddEditPeson(-1);
            AddPersonForm.OnPersonAdded += AddPersonForm_OnPersonAdded; 
            AddPersonForm.Show();
        }
    }
}
