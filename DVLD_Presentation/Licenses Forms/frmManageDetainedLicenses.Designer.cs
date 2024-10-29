namespace DVLD_Presentation.Licenses_Forms
{
    partial class frmManageDetainedLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txbFilterValue = new System.Windows.Forms.TextBox();
            this.cmbIsReleased = new System.Windows.Forms.ComboBox();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.dgvDetainedLicensesTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseTheDetainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReleaseLicenses = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefreshTable = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txbFilterValue
            // 
            this.txbFilterValue.Location = new System.Drawing.Point(275, 229);
            this.txbFilterValue.Multiline = true;
            this.txbFilterValue.Name = "txbFilterValue";
            this.txbFilterValue.Size = new System.Drawing.Size(180, 23);
            this.txbFilterValue.TabIndex = 49;
            this.txbFilterValue.Visible = false;
            // 
            // cmbIsReleased
            // 
            this.cmbIsReleased.Font = new System.Drawing.Font("Open Sans", 8F);
            this.cmbIsReleased.FormattingEnabled = true;
            this.cmbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbIsReleased.Location = new System.Drawing.Point(275, 229);
            this.cmbIsReleased.Name = "cmbIsReleased";
            this.cmbIsReleased.Size = new System.Drawing.Size(122, 23);
            this.cmbIsReleased.TabIndex = 48;
            this.cmbIsReleased.Visible = false;
            this.cmbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cmbIsReleased_SelectedIndexChanged);
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.lblTotalRows.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRows.Location = new System.Drawing.Point(558, 542);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(17, 19);
            this.lblTotalRows.TabIndex = 47;
            this.lblTotalRows.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Semibold", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(457, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 46;
            this.label3.Text = "#Total Rows: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 45;
            this.label2.Text = "Filter By: ";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Open Sans", 8F);
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "None",
            "DetainID",
            "LicenseID",
            "National Number",
            "Full Name",
            "IsReleased"});
            this.cmbFilterType.Location = new System.Drawing.Point(86, 229);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(154, 23);
            this.cmbFilterType.TabIndex = 44;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // dgvDetainedLicensesTable
            // 
            this.dgvDetainedLicensesTable.AllowUserToAddRows = false;
            this.dgvDetainedLicensesTable.AllowUserToDeleteRows = false;
            this.dgvDetainedLicensesTable.AllowUserToResizeColumns = false;
            this.dgvDetainedLicensesTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetainedLicensesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainedLicensesTable.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetainedLicensesTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicensesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetainedLicensesTable.ColumnHeadersHeight = 20;
            this.dgvDetainedLicensesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetainedLicensesTable.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainedLicensesTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainedLicensesTable.EnableHeadersVisualStyles = false;
            this.dgvDetainedLicensesTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicensesTable.Location = new System.Drawing.Point(10, 260);
            this.dgvDetainedLicensesTable.MultiSelect = false;
            this.dgvDetainedLicensesTable.Name = "dgvDetainedLicensesTable";
            this.dgvDetainedLicensesTable.ReadOnly = true;
            this.dgvDetainedLicensesTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetainedLicensesTable.RowHeadersVisible = false;
            this.dgvDetainedLicensesTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDetainedLicensesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicensesTable.Size = new System.Drawing.Size(1094, 268);
            this.dgvDetainedLicensesTable.TabIndex = 42;
            this.dgvDetainedLicensesTable.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvDetainedLicensesTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetainedLicensesTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetainedLicensesTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetainedLicensesTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetainedLicensesTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetainedLicensesTable.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvDetainedLicensesTable.ThemeStyle.ReadOnly = true;
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.Height = 22;
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicensesTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetainedLicensesTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetainedLicensesTable_RowsAdded);
            this.dgvDetainedLicensesTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDetainedLicensesTable_RowsRemoved);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.releaseTheDetainToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 152);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.WrittenTest;
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.id;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.history;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person\'s Licenses History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
            // 
            // releaseTheDetainToolStripMenuItem
            // 
            this.releaseTheDetainToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.ReleaseLicense_Pic;
            this.releaseTheDetainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseTheDetainToolStripMenuItem.Name = "releaseTheDetainToolStripMenuItem";
            this.releaseTheDetainToolStripMenuItem.Size = new System.Drawing.Size(246, 30);
            this.releaseTheDetainToolStripMenuItem.Text = "Release The Detain";
            this.releaseTheDetainToolStripMenuItem.Click += new System.EventHandler(this.releaseTheDetainToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 18F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1094, 49);
            this.label1.TabIndex = 40;
            this.label1.Text = "Manage Detained Licenses";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReleaseLicenses
            // 
            this.btnReleaseLicenses.BackgroundImage = global::DVLD_Presentation.Properties.Resources.unlocked;
            this.btnReleaseLicenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReleaseLicenses.BorderColor = System.Drawing.Color.Blue;
            this.btnReleaseLicenses.BorderRadius = 5;
            this.btnReleaseLicenses.BorderThickness = 1;
            this.btnReleaseLicenses.CheckedState.Parent = this.btnReleaseLicenses;
            this.btnReleaseLicenses.CustomImages.Parent = this.btnReleaseLicenses;
            this.btnReleaseLicenses.FillColor = System.Drawing.Color.Transparent;
            this.btnReleaseLicenses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReleaseLicenses.ForeColor = System.Drawing.Color.White;
            this.btnReleaseLicenses.HoverState.Parent = this.btnReleaseLicenses;
            this.btnReleaseLicenses.Location = new System.Drawing.Point(1013, 216);
            this.btnReleaseLicenses.Name = "btnReleaseLicenses";
            this.btnReleaseLicenses.ShadowDecoration.Parent = this.btnReleaseLicenses;
            this.btnReleaseLicenses.Size = new System.Drawing.Size(39, 38);
            this.btnReleaseLicenses.TabIndex = 52;
            this.btnReleaseLicenses.Click += new System.EventHandler(this.btnReleaseLicenses_Click);
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.CheckedState.Parent = this.btnRefreshTable;
            this.btnRefreshTable.HoverState.Parent = this.btnRefreshTable;
            this.btnRefreshTable.Image = global::DVLD_Presentation.Properties.Resources.reload;
            this.btnRefreshTable.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRefreshTable.Location = new System.Drawing.Point(10, 533);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.PressedState.Parent = this.btnRefreshTable;
            this.btnRefreshTable.Size = new System.Drawing.Size(25, 25);
            this.btnRefreshTable.TabIndex = 51;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
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
            this.btnClose.Location = new System.Drawing.Point(1035, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(67, 29);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.BackgroundImage = global::DVLD_Presentation.Properties.Resources._lock;
            this.btnDetainLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetainLicense.BorderColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.BorderRadius = 5;
            this.btnDetainLicense.BorderThickness = 1;
            this.btnDetainLicense.CheckedState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.CustomImages.Parent = this.btnDetainLicense;
            this.btnDetainLicense.FillColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.HoverState.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Location = new System.Drawing.Point(1065, 216);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.ShadowDecoration.Parent = this.btnDetainLicense;
            this.btnDetainLicense.Size = new System.Drawing.Size(39, 38);
            this.btnDetainLicense.TabIndex = 43;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.ManageDetainedLicenses;
            this.pictureBox1.Location = new System.Drawing.Point(474, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 576);
            this.Controls.Add(this.btnReleaseLicenses);
            this.Controls.Add(this.btnRefreshTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txbFilterValue);
            this.Controls.Add(this.cmbIsReleased);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.dgvDetainedLicensesTable);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btnRefreshTable;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.TextBox txbFilterValue;
        private System.Windows.Forms.ComboBox cmbIsReleased;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetainedLicensesTable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnReleaseLicenses;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseTheDetainToolStripMenuItem;
    }
}