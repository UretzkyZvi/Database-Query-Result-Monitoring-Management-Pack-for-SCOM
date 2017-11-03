namespace ManageQueryOleDbMonitorUI
{
    partial class SchedulerSettings
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
            this.lbl1 = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntervalSeconds = new System.Windows.Forms.NumericUpDown();
            this.cmbTimes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSyncTime = new System.Windows.Forms.MaskedTextBox();
            this.pageSectionLabel1 = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.cbxDays = new System.Windows.Forms.CheckedListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl1.Location = new System.Drawing.Point(6, 10);
            this.lbl1.MinimumSize = new System.Drawing.Size(244, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(244, 23);
            this.lbl1.TabIndex = 13;
            this.lbl1.Text = "Specify schedule settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sample Interval";
            // 
            // txtIntervalSeconds
            // 
            this.txtIntervalSeconds.Location = new System.Drawing.Point(6, 129);
            this.txtIntervalSeconds.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.txtIntervalSeconds.Name = "txtIntervalSeconds";
            this.txtIntervalSeconds.Size = new System.Drawing.Size(100, 20);
            this.txtIntervalSeconds.TabIndex = 15;
            this.txtIntervalSeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cmbTimes
            // 
            this.cmbTimes.FormattingEnabled = true;
            this.cmbTimes.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days"});
            this.cmbTimes.Location = new System.Drawing.Point(125, 128);
            this.cmbTimes.Name = "cmbTimes";
            this.cmbTimes.Size = new System.Drawing.Size(100, 21);
            this.cmbTimes.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Synchronize at";
            // 
            // txtSyncTime
            // 
            this.txtSyncTime.Location = new System.Drawing.Point(6, 179);
            this.txtSyncTime.Mask = "00:00";
            this.txtSyncTime.Name = "txtSyncTime";
            this.txtSyncTime.RejectInputOnFirstFailure = true;
            this.txtSyncTime.Size = new System.Drawing.Size(100, 20);
            this.txtSyncTime.TabIndex = 18;
            this.txtSyncTime.Text = "0001";
            this.txtSyncTime.ValidatingType = typeof(System.DateTime);
            // 
            // pageSectionLabel1
            // 
            this.pageSectionLabel1.BackColor = System.Drawing.Color.Transparent;
            this.pageSectionLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pageSectionLabel1.Location = new System.Drawing.Point(6, 213);
            this.pageSectionLabel1.MinimumSize = new System.Drawing.Size(244, 0);
            this.pageSectionLabel1.Name = "pageSectionLabel1";
            this.pageSectionLabel1.Size = new System.Drawing.Size(244, 23);
            this.pageSectionLabel1.TabIndex = 19;
            this.pageSectionLabel1.Text = "Specify days of week";
            // 
            // cbxDays
            // 
            this.cbxDays.FormattingEnabled = true;
            this.cbxDays.Location = new System.Drawing.Point(6, 240);
            this.cbxDays.Name = "cbxDays";
            this.cbxDays.Size = new System.Drawing.Size(567, 214);
            this.cbxDays.TabIndex = 20;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Start Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "End Time";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(6, 63);
            this.txtStartTime.Mask = "00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.RejectInputOnFirstFailure = true;
            this.txtStartTime.Size = new System.Drawing.Size(100, 20);
            this.txtStartTime.TabIndex = 23;
            this.txtStartTime.Text = "0000";
            this.txtStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(125, 63);
            this.txtEndTime.Mask = "00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.RejectInputOnFirstFailure = true;
            this.txtEndTime.Size = new System.Drawing.Size(100, 20);
            this.txtEndTime.SkipLiterals = false;
            this.txtEndTime.TabIndex = 24;
            this.txtEndTime.Text = "2359";
            this.txtEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // SchedulerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxDays);
            this.Controls.Add(this.pageSectionLabel1);
            this.Controls.Add(this.txtSyncTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimes);
            this.Controls.Add(this.txtIntervalSeconds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1);
            this.Name = "SchedulerSettings";
            this.Size = new System.Drawing.Size(579, 481);
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtIntervalSeconds;
        private System.Windows.Forms.ComboBox cmbTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtSyncTime;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel pageSectionLabel1;
        private System.Windows.Forms.CheckedListBox cbxDays;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
