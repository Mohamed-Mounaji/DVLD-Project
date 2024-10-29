namespace DVLD_Presentation.User_Controls
{
    partial class ucFilterLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLicenseID = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucLicenseInfo1 = new DVLD_Presentation.User_Controls.ucLicenseInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.txbLicenseID);
            this.gbFilter.Font = new System.Drawing.Font("Open Sans", 9F);
            this.gbFilter.Location = new System.Drawing.Point(107, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(625, 56);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 5;
            this.btnFind.CheckedState.Parent = this.btnFind;
            this.btnFind.CustomImages.Parent = this.btnFind;
            this.btnFind.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.HoverState.Parent = this.btnFind;
            this.btnFind.Image = global::DVLD_Presentation.Properties.Resources.search;
            this.btnFind.Location = new System.Drawing.Point(417, 18);
            this.btnFind.Name = "btnFind";
            this.btnFind.ShadowDecoration.Parent = this.btnFind;
            this.btnFind.Size = new System.Drawing.Size(61, 26);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label1.Location = new System.Drawing.Point(88, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "License ID : ";
            // 
            // txbLicenseID
            // 
            this.txbLicenseID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbLicenseID.DefaultText = "";
            this.txbLicenseID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbLicenseID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbLicenseID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLicenseID.DisabledState.Parent = this.txbLicenseID;
            this.txbLicenseID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbLicenseID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLicenseID.FocusedState.Parent = this.txbLicenseID;
            this.txbLicenseID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbLicenseID.HoverState.Parent = this.txbLicenseID;
            this.txbLicenseID.Location = new System.Drawing.Point(194, 18);
            this.txbLicenseID.Margin = new System.Windows.Forms.Padding(4);
            this.txbLicenseID.Name = "txbLicenseID";
            this.txbLicenseID.PasswordChar = '\0';
            this.txbLicenseID.PlaceholderText = "";
            this.txbLicenseID.SelectedText = "";
            this.txbLicenseID.ShadowDecoration.Parent = this.txbLicenseID;
            this.txbLicenseID.Size = new System.Drawing.Size(200, 26);
            this.txbLicenseID.TabIndex = 0;
            this.txbLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLicenseID_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.Font = new System.Drawing.Font("Open Sans", 8F);
            this.ucLicenseInfo1.Location = new System.Drawing.Point(3, 62);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(825, 289);
            this.ucLicenseInfo1.TabIndex = 0;
            // 
            // ucFilterLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ucLicenseInfo1);
            this.Name = "ucFilterLicense";
            this.Size = new System.Drawing.Size(832, 356);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucLicenseInfo ucLicenseInfo1;
        public System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public Guna.UI2.WinForms.Guna2TextBox txbLicenseID;
    }
}
