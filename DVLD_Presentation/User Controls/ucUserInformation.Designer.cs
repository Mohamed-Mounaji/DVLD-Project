namespace DVLD_Presentation
{
    partial class ucUserInformation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.gbxLoginInfo = new System.Windows.Forms.GroupBox();
            this.ucPersonInformation1 = new DVLD_Presentation.ucPersonInformation();
            this.gbxLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label1.Location = new System.Drawing.Point(55, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label2.Location = new System.Drawing.Point(288, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F);
            this.label3.Location = new System.Drawing.Point(521, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Is Active:";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Open Sans", 9.75F);
            this.lblUserId.Location = new System.Drawing.Point(119, 35);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(31, 18);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "N/A";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Open Sans", 9.75F);
            this.lblUserName.Location = new System.Drawing.Point(375, 35);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(31, 18);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "N/A";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Open Sans", 9.75F);
            this.lblIsActive.Location = new System.Drawing.Point(590, 35);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(31, 18);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "N/A";
            // 
            // gbxLoginInfo
            // 
            this.gbxLoginInfo.Controls.Add(this.lblIsActive);
            this.gbxLoginInfo.Controls.Add(this.lblUserName);
            this.gbxLoginInfo.Controls.Add(this.lblUserId);
            this.gbxLoginInfo.Controls.Add(this.label3);
            this.gbxLoginInfo.Controls.Add(this.label2);
            this.gbxLoginInfo.Controls.Add(this.label1);
            this.gbxLoginInfo.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLoginInfo.Location = new System.Drawing.Point(11, 360);
            this.gbxLoginInfo.Name = "gbxLoginInfo";
            this.gbxLoginInfo.Size = new System.Drawing.Size(704, 79);
            this.gbxLoginInfo.TabIndex = 3;
            this.gbxLoginInfo.TabStop = false;
            this.gbxLoginInfo.Text = "Login Info";
            // 
            // ucPersonInformation1
            // 
            this.ucPersonInformation1.Location = new System.Drawing.Point(11, 0);
            this.ucPersonInformation1.Name = "ucPersonInformation1";
            this.ucPersonInformation1.Size = new System.Drawing.Size(717, 351);
            this.ucPersonInformation1.TabIndex = 2;
            // 
            // ucUserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxLoginInfo);
            this.Controls.Add(this.ucPersonInformation1);
            this.Name = "ucUserInformation";
            this.Size = new System.Drawing.Size(727, 455);
            this.gbxLoginInfo.ResumeLayout(false);
            this.gbxLoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.GroupBox gbxLoginInfo;
        private ucPersonInformation ucPersonInformation1;
    }
}
