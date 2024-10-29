namespace DVLD_Presentation.User_Controls
{
    partial class ucFilterPerson
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
            this.FilteringBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txbFilterValue = new System.Windows.Forms.TextBox();
            this.cmbxFilterType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ucPersonInformation1 = new DVLD_Presentation.ucPersonInformation();
            this.FilteringBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilteringBox
            // 
            this.FilteringBox.Controls.Add(this.button1);
            this.FilteringBox.Controls.Add(this.btnSearch);
            this.FilteringBox.Controls.Add(this.txbFilterValue);
            this.FilteringBox.Controls.Add(this.cmbxFilterType);
            this.FilteringBox.Controls.Add(this.label2);
            this.FilteringBox.Font = new System.Drawing.Font("Open Sans", 9F);
            this.FilteringBox.Location = new System.Drawing.Point(14, 8);
            this.FilteringBox.Name = "FilteringBox";
            this.FilteringBox.Size = new System.Drawing.Size(696, 70);
            this.FilteringBox.TabIndex = 1;
            this.FilteringBox.TabStop = false;
            this.FilteringBox.Text = "Filter";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLD_Presentation.Properties.Resources.AddPerson;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(548, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 28;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::DVLD_Presentation.Properties.Resources.PersonSearch;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(498, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txbFilterValue
            // 
            this.txbFilterValue.Location = new System.Drawing.Point(296, 27);
            this.txbFilterValue.Name = "txbFilterValue";
            this.txbFilterValue.Size = new System.Drawing.Size(182, 24);
            this.txbFilterValue.TabIndex = 26;
            // 
            // cmbxFilterType
            // 
            this.cmbxFilterType.AllowDrop = true;
            this.cmbxFilterType.BackColor = System.Drawing.SystemColors.Control;
            this.cmbxFilterType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbxFilterType.FormattingEnabled = true;
            this.cmbxFilterType.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cmbxFilterType.Location = new System.Drawing.Point(90, 26);
            this.cmbxFilterType.Name = "cmbxFilterType";
            this.cmbxFilterType.Size = new System.Drawing.Size(182, 25);
            this.cmbxFilterType.TabIndex = 25;
            this.cmbxFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbxFilterType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter By: ";
            // 
            // ucPersonInformation1
            // 
            this.ucPersonInformation1.Location = new System.Drawing.Point(3, 74);
            this.ucPersonInformation1.Name = "ucPersonInformation1";
            this.ucPersonInformation1.Size = new System.Drawing.Size(717, 343);
            this.ucPersonInformation1.TabIndex = 0;
            // 
            // ucFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilteringBox);
            this.Controls.Add(this.ucPersonInformation1);
            this.Name = "ucFilterPerson";
            this.Size = new System.Drawing.Size(724, 417);
            this.Load += new System.EventHandler(this.ucFilterPerson_Load);
            this.FilteringBox.ResumeLayout(false);
            this.FilteringBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txbFilterValue;
        private System.Windows.Forms.ComboBox cmbxFilterType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.GroupBox FilteringBox;
        private System.Windows.Forms.Button button1;
        public ucPersonInformation ucPersonInformation1;
    }
}
