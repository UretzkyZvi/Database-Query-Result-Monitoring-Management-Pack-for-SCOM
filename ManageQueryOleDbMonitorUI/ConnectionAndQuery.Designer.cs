namespace ManageQueryOleDbMonitorUI
{
    partial class ConnectionAndQuery
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
            this.lblDBEngineSelect = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInstanceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMetricType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblDBEngineSelect
            // 
            this.lblDBEngineSelect.BackColor = System.Drawing.Color.Transparent;
            this.lblDBEngineSelect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDBEngineSelect.Location = new System.Drawing.Point(12, 16);
            this.lblDBEngineSelect.MinimumSize = new System.Drawing.Size(244, 0);
            this.lblDBEngineSelect.Name = "lblDBEngineSelect";
            this.lblDBEngineSelect.Size = new System.Drawing.Size(244, 23);
            this.lblDBEngineSelect.TabIndex = 11;
            this.lblDBEngineSelect.Text = "Connection string and query definition";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(518, 73);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInstanceName
            // 
            this.txtInstanceName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtInstanceName.Location = new System.Drawing.Point(12, 73);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.ReadOnly = true;
            this.txtInstanceName.Size = new System.Drawing.Size(485, 21);
            this.txtInstanceName.TabIndex = 9;
            this.txtInstanceName.TextChanged += new System.EventHandler(this.txtInstanceName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(12, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Note: Query result must be a single numeric value";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(524, 414);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 197);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(588, 200);
            this.txtQuery.TabIndex = 15;
            this.txtQuery.Text = "";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(12, 139);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(587, 21);
            this.cmbDatabase.TabIndex = 14;
            this.cmbDatabase.SelectedValueChanged += new System.EventHandler(this.cmbDatabase_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select a database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Database Engine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Write Query";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Give a name to the result for purposes performance collection\r\n(Metric name)";
            // 
            // txtMetricType
            // 
            this.txtMetricType.Location = new System.Drawing.Point(12, 472);
            this.txtMetricType.Name = "txtMetricType";
            this.txtMetricType.Size = new System.Drawing.Size(293, 20);
            this.txtMetricType.TabIndex = 21;
            this.txtMetricType.TextChanged += new System.EventHandler(this.txtMetricType_TextChanged);
            // 
            // ConnectionAndQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMetricType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDBEngineSelect);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtInstanceName);
            this.Name = "ConnectionAndQuery";
            this.Size = new System.Drawing.Size(606, 530);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel lblDBEngineSelect;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInstanceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMetricType;
        private System.Windows.Forms.Label label5;
    }
}
