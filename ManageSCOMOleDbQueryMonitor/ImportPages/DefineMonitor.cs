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
    public partial class DefineMonitor : UserControl, IWizardPage
    {



        #region Properties
        private SharedData data;
        public SharedData Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
        internal SortedDictionary<string, string> PopulateDirection()
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

        internal SortedDictionary<string, int> Days()
        {
            SortedDictionary<string, int> days = new SortedDictionary<string, int>();
            foreach (int item in Enum.GetValues(typeof(DaysMask)))
            {
                days.Add(((DaysMask)item).ToString(), item);
            }
           
            //Array a = Enum.GetValues(typeof(DaysMask));
            //DaysMask aa = (DaysMask)Enum.Parse(typeof(DaysMask), arr[0]);

            //SortedDictionary<string, int> days = new SortedDictionary<string, int>
            //{
            //    {"Sunday", 1},
            //    {"Monday", 2},
            //    {"Tuesday", 4},
            //    {"Wednesday", 8},
            //    {"Thursday", 16},
            //    {"Friday", 32},
            //    {"Saturday",64 }
            //};
            return days;

        }
        #endregion

        public DefineMonitor()
        {
            InitializeComponent();
        }

        public DefineMonitor(SharedData data) : this()
        {
            Data = data;
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
                if (Validation())
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
                return "Please fill all fields";
            }
        }



        public void Cancel()
        {
            //throw new NotImplementedException();
        }

        public void Save()
        {
            Data.MonitorDifinitionInfo = new MonitorDifinition();
            Data.MonitorDifinitionInfo.StartDay = txtStartDay.Text;
            Data.MonitorDifinitionInfo.EndDay = txtEndDay.Text;
            Data.MonitorDifinitionInfo.SyncTime = txtSyncTime.Text;
            Data.MonitorDifinitionInfo.IntervalSeconds = (int)DateTime.Parse(txtIntervalSeconds.Text).TimeOfDay.TotalSeconds;
            int mask = 0;
            foreach (KeyValuePair<string, int> item in cbxDays.CheckedItems)
            {
                mask = mask + item.Value;
            }
            Data.MonitorDifinitionInfo.DaysOfWeekMask = mask;
            Data.MonitorDifinitionInfo.GroupName = txtGroupName.Text;
            Data.MonitorDifinitionInfo.QueryName = txtQueryName.Text;
            Data.MonitorDifinitionInfo.ErrorMessage = txtErrMessage.Text;
            Data.MonitorDifinitionInfo.MetricType = txtMetricType.Text;

            Data.MonitorDifinitionInfo.Direction = cmbDirection.SelectedValue.ToString();
            Data.MonitorDifinitionInfo.Samples = (int)txtSamples.Value;
            if (!string.IsNullOrEmpty(txtThreshold.Text))
            {
                Data.MonitorDifinitionInfo.Threshold = double.Parse(txtThreshold.Text);
            }

        }

        void IWizardPage.Load()
        {

            cmbDirection.DataSource = new BindingSource(PopulateDirection(), null);
            cmbDirection.DisplayMember = "Key";
            cmbDirection.ValueMember = "Value";

            cbxDays.ListBox.DataSource = new BindingSource(Days().OrderBy(x => x.Value), null);
            cbxDays.ListBox.DisplayMember = "Key";
            cbxDays.ListBox.ValueMember = "Value";
            for (int i = 0; i < cbxDays.ListBox.Items.Count; i++)
            {
                cbxDays.SetItemChecked(i, true);
            }

        }

        private bool Validation()
        {
            bool valid;
            valid = !string.IsNullOrEmpty(txtGroupName.Text) ? true : false;
            valid = !string.IsNullOrEmpty(txtQueryName.Text) ? true : false;
            valid = !string.IsNullOrEmpty(txtErrMessage.Text) ? true : false;
            valid = !string.IsNullOrEmpty(txtMetricType.Text) ? true : false;
            valid = !string.IsNullOrEmpty(txtThreshold.Text) ? true : false;
            return valid;
        }
    }
}
