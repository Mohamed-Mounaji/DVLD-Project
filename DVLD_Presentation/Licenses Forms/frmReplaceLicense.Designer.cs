namespace DVLD_Presentation.Licenses_Forms
{
    partial class frmReplaceLicense
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
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblNewLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbDamagedLicense = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbLostLicense = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.linkShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linkShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ucFilterLicense = new DVLD_Presentation.User_Controls.ucFilterLicense();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.rbLostLicense);
            this.gbApplicationInfo.Controls.Add(this.rbDamagedLicense);
            this.gbApplicationInfo.Controls.Add(this.label10);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblNewLicenseID);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label8);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Controls.Add(this.label1);
            this.gbApplicationInfo.Enabled = false;
            this.gbApplicationInfo.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.gbApplicationInfo.Location = new System.Drawing.Point(79, 368);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(687, 147);
            this.gbApplicationInfo.TabIndex = 1;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info For License Replacement";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationFees.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApplicationFees.Location = new System.Drawing.Point(159, 115);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationFees.TabIndex = 29;
            this.lblApplicationFees.Text = "[ ? ? ? ]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationDate.ForeColor = System.Drawing.Color.Red;
            this.lblApplicationDate.Location = new System.Drawing.Point(159, 89);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationDate.TabIndex = 28;
            this.lblApplicationDate.Text = "[ ? ? ? ]";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblApplicationID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApplicationID.Location = new System.Drawing.Point(159, 63);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(53, 19);
            this.lblApplicationID.TabIndex = 27;
            this.lblApplicationID.Text = "[ ? ? ? ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label3.Location = new System.Drawing.Point(19, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label2.Location = new System.Drawing.Point(17, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Application Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Application ID :";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblCreatedBy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCreatedBy.Location = new System.Drawing.Point(519, 115);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(53, 19);
            this.lblCreatedBy.TabIndex = 35;
            this.lblCreatedBy.Text = "[ ? ? ? ]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Red;
            this.lblOldLicenseID.Location = new System.Drawing.Point(519, 89);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(53, 19);
            this.lblOldLicenseID.TabIndex = 34;
            this.lblOldLicenseID.Text = "[ ? ? ? ]";
            // 
            // lblNewLicenseID
            // 
            this.lblNewLicenseID.AutoSize = true;
            this.lblNewLicenseID.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblNewLicenseID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNewLicenseID.Location = new System.Drawing.Point(519, 63);
            this.lblNewLicenseID.Name = "lblNewLicenseID";
            this.lblNewLicenseID.Size = new System.Drawing.Size(53, 19);
            this.lblNewLicenseID.TabIndex = 33;
            this.lblNewLicenseID.Text = "[ ? ? ? ]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label7.Location = new System.Drawing.Point(417, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Created By :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label8.Location = new System.Drawing.Point(395, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 19);
            this.label8.TabIndex = 31;
            this.label8.Text = "Old License ID :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label9.Location = new System.Drawing.Point(389, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 19);
            this.label9.TabIndex = 30;
            this.label9.Text = "New License ID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label10.Location = new System.Drawing.Point(131, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 19);
            this.label10.TabIndex = 36;
            this.label10.Text = "Replacement For :";
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Checked = true;
            this.rbDamagedLicense.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDamagedLicense.CheckedState.BorderThickness = 0;
            this.rbDamagedLicense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbDamagedLicense.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDamagedLicense.CheckedState.InnerOffset = -4;
            this.rbDamagedLicense.Font = new System.Drawing.Font("Open Sans Semibold", 9F);
            this.rbDamagedLicense.ForeColor = System.Drawing.Color.Blue;
            this.rbDamagedLicense.Location = new System.Drawing.Point(276, 28);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(128, 21);
            this.rbDamagedLicense.TabIndex = 37;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDamagedLicense.UncheckedState.BorderThickness = 2;
            this.rbDamagedLicense.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDamagedLicense.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbLostLicense.CheckedState.BorderThickness = 0;
            this.rbLostLicense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbLostLicense.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbLostLicense.CheckedState.InnerOffset = -4;
            this.rbLostLicense.Font = new System.Drawing.Font("Open Sans Semibold", 9F);
            this.rbLostLicense.ForeColor = System.Drawing.Color.Blue;
            this.rbLostLicense.Location = new System.Drawing.Point(417, 28);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(98, 21);
            this.rbLostLicense.TabIndex = 38;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbLostLicense.UncheckedState.BorderThickness = 2;
            this.rbLostLicense.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbLostLicense.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderThickness = 1;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSave.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = global::DVLD_Presentation.Properties.Resources.Save;
            this.btnSave.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSave.Location = new System.Drawing.Point(697, 526);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(67, 29);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnClose.Location = new System.Drawing.Point(615, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(67, 29);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkShowLicenseHistory
            // 
            this.linkShowLicenseHistory.AutoSize = true;
            this.linkShowLicenseHistory.Font = new System.Drawing.Font("Open Sans", 11F);
            this.linkShowLicenseHistory.Location = new System.Drawing.Point(12, 530);
            this.linkShowLicenseHistory.Name = "linkShowLicenseHistory";
            this.linkShowLicenseHistory.Size = new System.Drawing.Size(163, 20);
            this.linkShowLicenseHistory.TabIndex = 20;
            this.linkShowLicenseHistory.TabStop = true;
            this.linkShowLicenseHistory.Text = "Show Licenses History";
            this.linkShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowLicenseHistory_LinkClicked);
            // 
            // linkShowNewLicenseInfo
            // 
            this.linkShowNewLicenseInfo.AutoSize = true;
            this.linkShowNewLicenseInfo.Enabled = false;
            this.linkShowNewLicenseInfo.Font = new System.Drawing.Font("Open Sans", 11F);
            this.linkShowNewLicenseInfo.Location = new System.Drawing.Point(193, 530);
            this.linkShowNewLicenseInfo.Name = "linkShowNewLicenseInfo";
            this.linkShowNewLicenseInfo.Size = new System.Drawing.Size(168, 20);
            this.linkShowNewLicenseInfo.TabIndex = 21;
            this.linkShowNewLicenseInfo.TabStop = true;
            this.linkShowNewLicenseInfo.Text = "Show New License Info";
            this.linkShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowNewLicenseInfo_LinkClicked);
            // 
            // ucFilterLicense
            // 
            this.ucFilterLicense.Location = new System.Drawing.Point(6, 6);
            this.ucFilterLicense.Name = "ucFilterLicense";
            this.ucFilterLicense.Size = new System.Drawing.Size(832, 356);
            this.ucFilterLicense.TabIndex = 0;
            this.ucFilterLicense.OnLicenseFound += new DVLD_Presentation.User_Controls.ucFilterLicense.LicenseFound(this.ucFilterLicense_OnPersonFound);
            // 
            // frmReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 562);
            this.Controls.Add(this.linkShowNewLicenseInfo);
            this.Controls.Add(this.linkShowLicenseHistory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.ucFilterLicense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace a damaged/lost license";
            this.Load += new System.EventHandler(this.frmReplaceLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.ucFilterLicense ucFilterLicense;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblNewLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2RadioButton rbLostLicense;
        private Guna.UI2.WinForms.Guna2RadioButton rbDamagedLicense;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.LinkLabel linkShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linkShowNewLicenseInfo;
    }
}