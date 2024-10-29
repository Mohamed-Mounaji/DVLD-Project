namespace DVLD_Presentation.Licenses_Forms
{
    partial class frmDetainLicense
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
            this.components = new System.ComponentModel.Container();
            this.linkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gbDetainInfo = new System.Windows.Forms.GroupBox();
            this.txbFineFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucFilterLicense1 = new DVLD_Presentation.User_Controls.ucFilterLicense();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkShowLicenseInfo
            // 
            this.linkShowLicenseInfo.AutoSize = true;
            this.linkShowLicenseInfo.Enabled = false;
            this.linkShowLicenseInfo.Font = new System.Drawing.Font("Open Sans", 10F);
            this.linkShowLicenseInfo.Location = new System.Drawing.Point(234, 549);
            this.linkShowLicenseInfo.Name = "linkShowLicenseInfo";
            this.linkShowLicenseInfo.Size = new System.Drawing.Size(136, 19);
            this.linkShowLicenseInfo.TabIndex = 30;
            this.linkShowLicenseInfo.TabStop = true;
            this.linkShowLicenseInfo.Text = "Show Licenses Info";
            this.linkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowNewLicenseInfo_LinkClicked);
            // 
            // linkShowLicensesHistory
            // 
            this.linkShowLicensesHistory.AutoSize = true;
            this.linkShowLicensesHistory.Font = new System.Drawing.Font("Open Sans", 10F);
            this.linkShowLicensesHistory.Location = new System.Drawing.Point(53, 549);
            this.linkShowLicensesHistory.Name = "linkShowLicensesHistory";
            this.linkShowLicensesHistory.Size = new System.Drawing.Size(157, 19);
            this.linkShowLicensesHistory.TabIndex = 29;
            this.linkShowLicensesHistory.TabStop = true;
            this.linkShowLicensesHistory.Text = "Show Licenses History";
            this.linkShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicensesHistory_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.BorderRadius = 5;
            this.btnDetain.BorderThickness = 1;
            this.btnDetain.CheckedState.Parent = this.btnDetain;
            this.btnDetain.CustomImages.Parent = this.btnDetain;
            this.btnDetain.Enabled = false;
            this.btnDetain.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDetain.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.btnDetain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDetain.HoverState.Parent = this.btnDetain;
            this.btnDetain.ImageSize = new System.Drawing.Size(18, 18);
            this.btnDetain.Location = new System.Drawing.Point(737, 541);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.ShadowDecoration.Parent = this.btnDetain;
            this.btnDetain.Size = new System.Drawing.Size(67, 29);
            this.btnDetain.TabIndex = 28;
            this.btnDetain.Text = "Detain";
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
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
            this.btnClose.Location = new System.Drawing.Point(655, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(67, 29);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbDetainInfo
            // 
            this.gbDetainInfo.Controls.Add(this.txbFineFees);
            this.gbDetainInfo.Controls.Add(this.lblCreatedBy);
            this.gbDetainInfo.Controls.Add(this.lblLicenseID);
            this.gbDetainInfo.Controls.Add(this.lblDetainDate);
            this.gbDetainInfo.Controls.Add(this.lblDetainID);
            this.gbDetainInfo.Controls.Add(this.label12);
            this.gbDetainInfo.Controls.Add(this.label13);
            this.gbDetainInfo.Controls.Add(this.label5);
            this.gbDetainInfo.Controls.Add(this.label4);
            this.gbDetainInfo.Controls.Add(this.label3);
            this.gbDetainInfo.Enabled = false;
            this.gbDetainInfo.Location = new System.Drawing.Point(39, 417);
            this.gbDetainInfo.Name = "gbDetainInfo";
            this.gbDetainInfo.Size = new System.Drawing.Size(765, 116);
            this.gbDetainInfo.TabIndex = 26;
            this.gbDetainInfo.TabStop = false;
            this.gbDetainInfo.Text = "Detain Info";
            // 
            // txbFineFees
            // 
            this.txbFineFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFineFees.DefaultText = "";
            this.txbFineFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbFineFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbFineFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbFineFees.DisabledState.Parent = this.txbFineFees;
            this.txbFineFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbFineFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbFineFees.FocusedState.Parent = this.txbFineFees;
            this.txbFineFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbFineFees.HoverState.Parent = this.txbFineFees;
            this.txbFineFees.Location = new System.Drawing.Point(157, 81);
            this.txbFineFees.Name = "txbFineFees";
            this.txbFineFees.PasswordChar = '\0';
            this.txbFineFees.PlaceholderText = "";
            this.txbFineFees.SelectedText = "";
            this.txbFineFees.ShadowDecoration.Parent = this.txbFineFees;
            this.txbFineFees.Size = new System.Drawing.Size(162, 19);
            this.txbFineFees.TabIndex = 47;
            this.txbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFineFees_KeyPress);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblCreatedBy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCreatedBy.Location = new System.Drawing.Point(571, 51);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(53, 19);
            this.lblCreatedBy.TabIndex = 46;
            this.lblCreatedBy.Text = "[ ? ? ? ]";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblLicenseID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLicenseID.Location = new System.Drawing.Point(571, 21);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(53, 19);
            this.lblLicenseID.TabIndex = 45;
            this.lblLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblDetainDate.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDetainDate.Location = new System.Drawing.Point(153, 51);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(53, 19);
            this.lblDetainDate.TabIndex = 42;
            this.lblDetainDate.Text = "[ ? ? ? ]";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblDetainID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDetainID.Location = new System.Drawing.Point(153, 21);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(53, 19);
            this.lblDetainID.TabIndex = 41;
            this.lblDetainID.Text = "[ ? ? ? ]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label12.Location = new System.Drawing.Point(460, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 19);
            this.label12.TabIndex = 38;
            this.label12.Text = "Created By :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label13.Location = new System.Drawing.Point(466, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 19);
            this.label13.TabIndex = 37;
            this.label13.Text = "License ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label5.Location = new System.Drawing.Point(55, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 35;
            this.label5.Text = "Fine Fees :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label4.Location = new System.Drawing.Point(36, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Detain Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label3.Location = new System.Drawing.Point(54, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Detain ID :";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 15F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(843, 48);
            this.label1.TabIndex = 24;
            this.label1.Text = "Detain a License ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucFilterLicense1
            // 
            this.ucFilterLicense1.Location = new System.Drawing.Point(5, 60);
            this.ucFilterLicense1.Name = "ucFilterLicense1";
            this.ucFilterLicense1.Size = new System.Drawing.Size(832, 356);
            this.ucFilterLicense1.TabIndex = 25;
            this.ucFilterLicense1.OnLicenseFound += new DVLD_Presentation.User_Controls.ucFilterLicense.LicenseFound(this.ucFilterLicense1_OnPersonFound);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 574);
            this.Controls.Add(this.linkShowLicenseInfo);
            this.Controls.Add(this.linkShowLicensesHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbDetainInfo);
            this.Controls.Add(this.ucFilterLicense1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain a License";
            this.gbDetainInfo.ResumeLayout(false);
            this.gbDetainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkShowLicensesHistory;
        private Guna.UI2.WinForms.Guna2Button btnDetain;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.GroupBox gbDetainInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private User_Controls.ucFilterLicense ucFilterLicense1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txbFineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}