namespace ManageQueryOleDbMonitorUI
{
    partial class Summary
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
            this.lblSummary = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.summaryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(12, 11);
            this.lblSummary.MinimumSize = new System.Drawing.Size(244, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(244, 23);
            this.lblSummary.TabIndex = 3;
            this.lblSummary.Text = "Confirm the settings";
            // 
            // summaryListView
            // 
            this.summaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.summaryListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.summaryListView.Location = new System.Drawing.Point(15, 37);
            this.summaryListView.Name = "summaryListView";
            this.summaryListView.Size = new System.Drawing.Size(459, 338);
            this.summaryListView.TabIndex = 0;
            this.summaryListView.UseCompatibleStateImageBehavior = false;
            this.summaryListView.View = System.Windows.Forms.View.Details;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.summaryListView);
            this.Controls.Add(this.lblSummary);
            this.Name = "Summary";
            this.Size = new System.Drawing.Size(511, 417);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel lblSummary;
        private System.Windows.Forms.ListView summaryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
