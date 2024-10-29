using System.Windows.Forms;

namespace DVLD_Presentation
{
    public enum enApplicationStatus { New = 1, Cancelled=2, Completed=3}
    public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3}
    enum enIssueReason { FirstTime = 1, Renew, ReplacementForDamaged, ReplacementForLost}

    enum enApplicationTypes { NewLocalLicense = 1, RenewLocalLicense, ReplacementForLostLicense, ReplacementForDamagedLicense, ReleaseDetainedLicense, NewInternationalLicense}

    internal static class clsGlobal
    {
        public static int CurrUserID =1;
        public const string LoginInfoFile = @"C:\MyFiles\DVLD_LoginInfo.txt"; 
        public static void NotImplementedMessageBox()
        {
            MessageBox.Show("This Feature is not implemented yet!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
       
    }
}
