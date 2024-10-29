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
    public partial class ucUserInformation : UserControl
    {
        public ucUserInformation()
        {
            InitializeComponent();
        }

        private void _ResetFields()
        {
            ucPersonInformation1.ResetFields();
            lblIsActive.Text = "N/A";
            lblUserId.Text = "N/A";
            lblUserName.Text = "N/A";
        }

       public bool LoadUserInfo(int UserID)
        {
            if(!clsUser.isUserExists(UserID))
            {
                _ResetFields();
                return false;
            }

            clsUser UserInfo = clsUser.Find(UserID);
            ucPersonInformation1.LoadPersonData(UserInfo.PersonID);
            lblUserName.Text = UserInfo.UserName;
            lblUserId.Text = UserInfo.UserID.ToString();
            lblIsActive.Text = UserInfo.isActive ? "Yes" : "No";
            return true;
        }
    }
}
