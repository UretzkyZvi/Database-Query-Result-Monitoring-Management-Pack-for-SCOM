using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Common;
using ComponentFactory.Krypton.Toolkit;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class SelectSQLDBEngine : UserControl, IWizardPage
    {
        private SharedData data;
        private IObjectReader<EnterpriseManagementObject> reader;
        public SelectSQLDBEngine()
        {
            InitializeComponent();
        }

        public SelectSQLDBEngine(SharedData data) : this()
        {
            this.data = data;
        }

        public UserControl Content
        {
            get
            {
                return this;
            }
        }

        public bool IsBusy
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool PageValid
        {
            get
            {
                if (lbxDbEngine.SelectedItem != null && (Guid)lbxDbEngine.SelectedValue !=Guid.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string ValidationMessage
        {
            get
            {
                return "Please Select DB Engine";
            }
        }

        public void Cancel()
        {
            //  throw new NotImplementedException();
        }

        public void Save()
        {
            data.DBEngine = (EnterpriseManagementObject)lbxDbEngine.SelectedItem;
        }

        void IWizardPage.Load()
        {

            SCOMSDKWrapper sdk = new SCOMSDKWrapper(data);

            if (reader==null)
            {
                reader = sdk.GetEnterpriseManagementObjects("Microsoft.SQLServer.DBEngine", "Microsoft.SQLServer.Library");
            }


            lbxDbEngine.ListBox.DataSource = new BindingSource(reader.OrderBy(x => x.Path), null);
            lbxDbEngine.ListBox.ValueMember = "Id";
            lbxDbEngine.ListBox.DisplayMember = "FullName";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            KryptonTextBox txt = sender as KryptonTextBox;
            IEnumerable<EnterpriseManagementObject> dataFiltered = reader.Where(x => x.FullName.Contains(txt.Text)).OrderBy(y => y.Path);
            if (dataFiltered.Count()==0)
            {
                KeyValuePair<Guid, string> noDataKeyPair = new KeyValuePair<Guid, string>(Guid.Empty, "No DB Engine");
                lbxDbEngine.ListBox.DataSource = new BindingSource(noDataKeyPair, null);
                lbxDbEngine.ListBox.ValueMember = "Key";
                lbxDbEngine.ListBox.DisplayMember = "Value";
            }
            else
            {
                lbxDbEngine.ListBox.DataSource = new BindingSource(dataFiltered, null);
                lbxDbEngine.ListBox.ValueMember = "Id";
                lbxDbEngine.ListBox.DisplayMember = "FullName";
            }
            
        }
    }
}
