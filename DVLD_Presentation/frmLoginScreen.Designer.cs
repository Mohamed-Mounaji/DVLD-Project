namespace DVLD_Presentation
{
    partial class frmLoginScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chbRememberME = new System.Windows.Forms.CheckBox();
            this.txbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowPassword = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.label1.Location = new System.Drawing.Point(489, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.label2.Location = new System.Drawing.Point(489, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 18F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(409, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 76);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login Screen";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chbRememberME
            // 
            this.chbRememberME.AutoSize = true;
            this.chbRememberME.Checked = true;
            this.chbRememberME.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRememberME.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F);
            this.chbRememberME.ForeColor = System.Drawing.Color.Red;
            this.chbRememberME.Location = new System.Drawing.Point(492, 271);
            this.chbRememberME.Name = "chbRememberME";
            this.chbRememberME.Size = new System.Drawing.Size(105, 19);
            this.chbRememberME.TabIndex = 8;
            this.chbRememberME.Text = "Remember me";
            this.chbRememberME.UseVisualStyleBackColor = true;
            // 
            // txbUserName
            // 
            this.txbUserName.Animated = true;
            this.txbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txbUserName.AutoRoundedCorners = true;
            this.txbUserName.BackColor = System.Drawing.Color.Transparent;
            this.txbUserName.BorderRadius = 17;
            this.txbUserName.BorderThickness = 2;
            this.txbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbUserName.DefaultText = "Mohamed";
            this.txbUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbUserName.DisabledState.Parent = this.txbUserName;
            this.txbUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbUserName.FocusedState.FillColor = System.Drawing.Color.Transparent;
            this.txbUserName.FocusedState.Parent = this.txbUserName;
            this.txbUserName.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txbUserName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txbUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbUserName.HoverState.Parent = this.txbUserName;
            this.txbUserName.Location = new System.Drawing.Point(480, 145);
            this.txbUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.PasswordChar = '\0';
            this.txbUserName.PlaceholderText = "";
            this.txbUserName.SelectedText = "";
            this.txbUserName.SelectionStart = 7;
            this.txbUserName.ShadowDecoration.BorderRadius = 12;
            this.txbUserName.ShadowDecoration.Parent = this.txbUserName;
            this.txbUserName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.txbUserName.Size = new System.Drawing.Size(259, 37);
            this.txbUserName.TabIndex = 9;
            this.txbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_ValidatingNulAndWhiteSpace);
            // 
            // txbPassword
            // 
            this.txbPassword.AutoRoundedCorners = true;
            this.txbPassword.BorderRadius = 17;
            this.txbPassword.BorderThickness = 2;
            this.txbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbPassword.DefaultText = "";
            this.txbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbPassword.DisabledState.Parent = this.txbPassword;
            this.txbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbPassword.FocusedState.Parent = this.txbPassword;
            this.txbPassword.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txbPassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbPassword.HoverState.Parent = this.txbPassword;
            this.txbPassword.Location = new System.Drawing.Point(480, 221);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.PlaceholderText = "";
            this.txbPassword.SelectedText = "";
            this.txbPassword.ShadowDecoration.Parent = this.txbPassword;
            this.txbPassword.Size = new System.Drawing.Size(259, 37);
            this.txbPassword.TabIndex = 10;
            this.txbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_ValidatingNulAndWhiteSpace);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoRoundedCorners = true;
            this.btnLogin.BorderRadius = 14;
            this.btnLogin.CheckedState.Parent = this.btnLogin;
            this.btnLogin.CustomImages.Parent = this.btnLogin;
            this.btnLogin.Font = new System.Drawing.Font("Open Sans", 8.25F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.Parent = this.btnLogin;
            this.btnLogin.Location = new System.Drawing.Point(643, 305);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ShadowDecoration.Parent = this.btnLogin;
            this.btnLogin.Size = new System.Drawing.Size(96, 31);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.CheckedState.Image = global::DVLD_Presentation.Properties.Resources.OpenEyes;
            this.btnShowPassword.CheckedState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowPassword.CheckedState.Parent = this.btnShowPassword;
            this.btnShowPassword.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowPassword.HoverState.Parent = this.btnShowPassword;
            this.btnShowPassword.Image = global::DVLD_Presentation.Properties.Resources.CloseEyes;
            this.btnShowPassword.ImageSize = new System.Drawing.Size(30, 30);
            this.btnShowPassword.Location = new System.Drawing.Point(755, 227);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.PressedState.Parent = this.btnShowPassword;
            this.btnShowPassword.Size = new System.Drawing.Size(36, 26);
            this.btnShowPassword.TabIndex = 12;
            this.btnShowPassword.CheckedChanged += new System.EventHandler(this.btnShowPassword_CheckedChanged);
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.license;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(-1, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 291);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 18F, System.Drawing.FontStyle.Underline);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(-1, 1);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.label4.Size = new System.Drawing.Size(403, 158);
            this.label4.TabIndex = 13;
            this.label4.Text = "Driving And Vehicle License Department";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.chbRememberME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.VisibleChanged += new System.EventHandler(this.frmLoginScreen_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chbRememberME;
        private Guna.UI2.WinForms.Guna2TextBox txbPassword;
        private Guna.UI2.WinForms.Guna2TextBox txbUserName;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2ImageButton btnShowPassword;
        private System.Windows.Forms.Label label4;
    }
}