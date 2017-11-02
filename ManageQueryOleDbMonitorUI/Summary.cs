using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManageQueryOleDbMonitorUI
{
    public partial class Summary : UIPage
    {
        #region Properties

        private string name;
        private string description;
        private ManagementPack outputManagementPack;
        public string UniqueID { get; set; }
        public string Instance { get; set; }
        public string Database { get; set; }
        public string QueryName { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string SyncTime { get; set; }
        public int IntervalSeconds { get; set; }
        public string Query { get; set; }
        public int DaysOfWeekMask { get; set; }
        public string GroupName { get; set; }
        public string Direction { get; set; }
        public string ErrorMessage { get; set; }
        public string MetricType { get; set; }
        public int Samples { get; set; }
        public double Threshold { get; set; }
        public string PrincipalName { get; set; }
        public string ConnectionString { get; set; }

        #endregion Properties

        #region Constructor

        public Summary()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Public Methods

        public override bool OnSetActive()
        {
            GetSharedUserData();
            SetListViewItems();
            IsConfigValid = true;

            return base.OnSetActive();
        }

        public override bool SavePageConfig()
        {
            if (!DestinationManagementPack.References.ContainsKey("Windows"))
            {
                ManagementPackCriteria mpCriteria = new ManagementPackCriteria("Name='Microsoft.Windows.Library'");
                IList<ManagementPack> managementPacks =
                 ManagementGroup.ManagementPacks.GetManagementPacks(mpCriteria);
                DestinationManagementPack.References.Add("Windows", managementPacks[0]);
                mpCriteria = null;
            }
            if (!DestinationManagementPack.References.ContainsKey("Health"))
            {
                ManagementPackCriteria mpCriteria = new ManagementPackCriteria("Name='System.Health.Library'");
                IList<ManagementPack> managementPacks =
                 ManagementGroup.ManagementPacks.GetManagementPacks(mpCriteria);
                DestinationManagementPack.References.Add("Health", managementPacks[0]);
                mpCriteria = null;
            }
            if (!DestinationManagementPack.References.ContainsKey("SCDW"))
            {
                ManagementPackCriteria mpCriteria = new ManagementPackCriteria("Name='Microsoft.SystemCenter.DataWarehouse.Library'");
                IList<ManagementPack> managementPacks =
                 ManagementGroup.ManagementPacks.GetManagementPacks(mpCriteria);
                DestinationManagementPack.References.Add("SCDW", managementPacks[0]);
                mpCriteria = null;
            }
            return base.SavePageConfig();
        }

        protected override void PageContextObjectCommitting(ObjectCommittingEventArgs e)
        {
            base.PageContextObjectCommitting(e);
        }

        protected override void PageContextObjectChanged(ObjectChangedEventArgs args)
        {
            base.PageContextObjectChanged(args);
        }

        protected override void PageContextObjectCommitted(EventArgs e)
        {
            base.PageContextObjectCommitted(e);
        }

        #endregion Public Methods

        #region Private Methods

        private void GetSharedUserData()
        {
            name = SharedUserData["NameAndDescriptionPage.Name"] as string;
            description = SharedUserData["NameAndDescriptionPage.Description"] as string;
            outputManagementPack = SharedUserData["NameAndDescriptionPage.ManagementPack"] as ManagementPack;
            UniqueID = SharedUserData["ConnectionAndQuery.UniqueID"] as string;
            Instance = SharedUserData["ConnectionAndQuery.Instance"] as string;
            Database = SharedUserData["ConnectionAndQuery.Database"] as string;
            QueryName = SharedUserData["NameAndDescriptionPage.Name"] as string;
            StartDay = SharedUserData["SchedulerSettings.StartDay"] as string;
            EndDay = SharedUserData["SchedulerSettings.EndDay"] as string;
            SyncTime = SharedUserData["SchedulerSettings.SyncTime"] as string;
            IntervalSeconds = int.Parse(SharedUserData["SchedulerSettings.IntervalSeconds"].ToString());
            Query = SharedUserData["ConnectionAndQuery.Query"] as string;
            DaysOfWeekMask = int.Parse(SharedUserData["SchedulerSettings.DaysOfWeekMask"].ToString());
            GroupName = SharedUserData["MonitoringSettings.GroupName"] as string;
            Direction = SharedUserData["MonitoringSettings.Direction"] as string;
            ErrorMessage = SharedUserData["MonitoringSettings.ErrorMessage"] as string;
            MetricType = SharedUserData["ConnectionAndQuery.MetricType"] as string;
            Samples = int.Parse(SharedUserData["MonitoringSettings.Samples"].ToString());
            Threshold = double.Parse(SharedUserData["MonitoringSettings.Threshold"].ToString());
            PrincipalName = SharedUserData["ConnectionAndQuery.PrincipalName"] as string;
            ConnectionString = SharedUserData["ConnectionAndQuery.ConnectionString"] as string;
        }

        private void SetListViewItems()
        {
            summaryListView.Items.Clear();

            IsConfigValid = false;
            AddSummaryItem("Name", name);
            if (!string.IsNullOrEmpty(description))
            {
                AddSummaryItem("Description", description);
            }
            if (DestinationManagementPack != null)
            {
                AddSummaryItem("Management Pack", DestinationManagementPack.DisplayName);
            }
            else if (outputManagementPack != null)
            {
                AddSummaryItem("Management Pack", outputManagementPack.DisplayName);
            }
            AddSummaryItem("Instance", Instance.ToUpper());
            AddSummaryItem("Database", Database);
            AddSummaryItem("Query", Query);

            summaryListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            summaryListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void AddSummaryItem(string name, string value)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(value);
            summaryListView.Items.Add(item);
        }

        #endregion Private Methods
    }
}