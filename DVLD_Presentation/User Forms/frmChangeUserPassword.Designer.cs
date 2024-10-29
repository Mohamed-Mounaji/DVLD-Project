namespace DVLD_Presentation
{
    partial class frmChangeUserPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeUserPassword));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbCurrPassword = new System.Windows.Forms.TextBox();
            this.txbPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucUserInformation1 = new DVLD_Presentation.ucUserInformation();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(274, 534);
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
            this.btnSave.Location = new System.Drawing.Point(370, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "   Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbCurrPassword
            // 
            this.txbCurrPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbCurrPassword.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCurrPassword.Location = new System.Drawing.Point(12, 482);
            this.txbCurrPassword.Name = "txbCurrPassword";
            this.txbCurrPassword.PasswordChar = '*';
            this.txbCurrPassword.Size = new System.Drawing.Size(181, 25);
            this.txbCurrPassword.TabIndex = 22;
            this.txbCurrPassword.Validated += new System.EventHandler(this.TextBox_ValidatedEmpyAndWhiteSpace);
            // 
            // txbPasswordConfirmation
            // 
            this.txbPasswordConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbPasswordConfirmation.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPasswordConfirmation.Location = new System.Drawing.Point(530, 482);
            this.txbPasswordConfirmation.Name = "txbPasswordConfirmation";
            this.txbPasswordConfirmation.PasswordChar = '*';
            this.txbPasswordConfirmation.Size = new System.Drawing.Size(181, 25);
            this.txbPasswordConfirmation.TabIndex = 23;
            this.txbPasswordConfirmation.Validated += new System.EventHandler(this.TextBox_ValidatedEmpyAndWhiteSpace);
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbNewPassword.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPassword.Location = new System.Drawing.Point(271, 482);
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.Size = new System.Drawing.Size(181, 25);
            this.txbNewPassword.TabIndex = 24;
            this.txbNewPassword.Validated += new System.EventHandler(this.TextBox_ValidatedEmpyAndWhiteSpace);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label1.Location = new System.Drawing.Point(12, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Current Password: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label2.Location = new System.Drawing.Point(529, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Confirm Password: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label3.Location = new System.Drawing.Point(270, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "New Password: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucUserInformation1
            // 
            this.ucUserInformation1.Location = new System.Drawing.Point(2, 1);
            this.ucUserInformation1.Name = "ucUserInformation1";
            this.ucUserInformation1.Size = new System.Drawing.Size(727, 455);
            this.ucUserInformation1.TabIndex = 21;
            // 
            // frmChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 574);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbNewPassword);
            this.Controls.Add(this.txbPasswordConfirmation);
            this.Controls.Add(this.txbCurrPassword);
            this.Controls.Add(this.ucUserInformation1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangeUserPassword";
            this.Text = "ChangeUserPassword";
            this.Shown += new System.EventHandler(this.frmChangeUserPassword_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private ucUserInformation ucUserInformation1;
        private System.Windows.Forms.TextBox txbCurrPassword;
        private System.Windows.Forms.TextBox txbPasswordConfirmation;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}