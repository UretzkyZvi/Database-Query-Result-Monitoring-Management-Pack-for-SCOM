using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.UI;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
using System.Globalization;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using System.Data.OleDb;

namespace ManageQueryOleDbMonitorUI
{
    public partial class ConnectionAndQuery : UIPage
    {
        #region Private Properties
        private string templateIdString;
        private string UniqueID;
        private string Database;
        private string principalName;
        private IList<EnterpriseManagementObject> Databases;
        #endregion

        #region Events

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DBEngineChooserDialog dialog = new DBEngineChooserDialog(this.Container);
            dialog.ShowDialog(this);
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.SelectedItems != null)
                {
                    ChooserControlItem selectedItem = dialog.SelectedItem as ChooserControlItem;
                    if ((selectedItem == null) || (selectedItem.Item == null))
                    {
                    }
                    else
                    {
                        EnterpriseManagementObject item = selectedItem.Item as EnterpriseManagementObject;
                        if (!string.IsNullOrEmpty(item.FullName))
                        {
                            if (item.DisplayName.ToLower()== "SQLEXPRESS".ToLower() || item.DisplayName.ToLower() == "MSSQLSERVER")
                            {
                                txtInstanceName.Text = item.Path;
                            }
                            else
                            {
                                txtInstanceName.Text = item.Path + "\\" + item.DisplayName;
                            }
                            using (ManageQueryOleDBSDKHelper helper = new ManageQueryOleDBSDKHelper(ManagementGroup))
                            {
                                switch (item.FullName.ToString().Split(':')[0])
                                {
                                    case "Microsoft.SQLServer.DBEngine":
                                        Databases = helper.GetRelatedObjects(item.Id, "Microsoft.SQLServer.Library", "Microsoft.SQLServer.Database");
                                        break;
                                    case "Microsoft.SQLServer.2014.DBEngine":
                                        Databases = helper.GetRelatedObjects(item.Id, "Microsoft.SQLServer.2014.Discovery", "Microsoft.SQLServer.2014.Database");
                                        break;
                                    case "Microsoft.SQLServer.2016.DBEngine":
                                        Databases = helper.GetRelatedObjects(item.Id, "Microsoft.SQLServer.2016.Discovery", "Microsoft.SQLServer.2016.Database");
                                        break;
                                    default:
                                        break;
                                }

                                cmbDatabase.DataSource = new BindingSource(Databases, null);
                                cmbDatabase.DisplayMember = "DisplayName";
                                cmbDatabase.ValueMember = "Id";

                                ManagementPackClass winClass = helper.GetManagementPackClass("Microsoft.Windows.Library", "Microsoft.Windows.Computer");

                                principalName = helper.GetObjectsByName(item.Path, winClass).FirstOrDefault().DisplayName;
                            }
                        }
                    }
                }
            }
        }

        private void txtInstanceName_TextChanged(object sender, EventArgs e)
        {
            cmbDatabase.Enabled = true;

        }

        private void cmbDatabase_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Database = (comboBox.SelectedItem as EnterpriseManagementObject).DisplayName;

            txtQuery.Enabled = true;
            btnTest.Enabled = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.ValidatePageConfiguration();
            using (OleDbConnection con = new OleDbConnection(string.Format("Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI", txtInstanceName.Text, Database)))
            {
                using (OleDbCommand cmd = new OleDbCommand(txtQuery.Text, con))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
                        {
                            double value;
                            if (double.TryParse(dt.Rows[0][0].ToString(), out value))
                            {
                                MessageBox.Show("return numeric value successfully test, result value " + value);

                            }
                            else
                            {
                                MessageBox.Show("return not numeric value rewrite query, result value " + dt.Rows[0][0].ToString());
                                IsConfigValid = false;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("return more then one row or column");
                            IsConfigValid = false;
                            return;
                        }
                    }
                    catch (Exception EX)
                    {

                        MessageBox.Show("Error: " + EX.Message);
                        IsConfigValid = false;
                        return;
                    }

                }
            }
            IsConfigValid = this.ValidatePageConfiguration();
        }
        #endregion

        #region Private Methods
        private bool ValidatePageConfiguration()
        {
            this.errorProvider.Clear();
            if (string.IsNullOrEmpty(txtInstanceName.Text))
            {
                this.errorProvider.SetError(txtInstanceName, string.Format(CultureInfo.CurrentUICulture, "BD Engine must be selected", new object[0]));

                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtQuery.Text))
                {
                    this.errorProvider.SetError(txtQuery, string.Format(CultureInfo.CurrentUICulture, "Query invalid", new object[0]));
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtMetricType.Text))
            {
                this.errorProvider.SetError(txtMetricType, string.Format(CultureInfo.CurrentUICulture, "Give a name to query result", new object[0]));

                return false;
            }

            this.SetSharedUserData();
            return true;
        }

        private void SetSharedUserData()
        {
            SharedUserData["ConnectionAndQuery.TemplateIdString"] = templateIdString;
            SharedUserData["ConnectionAndQuery.UniqueID"] = UniqueID;
            SharedUserData["ConnectionAndQuery.Instance"] = txtInstanceName.Text;
            SharedUserData["ConnectionAndQuery.Database"] = Database;
            SharedUserData["ConnectionAndQuery.Query"] = txtQuery.Text;
            SharedUserData["ConnectionAndQuery.MetricType"] = txtMetricType.Text;
            SharedUserData["ConnectionAndQuery.PrincipalName"] = principalName;

        }
        #endregion

        #region Constructor
        public ConnectionAndQuery()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Methods

        public override void LoadPageConfig()
        {

            if (IsCreationMode)
            {
                // in create mode init new id
                templateIdString = Guid.NewGuid().ToString("N");
                UniqueID = Guid.NewGuid().ToString("N");

                cmbDatabase.Enabled = false;
                txtQuery.Enabled = false;
                btnTest.Enabled = false;

            }
            else
            {
                if (string.IsNullOrEmpty(InputConfigurationXml))
                {
                    return;
                }
                try
                {
                    ConnectionAndQueryConfig config = XmlHelper.Deserialize(InputConfigurationXml, typeof(ConnectionAndQueryConfig), true) as ConnectionAndQueryConfig;
                    templateIdString = config.TemplateIdString;
                    UniqueID = config.UniqueID;
                    txtInstanceName.Text = config.Instance;
                    txtQuery.Text = config.Query;
                    Database = config.Database;
                    cmbDatabase.Text = Database;
                    txtMetricType.Text = config.MetricType;
                    principalName = config.PrincipalName;

                    cmbDatabase.Enabled = false;
                    txtQuery.Enabled = false;
                    btnTest.Enabled = false;

                    SetSharedUserData();

                }
                catch (ArgumentNullException exception)
                {
                    return;
                }
                catch (InvalidOperationException exception2)
                {
                    return;
                }
            }
            base.IsConfigValid = ValidatePageConfiguration();
            base.LoadPageConfig();
        }

        public override bool SavePageConfig()
        {
            IsConfigValid = ValidatePageConfiguration();
            if (!IsConfigValid)
            {
                return false;
            }
            ConnectionAndQueryConfig config = new ConnectionAndQueryConfig();
            config.TemplateIdString = templateIdString;
            config.Instance = txtInstanceName.Text;
            config.Database = Database;
            config.Query = txtQuery.Text;
            config.UniqueID = UniqueID;
            config.MetricType = txtMetricType.Text;
            config.PrincipalName = principalName;


            base.OutputConfigurationXml = XmlHelper.Serialize(config, true);
            this.SetSharedUserData();
            return true;
        }



        #endregion

        private void txtMetricType_TextChanged(object sender, EventArgs e)
        {
            IsConfigValid = ValidatePageConfiguration();
        }
    }
}
