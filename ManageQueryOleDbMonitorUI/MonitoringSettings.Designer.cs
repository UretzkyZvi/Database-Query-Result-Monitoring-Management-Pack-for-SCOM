namespace ManageQueryOleDbMonitorUI
{
    partial class MonitoringSettings
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblMonitoring = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSamples = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.NumericUpDown();
            this.pageSectionLabel1 = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.pageSectionLabel2 = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.rbtnExistGroup = new System.Windows.Forms.RadioButton();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rbtnNewGroup = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblMonitoring
            // 
            this.lblMonitoring.BackColor = System.Drawing.Color.Transparent;
            this.lblMonitoring.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMonitoring.Location = new System.Drawing.Point(13, 12);
            this.lblMonitoring.MinimumSize = new System.Drawing.Size(244, 0);
            this.lblMonitoring.Name = "lblMonitoring";
            this.lblMonitoring.Size = new System.Drawing.Size(244, 23);
            this.lblMonitoring.TabIndex = 12;
            this.lblMonitoring.Text = "Specify threshold value to compare";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Specify the number of consective samples that should exceed a threshold before an" +
    " alert is generated";
            // 
            // txtSamples
            // 
            this.txtSamples.Location = new System.Drawing.Point(13, 149);
            this.txtSamples.Name = "txtSamples";
            this.txtSamples.Size = new System.Drawing.Size(120, 20);
            this.txtSamples.TabIndex = 14;
            this.txtSamples.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Value: ";
            // 
            // cmbDirection
            // 
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(75, 47);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(121, 21);
            this.cmbDirection.TabIndex = 16;
            // 
            // txtValue
            // 
            this.txtValue.DecimalPlaces = 5;
            this.txtValue.Location = new System.Drawing.Point(218, 47);
            this.txtValue.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(120, 20);
            this.txtValue.TabIndex = 17;
            // 
            // pageSectionLabel1
            // 
            this.pageSectionLabel1.BackColor = System.Drawing.Color.Transparent;
            this.pageSectionLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pageSectionLabel1.Location = new System.Drawing.Point(13, 92);
            this.pageSectionLabel1.MinimumSize = new System.Drawing.Size(244, 0);
            this.pageSectionLabel1.Name = "pageSectionLabel1";
            this.pageSectionLabel1.Size = new System.Drawing.Size(244, 23);
            this.pageSectionLabel1.TabIndex = 18;
            this.pageSectionLabel1.Text = "Specify number of samples";
            // 
            // pageSectionLabel2
            // 
            this.pageSectionLabel2.BackColor = System.Drawing.Color.Transparent;
            this.pageSectionLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pageSectionLabel2.Location = new System.Drawing.Point(13, 184);
            this.pageSectionLabel2.MinimumSize = new System.Drawing.Size(244, 0);
            this.pageSectionLabel2.Name = "pageSectionLabel2";
            this.pageSectionLabel2.Size = new System.Drawing.Size(244, 23);
            this.pageSectionLabel2.TabIndex = 19;
            this.pageSectionLabel2.Text = "Alert info and monitor group define";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Add more information to the alert content.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Extra alert content";
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(16, 265);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(322, 74);
            this.txtErrorMessage.TabIndex = 22;
            // 
            // rbtnExistGroup
            // 
            this.rbtnExistGroup.AutoSize = true;
            this.rbtnExistGroup.Checked = true;
            this.rbtnExistGroup.Location = new System.Drawing.Point(16, 368);
            this.rbtnExistGroup.Name = "rbtnExistGroup";
            this.rbtnExistGroup.Size = new System.Drawing.Size(123, 17);
            this.rbtnExistGroup.TabIndex = 23;
            this.rbtnExistGroup.TabStop = true;
            this.rbtnExistGroup.Text = "Select exsiting group";
            this.rbtnExistGroup.UseVisualStyleBackColor = true;
            this.rbtnExistGroup.CheckedChanged += new System.EventHandler(this.rbtnExistGroup_CheckedChanged);
            // 
            // txtGroup
            // 
            this.txtGroup.Enabled = false;
            this.txtGroup.Location = new System.Drawing.Point(16, 403);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(322, 20);
            this.txtGroup.TabIndex = 24;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(345, 402);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 25;
            this.btnBrowse.Text = "Browse..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rbtnNewGroup
            // 
            this.rbtnNewGroup.AutoSize = true;
            this.rbtnNewGroup.Location = new System.Drawing.Point(229, 368);
            this.rbtnNewGroup.Name = "rbtnNewGroup";
            this.rbtnNewGroup.Size = new System.Drawing.Size(109, 17);
            this.rbtnNewGroup.TabIndex = 26;
            this.rbtnNewGroup.Text = "Create new group";
            this.rbtnNewGroup.UseVisualStyleBackColor = true;
            this.rbtnNewGroup.CheckedChanged += new System.EventHandler(this.rbtnNewGroup_CheckedChanged);
            // 
            // MonitoringSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbtnNewGroup);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.rbtnExistGroup);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pageSectionLabel2);
            this.Controls.Add(this.pageSectionLabel1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSamples);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMonitoring);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MonitoringSettings";
            this.Size = new System.Drawing.Size(561, 469);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel lblMonitoring;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel pageSectionLabel1;
        private System.Windows.Forms.NumericUpDown txtValue;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel pageSectionLabel2;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnExistGroup;
        private System.Windows.Forms.RadioButton rbtnNewGroup;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtGroup;
    }
}
