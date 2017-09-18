using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ManageQueryOleDbMonitorUI
{
    public partial class SchedulerSettings : UIPage
    {
        #region Properites and Enum

        [Flags]
        public enum DaysMask
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64
        }

        private int daysOfWeek;

        #endregion Properites and Enum

        #region Constructor

        public SchedulerSettings()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Private Methods

        private SortedDictionary<string, int> Days()
        {
            SortedDictionary<string, int> days = new SortedDictionary<string, int>();
            foreach (int item in Enum.GetValues(typeof(DaysMask)))
            {
                days.Add(((DaysMask)item).ToString(), item);
            }
            return days;
        }

        private bool ValidatePageConfiguration()
        {
            errorProvider.Clear();
            if (cbxDays.SelectedItems.Count == 0)
            {
                errorProvider.SetError(cbxDays, string.Format(CultureInfo.CurrentUICulture, "Select at least one day", new object[0]));
                return false;
            }
            DateTime dt1;
            DateTime dt2;
            if (DateTime.TryParse(txtStartTime.Text, out dt1) && DateTime.TryParse(txtEndTime.Text, out dt2))
            {
                if ((dt2 - dt1).TotalSeconds < 0)
                {
                    errorProvider.SetError(txtStartTime, string.Format(CultureInfo.CurrentUICulture, "Start time should be less or equal then end time", new object[0]));
                    return false;
                }
            }
            return true;
        }

        private void SetSharedUserData()
        {
            SharedUserData["SchedulerSettings.IntervalSeconds"] = GetIntervalSeconds();
            SharedUserData["SchedulerSettings.StartDay"] = txtStartTime.Text;
            SharedUserData["SchedulerSettings.EndDay"] = txtEndTime.Text;
            SharedUserData["SchedulerSettings.SyncTime"] = txtSyncTime.Text;
            SharedUserData["SchedulerSettings.DaysOfWeekMask"] = getDayOfMask();
        }

        private int getDayOfMask()
        {
            int mask = 0;
            foreach (KeyValuePair<string, int> item in cbxDays.CheckedItems)
            {
                mask = mask + item.Value;
            }
            return mask;
        }

        private int GetIntervalSeconds()
        {
            switch (cmbTimes.SelectedItem.ToString())
            {
                case "Seconds":
                    return (int)txtIntervalSeconds.Value;

                case "Minutes":
                    return (int)txtIntervalSeconds.Value * 60;

                case "Hours":
                    return (int)txtIntervalSeconds.Value * 60 * 60;

                case "Days":
                    return (int)txtIntervalSeconds.Value * 60 * 60 * 24;

                default:
                    return 0;
            }
        }

        #endregion Private Methods

        #region Public Methods

        public override bool OnSetActive()
        {
            cbxDays.DataSource = new BindingSource(Days().OrderBy(x => x.Value), null);
            cbxDays.DisplayMember = "Key";
            cbxDays.ValueMember = "Value";

            if (daysOfWeek != 0)
            {
                DaysMask DaysVal = (DaysMask)Enum.ToObject(typeof(DaysMask), daysOfWeek);
                IEnumerable<Enum> values = DaysVal.GetUniqueFlags();
                foreach (DaysMask item in values)
                {
                    cbxDays.SetItemChecked(cbxDays.Items.IndexOf(new KeyValuePair<string, int>(item.ToString(), (int)item)), true);
                }
            }
            else
            {
                cmbTimes.SelectedIndex = 1;
                for (int i = 0; i < cbxDays.Items.Count; i++)
                {
                    cbxDays.SetItemChecked(i, true);
                }
            }
            IsConfigValid = ValidatePageConfiguration();
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
                    SchedulerSettingsConfig config = XmlHelper.Deserialize(InputConfigurationXml, typeof(SchedulerSettingsConfig), true) as SchedulerSettingsConfig;
                    daysOfWeek = config.DaysOfWeekMask;
                    txtIntervalSeconds.Value = config.IntervalSeconds;
                    cmbTimes.SelectedIndex = 0;
                    txtSyncTime.Text = config.SyncTime;
                    txtStartTime.Text = config.StartDay;
                    txtEndTime.Text = config.EndDay;
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
            SchedulerSettingsConfig config = new SchedulerSettingsConfig();
            config.DaysOfWeekMask = getDayOfMask();
            config.IntervalSeconds = GetIntervalSeconds();
            config.SyncTime = txtSyncTime.Text;
            config.StartDay = txtStartTime.Text;
            config.EndDay = txtEndTime.Text;

            OutputConfigurationXml = XmlHelper.Serialize(config, true);
            SetSharedUserData();
            return true;
        }

        #endregion Public Methods
    }
}