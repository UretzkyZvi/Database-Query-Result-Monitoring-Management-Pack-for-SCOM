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
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using System.Data.OleDb;
using System.Globalization;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;

namespace ManageQueryOleDbMonitorUI
{
    public partial class MonitoringSettings : UIPage
    {

        #region Constructor
        public MonitoringSettings()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods

        private SortedDictionary<string, string> PopulateDirection()
        {
            SortedDictionary<string, string> Direction = new SortedDictionary<string, string>
            {
              {"greater then", "greater"},
              {"greater then or equals", "greaterequal"},
              {"less then", "less"},
              {"less then or equals","lessequal" }
            };
            return Direction;

        }

        private void SetSharedUserData()
        {
            SharedUserData["MonitoringSettings.Threshold"] = (double)txtValue.Value;
            SharedUserData["MonitoringSettings.Samples"] = (int)txtSamples.Value;
            SharedUserData["MonitoringSettings.Direction"] = cmbDirection.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(txtErrorMessage.Text))
            {
                SharedUserData["MonitoringSettings.ErrorMessage"] = txtErrorMessage.Text;
            }
            else
            {
                SharedUserData["MonitoringSettings.ErrorMessage"] = "No Description";
            }
            SharedUserData["MonitoringSettings.GroupName"] = txtGroup.Text;
        }

        private bool ValidatePageConfiguration()
        {
            errorProvider.Clear();
            if (txtSamples.Value <= 0)
            {
                errorProvider.SetError(txtSamples, string.Format(CultureInfo.CurrentUICulture, "Number of samples have to greater then 0", new object[0]));
                return false;
            }
            if (string.IsNullOrEmpty(txtGroup.Text))
            {
                errorProvider.SetError(txtGroup, string.Format(CultureInfo.CurrentUICulture, "You must to specify exist group or create new.", new object[0]));
                return false;
            }
            return true;
        }
        #endregion

        #region Public Methods

        public override bool OnSetActive()
        {
            if (cmbDirection.DataSource == null)
            {
                cmbDirection.DataSource = new BindingSource(PopulateDirection(), null);
                cmbDirection.DisplayMember = "Key";
                cmbDirection.ValueMember = "Value";
            }

            return base.OnSetActive();
        }
        public override void LoadPageConfig()
        {
            if (!IsCreationMode)
            {
                if (string.IsNullOrEmpty(InputConfigurationXml))
                {
                    return;
                }
                try
                {
                    if (cmbDirection.DataSource == null)
                    {
                        cmbDirection.DataSource = new BindingSource(PopulateDirection(), null);
                        cmbDirection.DisplayMember = "Key";
                        cmbDirection.ValueMember = "Value";
                    }
                    MonitoringSettingsConfig config = XmlHelper.Deserialize(InputConfigurationXml, typeof(MonitoringSettingsConfig), true) as MonitoringSettingsConfig;
                    txtValue.Value = (decimal)config.Threshold;
                    txtSamples.Value = config.Samples;
                    cmbDirection.SelectedValue = config.Direction;
                    txtErrorMessage.Text = config.ErrorMessage;
                    txtGroup.Text = config.GroupName;

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
            IsConfigValid = ValidatePageConfiguration();
            base.LoadPageConfig();
        }



        public override bool SavePageConfig()
        {
            IsConfigValid = ValidatePageConfiguration();
            if (!IsConfigValid)
            {
                return false;
            }
            MonitoringSettingsConfig config = new MonitoringSettingsConfig();
            config.Threshold = (double)txtValue.Value;
            config.Direction = cmbDirection.SelectedValue.ToString();
            config.Samples = (int)txtSamples.Value;
            if (!string.IsNullOrEmpty(txtErrorMessage.Text))
            {
                config.ErrorMessage = txtErrorMessage.Text;
            }
            else
            {
                config.ErrorMessage = "No Description";
            }
           
            config.GroupName = txtGroup.Text;

            OutputConfigurationXml = XmlHelper.Serialize(config, true);
            SetSharedUserData();
            return true;
        }


        #endregion

        #region Events
        private void rbtnExistGroup_CheckedChanged(object sender, EventArgs e)
        {
            txtGroup.Enabled = false;
            btnBrowse.Enabled = true;
        }

        private void rbtnNewGroup_CheckedChanged(object sender, EventArgs e)
        {
            txtGroup.Enabled = true;
            btnBrowse.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            GroupChooserDialog dialog = new GroupChooserDialog(this.Container);
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
                        if (!string.IsNullOrEmpty(item.DisplayName))
                        {
                            txtGroup.Text = item.DisplayName;
                            IsConfigValid = ValidatePageConfiguration();
                        }
                    }
                }
            }

        }
        #endregion

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            IsConfigValid = ValidatePageConfiguration();
        }
    }
}
