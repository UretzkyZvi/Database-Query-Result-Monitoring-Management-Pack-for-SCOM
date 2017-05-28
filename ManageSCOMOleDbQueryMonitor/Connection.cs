using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class Connection : KryptonForm
    {
        private SharedData data;
        private Configuration _config;
        public Connection()
        {
            InitializeComponent();
        }

        public Connection(SharedData data):this()
        {
            this.data = data;
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

           
            if (!string.IsNullOrEmpty(_config.AppSettings.Settings["ConnectionServer"].Value))
            {
                txtServer.Text = _config.AppSettings.Settings["ConnectionServer"].Value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("Please Fill SCOM Server");
                return;
            }
            else
            {
                _config.AppSettings.Settings["ConnectionServer"].Value = txtServer.Text;
                _config.Save(ConfigurationSaveMode.Modified);
                try
                {
                    data.MGConnection =
                          new Microsoft.EnterpriseManagement.ManagementGroup(txtServer.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            Close();
        }
    }
}
