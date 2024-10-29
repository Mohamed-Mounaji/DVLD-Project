namespace DVLD_Presentation.Licenses_Forms
{
    partial class frmRenewLicense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gbApplicationInformation = new System.Windows.Forms.GroupBox();
            this.txbNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblExpiredLicenseID = new System.Windows.Forms.Label();
            this.lblNewLicenseID = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIssue = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.linkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.linkShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ucFilterLicense1 = new DVLD_Presentation.User_Controls.ucFilterLicense();
            this.gbApplicationInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 15F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(844, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Renew Local Driving License ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbApplicationInformation
            // 
            this.gbApplicationInformation.Controls.Add(this.txbNotes);
            this.gbApplicationInformation.Controls.Add(this.label2);
            this.gbApplicationInformation.Controls.Add(this.lblTotalFees);
            this.gbApplicationInformation.Controls.Add(this.lblLicenseFees);
            this.gbApplicationInformation.Controls.Add(this.label8);
            this.gbApplicationInformation.Controls.Add(this.label9);
            this.gbApplicationInformation.Controls.Add(this.lblCreatedByUser);
            this.gbApplicationInformation.Controls.Add(this.lblExpirationDate);
            this.gbApplicationInformation.Controls.Add(this.lblExpiredLicenseID);
            this.gbApplicationInformation.Controls.Add(this.lblNewLicenseID);
            this.gbApplicationInformation.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInformation.Controls.Add(this.lblIssueDate);
            this.gbApplicationInformation.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInformation.Controls.Add(this.lblApplicationID);
            this.gbApplicationInformation.Controls.Add(this.label10);
            this.gbApplicationInformation.Controls.Add(this.label11);
            this.gbApplicationInformation.Controls.Add(this.label12);
            this.gbApplicationInformation.Controls.Add(this.label13);
            this.gbApplicationInformation.Controls.Add(this.label6);
            this.gbApplicationInformation.Controls.Add(this.label5);
            this.gbApplicationInformation.Controls.Add(this.label4);
            this.gbApplicationInformation.Controls.Add(this.label3);
            this.gbApplicationInformation.Enabled = false;
            this.gbApplicationInformation.Location = new System.Drawing.Point(39, 400);
            this.gbApplicationInformation.Name = "gbApplicationInformation";
            this.gbApplicationInformation.Size = new System.Drawing.Size(765, 237);
            this.gbApplicationInformation.TabIndex = 2;
            this.gbApplicationInformation.TabStop = false;
            this.gbApplicationInformation.Text = "Application Information";
            // 
            // txbNotes
            // 
            this.txbNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbNotes.DefaultText = "";
            this.txbNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbNotes.DisabledState.Parent = this.txbNotes;
            this.txbNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbNotes.FocusedState.Parent = this.txbNotes;
            this.txbNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbNotes.HoverState.Parent = this.txbNotes;
            this.txbNotes.Location = new System.Drawing.Point(163, 171);
            this.txbNotes.Multiline = true;
            this.txbNotes.Name = "txbNotes";
            this.txbNotes.PasswordChar = '\0';
            this.txbNotes.PlaceholderText = "";
            this.txbNotes.SelectedText = "";
            this.txbNotes.ShadowDecoration.Parent = this.txbNotes;
            this.txbNotes.Size = new System.Drawing.Size(505, 51);
            this.txbNotes.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label2.Location = new System.Drawing.Point(81, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 53;
            this.label2.Text = "Notes : ";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblTotalFees.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalFees.Location = new System.Drawing.Point(615, 142);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(53, 19);
            this.lblTotalFees.TabIndex = 52;
            this.lblTotalFees.Text = "[ ? ? ? ]";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblLicenseFees.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLicenseFees.Location = new System.Drawing.Point(160, 142);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(53, 19);
            this.lblLicenseFees.TabIndex = 51;
            this.lblLicenseFees.Text = "[ ? ? ? ]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label8.Location = new System.Drawing.Point(516, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = "Total Fees :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label9.Location = new System.Drawing.Point(41, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 19);
            this.label9.TabIndex = 49;
            this.label9.Text = "License Fees :";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblCreatedByUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCreatedByUser.Location = new System.Drawing.Point(615, 111);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(53, 19);
            this.lblCreatedByUser.TabIndex = 48;
            this.lblCreatedByUser.Text = "[ ? ? ? ]";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblExpirationDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblExpirationDate.Location = new System.Drawing.Point(615, 81);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(53, 19);
            this.lblExpirationDate.TabIndex = 47;
            this.lblExpirationDate.Text = "[ ? ? ? ]";
            // 
            // lblExpiredLicenseID
            // 
            this.lblExpiredLicenseID.AutoSize = true;
            this.lblExpiredLicenseID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblExpiredLicenseID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblExpiredLicenseID.Location = new System.Drawing.Point(615, 51);
            this.lblExpiredLicenseID.Name = "lblExpiredLicenseID";
            this.lblExpiredLicenseID.Size = new System.Drawing.Size(53, 19);
            this.lblExpiredLicenseID.TabIndex = 46;
            this.lblExpiredLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblNewLicenseID
            // 
            this.lblNewLicenseID.AutoSize = true;
            this.lblNewLicenseID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblNewLicenseID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNewLicenseID.Location = new System.Drawing.Point(615, 21);
            this.lblNewLicenseID.Name = "lblNewLicenseID";
            this.lblNewLicenseID.Size = new System.Drawing.Size(53, 19);
            this.lblNewLicenseID.TabIndex = 45;
            this.lblNewLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationFees.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApplicationFees.Location = new System.Drawing.Point(160, 111);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationFees.TabIndex = 44;
            this.lblApplicationFees.Text = "[ ? ? ? ]";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblIssueDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblIssueDate.Location = new System.Drawing.Point(160, 81);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(53, 19);
            this.lblIssueDate.TabIndex = 43;
            this.lblIssueDate.Text = "[ ? ? ? ]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApplicationDate.Location = new System.Drawing.Point(160, 51);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationDate.TabIndex = 42;
            this.lblApplicationDate.Text = "[ ? ? ? ]";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApplicationID.Location = new System.Drawing.Point(160, 21);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationID.TabIndex = 41;
            this.lblApplicationID.Text = "[ ? ? ? ]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label10.Location = new System.Drawing.Point(475, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "Created By User :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label11.Location = new System.Drawing.Point(478, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 19);
            this.label11.TabIndex = 39;
            this.label11.Text = "Expiration Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label12.Location = new System.Drawing.Point(460, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 19);
            this.label12.TabIndex = 38;
            this.label12.Text = "Expired License ID :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label13.Location = new System.Drawing.Point(482, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 19);
            this.label13.TabIndex = 37;
            this.label13.Text = "New License ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label6.Location = new System.Drawing.Point(14, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 19);
            this.label6.TabIndex = 36;
            this.label6.Text = "Application Fees :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label5.Location = new System.Drawing.Point(55, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 35;
            this.label5.Text = "Issue Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Application Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label3.Location = new System.Drawing.Point(30, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Applicatoin ID :";
            // 
            // btnIssue
            // 
            this.btnIssue.BorderRadius = 5;
            this.btnIssue.BorderThickness = 1;
            this.btnIssue.CheckedState.Parent = this.btnIssue;
            this.btnIssue.CustomImages.Parent = this.btnIssue;
            this.btnIssue.Enabled = false;
            this.btnIssue.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnIssue.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.btnIssue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIssue.HoverState.Parent = this.btnIssue;
            this.btnIssue.ImageSize = new System.Drawing.Size(18, 18);
            this.btnIssue.Location = new System.Drawing.Point(737, 644);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.ShadowDecoration.Parent = this.btnIssue;
            this.btnIssue.Size = new System.Drawing.Size(67, 29);
            this.btnIssue.TabIndex = 21;
            this.btnIssue.Text = "Issue";
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClose.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(655, 644);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(67, 29);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkShowLicensesHistory
            // 
            this.linkShowLicensesHistory.AutoSize = true;
            this.linkShowLicensesHistory.Font = new System.Drawing.Font("Open Sans", 10F);
            this.linkShowLicensesHistory.Location = new System.Drawing.Point(53, 652);
            this.linkShowLicensesHistory.Name = "linkShowLicensesHistory";
            this.linkShowLicensesHistory.Size = new System.Drawing.Size(157, 19);
            this.linkShowLicensesHistory.TabIndex = 22;
            this.linkShowLicensesHistory.TabStop = true;
            this.linkShowLicensesHistory.Text = "Show Licenses History";
            this.linkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesHistory_LinkClicked);
            // 
            // linkShowNewLicenseInfo
            // 
            this.linkShowNewLicenseInfo.AutoSize = true;
            this.linkShowNewLicenseInfo.Enabled = false;
            this.linkShowNewLicenseInfo.Font = new System.Drawing.Font("Open Sans", 10F);
            this.linkShowNewLicenseInfo.Location = new System.Drawing.Point(234, 652);
            this.linkShowNewLicenseInfo.Name = "linkShowNewLicenseInfo";
            this.linkShowNewLicenseInfo.Size = new System.Drawing.Size(170, 19);
            this.linkShowNewLicenseInfo.TabIndex = 23;
            this.linkShowNewLicenseInfo.TabStop = true;
            this.linkShowNewLicenseInfo.Text = "Show New Licenses Info";
            this.linkShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowNewLicenseInfo_LinkClicked);
            // 
            // ucFilterLicense1
            // 
            this.ucFilterLicense1.Location = new System.Drawing.Point(5, 43);
            this.ucFilterLicense1.Name = "ucFilterLicense1";
            this.ucFilterLicense1.Size = new System.Drawing.Size(832, 356);
            this.ucFilterLicense1.TabIndex = 1;
            this.ucFilterLicense1.OnLicenseFound += new DVLD_Presentation.User_Controls.ucFilterLicense.LicenseFound(this.ucFilterLicense1_OnPersonFound);
            // 
            // frmRenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 680);
            this.Controls.Add(this.linkShowNewLicenseInfo);
            this.Controls.Add(this.linkShowLicensesHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInformation);
            this.Controls.Add(this.ucFilterLicense1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.frmRenewLicense_Load);
            this.gbApplicationInformation.ResumeLayout(false);
            this.gbApplicationInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private User_Controls.ucFilterLicense ucFilterLicense1;
        private System.Windows.Forms.GroupBox gbApplicationInformation;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblExpiredLicenseID;
        private System.Windows.Forms.Label lblNewLicenseID;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txbNotes;
        private Guna.UI2.WinForms.Guna2Button btnIssue;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.LinkLabel linkShowLicensesHistory;
        private System.Windows.Forms.LinkLabel linkShowNewLicenseInfo;
    }
}