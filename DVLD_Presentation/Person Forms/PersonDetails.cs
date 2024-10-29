using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            ucPersonInformation1.LoadPersonData(personID);
        }

        public frmPersonDetails(string nationalNumber)
        {
            InitializeComponent();
            ucPersonInformation1.LoadPersonData(nationalNumber);
        }

        private void btnClose2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
