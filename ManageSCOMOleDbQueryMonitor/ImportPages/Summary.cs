using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class Summary : UserControl, IWizardPage
    {
        private SharedData data;

        public Summary()
        {
            InitializeComponent();
        }

        public Summary(SharedData data) : this()
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
                return true;
            }
        }

        public string ValidationMessage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Cancel()
        {

        }

        public void Save()
        {
            SCOMSDKWrapper instance = new SCOMSDKWrapper(data);
            instance.CreateInstance();
        }

        void IWizardPage.Load()
        {
            txtSummary.Text = string.Format(
                "Are you sure want to create OleDB Query?\r\nConnection String: {0}\r\n",
                data.QueryDataInfo.ConnectionString
                );
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Query Name", data.MonitorDifinitionInfo.QueryName);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Group Name", data.MonitorDifinitionInfo.GroupName);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Query", data.QueryDataInfo.Query);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Threshold", data.MonitorDifinitionInfo.Threshold);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Samples", data.MonitorDifinitionInfo.Samples);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Direction", data.MonitorDifinitionInfo.Direction);

            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Error Message", data.MonitorDifinitionInfo.ErrorMessage);

            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Sync Time", data.MonitorDifinitionInfo.SyncTime);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Start Time", data.MonitorDifinitionInfo.StartDay);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "End Time", data.MonitorDifinitionInfo.EndDay);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Interval Seconds", data.MonitorDifinitionInfo.IntervalSeconds);
            txtSummary.Text = txtSummary.Text + string.Format("{0}: {1}\r\n", "Days Of Week Mask", data.MonitorDifinitionInfo.DaysOfWeekMask);
           
          
        }
    }
}
