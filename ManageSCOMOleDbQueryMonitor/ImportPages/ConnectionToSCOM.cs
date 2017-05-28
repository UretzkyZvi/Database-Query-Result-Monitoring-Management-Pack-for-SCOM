using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class ConnectionToSCOM : UserControl, IWizardPage
    {
        private SharedData data;
        ManagementGroup _mg;
        private string _Error;
        public ConnectionToSCOM()
        {
            InitializeComponent();
        }

        public ConnectionToSCOM(SharedData data):this()
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
                if (!string.IsNullOrEmpty(txtServer.Text))
                {
                    if (_mg==null)
                    {
                        try
                        {
                            _mg = new ManagementGroup(txtServer.Text);
                        }
                        catch (Exception ex)
                        {
                            _Error = ex.Message;
                            return false;
                        }
                        
                    }
                  
                    if (_mg.IsConnected)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    _Error = "Please fill Server Name";
                    return false;
                }
            }
        }

        public string ValidationMessage
        {
            get
            {
                return _Error;
            }
        }

        public void Cancel()
        {
            //throw new NotImplementedException();
        }

        public void Save()
        {
            if (_mg == null)
            {
                _mg = new ManagementGroup(txtServer.Text);
            }
            this.data.MGConnection = _mg;
        }

        void IWizardPage.Load()
        {
          //  throw new NotImplementedException();
        }
    }
}
