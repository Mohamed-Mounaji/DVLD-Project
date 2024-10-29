namespace DVLD_Presentation.Applications_Forms
{
    partial class frmNewLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLocalDrivingLicenseApplication));
            this.label1 = new System.Windows.Forms.Label();
            this.AddNewApplicationTabControl = new System.Windows.Forms.TabControl();
            this.PersonalInfoTab = new System.Windows.Forms.TabPage();
            this.ucFilterPerson1 = new DVLD_Presentation.User_Controls.ucFilterPerson();
            this.btnNext = new System.Windows.Forms.Button();
            this.LoginInfoTab = new System.Windows.Forms.TabPage();
            this.cmbLicenseClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.AddNewApplicationTabControl.SuspendLayout();
            this.PersonalInfoTab.SuspendLayout();
            this.LoginInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 20F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(20, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(777, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Local Driving License Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddNewApplicationTabControl
            // 
            this.AddNewApplicationTabControl.Controls.Add(this.PersonalInfoTab);
            this.AddNewApplicationTabControl.Controls.Add(this.LoginInfoTab);
            this.AddNewApplicationTabControl.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewApplicationTabControl.Location = new System.Drawing.Point(23, 64);
            this.AddNewApplicationTabControl.Name = "AddNewApplicationTabControl";
            this.AddNewApplicationTabControl.SelectedIndex = 0;
            this.AddNewApplicationTabControl.Size = new System.Drawing.Size(757, 498);
            this.AddNewApplicationTabControl.TabIndex = 1;
            // 
            // PersonalInfoTab
            // 
            this.PersonalInfoTab.BackColor = System.Drawing.SystemColors.Control;
            this.PersonalInfoTab.Controls.Add(this.ucFilterPerson1);
            this.PersonalInfoTab.Controls.Add(this.btnNext);
            this.PersonalInfoTab.Location = new System.Drawing.Point(4, 26);
            this.PersonalInfoTab.Name = "PersonalInfoTab";
            this.PersonalInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalInfoTab.Size = new System.Drawing.Size(749, 468);
            this.PersonalInfoTab.TabIndex = 0;
            this.PersonalInfoTab.Text = "Applicant Info";
            // 
            // ucFilterPerson1
            // 
            this.ucFilterPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ucFilterPerson1.Location = new System.Drawing.Point(9, 10);
            this.ucFilterPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ucFilterPerson1.Name = "ucFilterPerson1";
            this.ucFilterPerson1.Size = new System.Drawing.Size(724, 417);
            this.ucFilterPerson1.TabIndex = 2;
            this.ucFilterPerson1.PersonFound += new DVLD_Presentation.User_Controls.ucFilterPerson.FilterPerson_PersonFoundEventHandler(this.ucFilterPerson1_PersonFound);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(640, 428);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // LoginInfoTab
            // 
            this.LoginInfoTab.BackColor = System.Drawing.SystemColors.Control;
            this.LoginInfoTab.Controls.Add(this.cmbLicenseClass);
            this.LoginInfoTab.Controls.Add(this.lblCreatedBy);
            this.LoginInfoTab.Controls.Add(this.lblApplicationFees);
            this.LoginInfoTab.Controls.Add(this.lblApplicationDate);
            this.LoginInfoTab.Controls.Add(this.lblApplicationID);
            this.LoginInfoTab.Controls.Add(this.label6);
            this.LoginInfoTab.Controls.Add(this.label5);
            this.LoginInfoTab.Controls.Add(this.label4);
            this.LoginInfoTab.Controls.Add(this.label3);
            this.LoginInfoTab.Controls.Add(this.label2);
            this.LoginInfoTab.Location = new System.Drawing.Point(4, 26);
            this.LoginInfoTab.Name = "LoginInfoTab";
            this.LoginInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfoTab.Size = new System.Drawing.Size(749, 468);
            this.LoginInfoTab.TabIndex = 1;
            this.LoginInfoTab.Text = "Application Info";
            // 
            // cmbLicenseClass
            // 
            this.cmbLicenseClass.BackColor = System.Drawing.Color.Transparent;
            this.cmbLicenseClass.BorderThickness = 3;
            this.cmbLicenseClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLicenseClass.FocusedColor = System.Drawing.Color.Empty;
            this.cmbLicenseClass.FocusedState.Parent = this.cmbLicenseClass;
            this.cmbLicenseClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLicenseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLicenseClass.FormattingEnabled = true;
            this.cmbLicenseClass.HoverState.Parent = this.cmbLicenseClass;
            this.cmbLicenseClass.ItemHeight = 30;
            this.cmbLicenseClass.ItemsAppearance.Parent = this.cmbLicenseClass;
            this.cmbLicenseClass.Location = new System.Drawing.Point(265, 201);
            this.cmbLicenseClass.Name = "cmbLicenseClass";
            this.cmbLicenseClass.ShadowDecoration.Parent = this.cmbLicenseClass;
            this.cmbLicenseClass.Size = new System.Drawing.Size(252, 36);
            this.cmbLicenseClass.TabIndex = 9;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(262, 312);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 18);
            this.lblCreatedBy.TabIndex = 8;
            this.lblCreatedBy.Text = "N/A ";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(262, 259);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(35, 18);
            this.lblApplicationFees.TabIndex = 7;
            this.lblApplicationFees.Text = "N/A ";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(262, 153);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(35, 18);
            this.lblApplicationDate.TabIndex = 6;
            this.lblApplicationDate.Text = "N/A ";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(262, 100);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(35, 18);
            this.lblApplicationID.TabIndex = 5;
            this.lblApplicationID.Text = "N/A ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(127, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Fees:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L Application ID: ";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(600, 575);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "   Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(696, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "   Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 617);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.AddNewApplicationTabControl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicenseApplication_Load);
            this.AddNewApplicationTabControl.ResumeLayout(false);
            this.PersonalInfoTab.ResumeLayout(false);
            this.LoginInfoTab.ResumeLayout(false);
            this.LoginInfoTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl AddNewApplicationTabControl;
        private System.Windows.Forms.TabPage PersonalInfoTab;
        private User_Controls.ucFilterPerson ucFilterPerson1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage LoginInfoTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblApplicationID;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLicenseClass;
    }
}